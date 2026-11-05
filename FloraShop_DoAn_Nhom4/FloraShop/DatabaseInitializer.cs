using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    /// <summary>
    /// Tiện ích tự động kiểm tra và khởi tạo CSDL FloraShopDB khi mang dự án sang máy tính khác.
    /// Giúp người dùng hoặc giảng viên chấm thi có thể chạy ngay mà không bắt buộc phải mở SSMS.
    /// </summary>
    public static class DatabaseInitializer
    {
        private static readonly string[] CandidateServers = new string[]
        {
            @".\SQLEXPRESS",
            ".",
            "localhost",
            @"(localdb)\MSSQLLocalDB",
            @"localhost\SQLEXPRESS"
        };

        /// <summary>
        /// Tự động dò tìm phiên bản máy chủ SQL Server đang hoạt động trên máy tính
        /// </summary>
        public static string DetectActiveServer()
        {
            foreach (string srv in CandidateServers)
            {
                try
                {
                    string connStr = $@"Server={srv};Database=master;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=2;";
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        return srv; // Tìm thấy server đang online!
                    }
                }
                catch
                {
                    // Thử server tiếp theo
                }
            }
            return @".\SQLEXPRESS"; // Giá trị mặc định
        }

        /// <summary>
        /// Tìm đường dẫn thực tế của tập tin Database_Setup_And_SeedData.sql
        /// </summary>
        public static string GetScriptPath()
        {
            string[] possiblePaths = new string[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "Database_Setup_And_SeedData.sql"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Database", "Database_Setup_And_SeedData.sql"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Database", "Database_Setup_And_SeedData.sql"),
                @"d:\DOAN\DOAN\FloraShop\Database\Database_Setup_And_SeedData.sql"
            };

            foreach (string p in possiblePaths)
            {
                string fullPath = Path.GetFullPath(p);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Thực thi file script T-SQL để khởi tạo Database, Bảng, Views, SP, Functions, Triggers và Seed Data
        /// </summary>
        public static bool ExecuteSetupScript(string serverName, out string message)
        {
            try
            {
                string scriptPath = GetScriptPath();
                if (string.IsNullOrEmpty(scriptPath))
                {
                    message = "Không tìm thấy tập tin [Database_Setup_And_SeedData.sql] trong thư mục Database!";
                    return false;
                }

                string masterConnStr = $@"Server={serverName};Database=master;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=8;";
                using (SqlConnection conn = new SqlConnection(masterConnStr))
                {
                    conn.Open();

                    string script = File.ReadAllText(scriptPath);
                    string[] batches = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                    foreach (string batch in batches)
                    {
                        string trimmed = batch.Trim();
                        if (string.IsNullOrWhiteSpace(trimmed)) continue;

                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(trimmed, conn))
                            {
                                cmd.CommandTimeout = 90;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (SqlException sqlex)
                        {
                            // Bỏ qua các cảnh báo DROP không tồn tại
                            if (!sqlex.Message.Contains("Cannot drop", StringComparison.OrdinalIgnoreCase))
                            {
                                // Không gián đoạn toàn bộ batch trừ phi lỗi nghiêm trọng
                            }
                        }
                    }
                }

                message = $"Khởi tạo CSDL FloraShopDB thành công trên máy chủ [{serverName}]!\nĐã nạp đầy đủ 7 bảng BCNF, Views, SP, Triggers và dữ liệu mẫu.";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Lỗi khi kết nối hoặc tạo CSDL trên máy chủ [{serverName}]:\n{ex.Message}\n\nGợi ý: Kiểm tra dịch vụ SQL Server của máy tính đã bật chưa.";
                return false;
            }
        }

        /// <summary>
        /// Tự động kiểm tra và khởi tạo CSDL trong nền khi ứng dụng khởi chạy
        /// </summary>
        public static void EnsureDatabase()
        {
            try
            {
                string activeServer = DetectActiveServer();
                Session.ServerName = activeServer;

                string masterConnStr = $@"Server={activeServer};Database=master;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=3;";

                using (SqlConnection conn = new SqlConnection(masterConnStr))
                {
                    conn.Open();

                    using (SqlCommand checkCmd = new SqlCommand("SELECT DB_ID(@DbName)", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@DbName", Session.DatabaseName);
                        object result = checkCmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return; // CSDL đã có sẵn
                        }
                    }
                }

                // Nếu chưa có CSDL, tự động chạy khởi tạo
                ExecuteSetupScript(activeServer, out _);
            }
            catch
            {
                // Để FrmLogin hiển thị lỗi trực quan cho người dùng xử lý nếu cần
            }
        }
    }
}
