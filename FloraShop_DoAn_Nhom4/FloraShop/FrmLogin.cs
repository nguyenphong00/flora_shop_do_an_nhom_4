using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            string connString = $@"Server={Session.ServerName};Database={Session.DatabaseName};Integrated Security=True;TrustServerCertificate=True;Connect Timeout=5;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT MaNV, HoTenNV, ChucVu, TenDangNhap, QuyenHan
                        FROM NhanVien
                        WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string maNV = reader["MaNV"].ToString() ?? "";
                                string hoTenNV = reader["HoTenNV"].ToString() ?? "";
                                string quyenHan = reader["QuyenHan"].ToString() ?? "User";
                                string chucVu = reader["ChucVu"].ToString() ?? "";

                                Session.SetSession(maNV, hoTenNV, quyenHan, chucVu, tenDangNhap, "Windows");

                                MessageBox.Show(
                                    $"Đăng nhập thành công!\nXin chào: {hoTenNV} ({chucVu})",
                                    "FloraShop",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                FrmDashboard dashboard = new FrmDashboard();
                                dashboard.Show();

                                this.Hide();
                                dashboard.FormClosed += (s, args) => this.Close();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Tên đăng nhập hoặc mật khẩu không chính xác!",
                                    "Đăng nhập thất bại",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                txtMatKhau.Clear();
                                txtMatKhau.Focus();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể kết nối đến máy chủ cơ sở dữ liệu!\n\nChi tiết: " + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FrmDangKy frm = new FrmDangKy())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    txtTenDangNhap.Text = frm.CreatedUsername;
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
