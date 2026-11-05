using System;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    /// <summary>
    /// Lớp Session quản lý trạng thái phiên làm việc của người dùng hiện tại,
    /// lưu thông tin phân quyền và cấu hình chuỗi kết nối (Windows Authentication hoặc SQL Server Authentication).
    /// </summary>
    public static class Session
    {
        // Thông tin người dùng đăng nhập hiện tại
        public static string MaNV { get; set; } = "NV01";
        public static string HoTenNV { get; set; } = "Lê Quản Trị";
        public static string QuyenHan { get; set; } = "Admin"; // 'Admin' hoặc 'User'
        public static string ChucVu { get; set; } = "Cửa hàng trưởng";
        public static string TenDangNhap { get; set; } = "admin";

        // Cấu hình máy chủ SQL Server
        public static string ServerName { get; set; } = @".\SQLEXPRESS";
        public static string DatabaseName { get; set; } = "FloraShopDB";

        // Chế độ xác thực: "Windows" hoặc "SQL"
        public static string AuthMode { get; set; } = "Windows";

        // Chuỗi kết nối đang kích hoạt
        public static string ConnectionString { get; set; } =
           @"Server=.\SQLEXPRESS;Database=FloraShopDB;Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>
        /// Khởi tạo trạng thái phiên sau khi xác thực thành công từ bảng NhanVien
        /// </summary>
        public static void SetSession(string maNV, string hoTenNV, string quyenHan, string chucVu, string tenDangNhap, string authMode)
        {
            MaNV = maNV;
            HoTenNV = hoTenNV;
            QuyenHan = quyenHan;
            ChucVu = chucVu;
            TenDangNhap = tenDangNhap;
            AuthMode = authMode;

            if (authMode == "SQL")
            {
                // Chuyển đổi Connection String tương ứng với SQL Login (Flora_Admin hoặc Flora_User)
                if (quyenHan.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    ConnectionString = $@"Server={ServerName};Database={DatabaseName};User Id=Flora_Admin;Password=FloraAdmin@2026!;TrustServerCertificate=True;";
                }
                else
                {
                    ConnectionString = $@"Server={ServerName};Database={DatabaseName};User Id=Flora_User;Password=FloraUser@2026!;TrustServerCertificate=True;";
                }
            }
            else
            {
                // Chế độ Windows Authentication
                ConnectionString = $@"Server={ServerName};Database={DatabaseName};Integrated Security=True;TrustServerCertificate=True;";
            }

            // Đồng bộ sang DatabaseConfig để tương thích ngược nếu có module khác gọi
            DatabaseConfig.ConnectionString = ConnectionString;
            DatabaseConfig.CurrentUserId = MaNV;
            DatabaseConfig.CurrentUserName = HoTenNV;
            DatabaseConfig.CurrentRole = QuyenHan;
        }

        /// <summary>
        /// Tạo mới đối tượng SqlConnection sử dụng chuỗi kết nối hiện tại của Session
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Kiểm tra xem người dùng hiện tại có phải là Admin hay không
        /// </summary>
        public static bool IsAdmin()
        {
            return string.Equals(QuyenHan, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Xóa phiên đăng nhập khi người dùng đăng xuất
        /// </summary>
        public static void Clear()
        {
            MaNV = "";
            HoTenNV = "";
            QuyenHan = "User";
            ChucVu = "";
            TenDangNhap = "";
            AuthMode = "Windows";
            ConnectionString = $@"Server={ServerName};Database={DatabaseName};Integrated Security=True;TrustServerCertificate=True;";
            
            DatabaseConfig.ConnectionString = ConnectionString;
            DatabaseConfig.CurrentUserId = "";
            DatabaseConfig.CurrentUserName = "";
            DatabaseConfig.CurrentRole = "User";
        }
    }
}
