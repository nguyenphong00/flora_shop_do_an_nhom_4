using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmDangKy : Form
    {
        public string CreatedUsername { get; private set; } = string.Empty;

        public FrmDangKy()
        {
            InitializeComponent();
            cboChucVu.SelectedIndex = 0; // Mặc định: Nhân viên bán hàng
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string chucVu = cboChucVu.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string xacNhan = txtXacNhanMatKhau.Text;

            // 1. Kiểm tra tính hợp lệ của dữ liệu
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (matKhau != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            string quyenHan = chucVu.Equals("Quản trị viên", StringComparison.OrdinalIgnoreCase) ? "Admin" : "User";

            string connStr = $@"Server={Session.ServerName};Database={Session.DatabaseName};Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // 2. Kiểm tra xem tên đăng nhập đã tồn tại chưa
                    string checkSql = "SELECT COUNT(*) FROM NhanVien WHERE TenDangNhap = @TenDangNhap";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Tên đăng nhập này đã được sử dụng! Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenDangNhap.Focus();
                            return;
                        }
                    }

                    // 3. Tự động sinh mã nhân viên tiếp theo (NV06, NV07, ...)
                    string genSql = "SELECT ISNULL(MAX(CAST(SUBSTRING(MaNV, 3, 10) AS INT)), 0) + 1 FROM NhanVien WHERE MaNV LIKE 'NV%'";
                    int nextId = 1;
                    using (SqlCommand genCmd = new SqlCommand(genSql, conn))
                    {
                        object obj = genCmd.ExecuteScalar();
                        if (obj != null && obj != DBNull.Value)
                        {
                            nextId = Convert.ToInt32(obj);
                        }
                    }
                    string maNV = $"NV{nextId:D2}";

                    // 4. Thêm tài khoản nhân viên mới vào CSDL
                    string insertSql = @"
                        INSERT INTO NhanVien (MaNV, HoTenNV, SoDienThoai, ChucVu, TenDangNhap, MatKhau, QuyenHan)
                        VALUES (@MaNV, @HoTenNV, @SoDienThoai, @ChucVu, @TenDangNhap, @MatKhau, @QuyenHan)";

                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@HoTenNV", hoTen);
                        cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrEmpty(sdt) ? (object)DBNull.Value : sdt);
                        cmd.Parameters.AddWithValue("@ChucVu", chucVu);
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@QuyenHan", quyenHan);

                        cmd.ExecuteNonQuery();
                    }

                    CreatedUsername = tenDangNhap;

                    MessageBox.Show(
                        $"Tạo tài khoản thành công!\n\n" +
                        $"• Mã nhân viên: {maNV}\n" +
                        $"• Họ và tên: {hoTen}\n" +
                        $"• Tên đăng nhập: {tenDangNhap}\n" +
                        $"• Quyền hạn: {quyenHan}\n\n" +
                        "Bạn có thể sử dụng tài khoản này để đăng nhập ngay bây giờ.",
                        "FloraShop",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
