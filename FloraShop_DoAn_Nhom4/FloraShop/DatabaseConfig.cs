using System;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    /// <summary>
    /// Lớp DatabaseConfig cầu nối giữ tương thích cho các module gọi DatabaseConfig.
    /// Toàn bộ chuỗi kết nối và thông tin người dùng được điều phối qua Session.
    /// </summary>
    public static class DatabaseConfig
    {
        public static string ConnectionString
        {
            get => Session.ConnectionString;
            set => Session.ConnectionString = value;
        }

        public static string CurrentUserId
        {
            get => Session.MaNV;
            set => Session.MaNV = value;
        }

        public static string CurrentUserName
        {
            get => Session.HoTenNV;
            set => Session.HoTenNV = value;
        }

        public static string CurrentRole
        {
            get => Session.QuyenHan;
            set => Session.QuyenHan = value;
        }

        public static string GetConnectionStringForLogin(string username, string password)
        {
            return $@"Server={Session.ServerName};Database={Session.DatabaseName};User Id={username};Password={password};TrustServerCertificate=True;";
        }

        public static SqlConnection GetConnection()
        {
            return Session.CreateConnection();
        }
    }
}
