using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
            if (cboVaiTro != null)
            {
                cboVaiTro.Items.Clear();
                cboVaiTro.Items.Add("Admin");
                cboVaiTro.Items.Add("User");
                cboVaiTro.SelectedIndex = 1;
            }
            LoadNhanVien();
        }

        // Hiển thị danh sách nhân viên
        private void LoadNhanVien(string tuKhoa = "")
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT MaNV, HoTenNV, SoDienThoai, ChucVu, TenDangNhap, QuyenHan
                        FROM NhanVien
                        WHERE 1=1 ";

                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        sql += " AND (MaNV LIKE @TuKhoa OR HoTenNV LIKE @TuKhoa OR TenDangNhap LIKE @TuKhoa)";
                    }

                    sql += " ORDER BY MaNV";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(tuKhoa))
                        {
                            cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa.Trim() + "%");
                        }

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            adapter.Fill(dt);

                        dgvNhanVien.DataSource = dt;

                        if (dgvNhanVien.Columns.Contains("MaNV"))
                            dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                        if (dgvNhanVien.Columns.Contains("HoTenNV"))
                            dgvNhanVien.Columns["HoTenNV"].HeaderText = "Họ Tên Nhân Viên";
                        if (dgvNhanVien.Columns.Contains("SoDienThoai"))
                            dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                        if (dgvNhanVien.Columns.Contains("ChucVu"))
                            dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ";
                        if (dgvNhanVien.Columns.Contains("TenDangNhap"))
                            dgvNhanVien.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
                        if (dgvNhanVien.Columns.Contains("QuyenHan"))
                            dgvNhanVien.Columns["QuyenHan"].HeaderText = "Quyền Hạn";

                        dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvNhanVien.MultiSelect = false;
                        dgvNhanVien.ReadOnly = true;
                        dgvNhanVien.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách nhân viên.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                txtMaNhanVien.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!");
                txtTenNhanVien.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                txtTenDangNhap.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return false;
            }
            return true;
        }

        // Thêm nhân viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO NhanVien (MaNV, HoTenNV, SoDienThoai, ChucVu, TenDangNhap, MatKhau, QuyenHan)
                        VALUES (@MaNV, @HoTenNV, @SoDienThoai, @ChucVu, @TenDangNhap, @MatKhau, @QuyenHan)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", txtMaNhanVien.Text.Trim());
                        cmd.Parameters.AddWithValue("@HoTenNV", txtTenNhanVien.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoDienThoai", (object)txtSoDienThoai.Text.Trim() ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ChucVu", string.IsNullOrWhiteSpace(txtChucVu.Text) ? "Nhân viên bán hàng" : txtChucVu.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text.Trim());
                        cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text.Trim());
                        cmd.Parameters.AddWithValue("@QuyenHan", cboVaiTro.SelectedItem?.ToString() ?? "User");

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadNhanVien();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa nhân viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        UPDATE NhanVien
                        SET HoTenNV = @HoTenNV,
                            SoDienThoai = @SoDienThoai,
                            ChucVu = @ChucVu,
                            MatKhau = @MatKhau,
                            QuyenHan = @QuyenHan
                        WHERE MaNV = @MaNV";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", txtMaNhanVien.Text.Trim());
                        cmd.Parameters.AddWithValue("@HoTenNV", txtTenNhanVien.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoDienThoai", (object)txtSoDienThoai.Text.Trim() ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ChucVu", string.IsNullOrWhiteSpace(txtChucVu.Text) ? "Nhân viên bán hàng" : txtChucVu.Text.Trim());
                        cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text.Trim());
                        cmd.Parameters.AddWithValue("@QuyenHan", cboVaiTro.SelectedItem?.ToString() ?? "User");

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadNhanVien();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa nhân viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMaNhanVien.Text.Trim() == Session.MaNV)
            {
                MessageBox.Show("Không thể tự xóa tài khoản đang đăng nhập của chính bạn!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult kq = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên [{txtMaNhanVien.Text.Trim()}] không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", txtMaNhanVien.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadNhanVien();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể xóa nhân viên này (có thể đã lập đơn hàng)!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadNhanVien(txtTimKiem.Text);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadNhanVien(txtTimKiem.Text.Trim());
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNhanVien.Text = row.Cells["MaNV"].Value?.ToString() ?? "";
                txtTenNhanVien.Text = row.Cells["HoTenNV"].Value?.ToString() ?? "";
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString() ?? "";
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";

                string quyen = row.Cells["QuyenHan"].Value?.ToString() ?? "User";
                if (cboVaiTro != null)
                {
                    cboVaiTro.SelectedItem = quyen;
                }

                txtMaNhanVien.Enabled = false;
                txtTenDangNhap.Enabled = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadNhanVien();
        }

        private void LamMoi()
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            txtSoDienThoai.Clear();
            txtChucVu.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtTimKiem.Clear();

            if (cboVaiTro != null)
                cboVaiTro.SelectedIndex = 1;

            txtMaNhanVien.Enabled = true;
            txtTenDangNhap.Enabled = true;
            txtMaNhanVien.Focus();
        }
    }
}
