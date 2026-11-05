using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        // Hiển thị danh sách khách hàng
        private void LoadKhachHang(string tuKhoa = "")
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT MaKH, HoTenKH, SoDienThoai, Email, DiaChi
                        FROM KhachHang
                        WHERE 1=1 ";

                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        sql += " AND (MaKH LIKE @TuKhoa OR HoTenKH LIKE @TuKhoa OR SoDienThoai LIKE @TuKhoa)";
                    }

                    sql += " ORDER BY MaKH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(tuKhoa))
                        {
                            cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa.Trim() + "%");
                        }

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        dgvKhachHang.DataSource = dt;
                        dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvKhachHang.MultiSelect = false;
                        dgvKhachHang.ReadOnly = true;
                        dgvKhachHang.AllowUserToAddRows = false;

                        if (dgvKhachHang.Columns.Contains("MaKH"))
                            dgvKhachHang.Columns["MaKH"].HeaderText = "Mã KH";
                        if (dgvKhachHang.Columns.Contains("HoTenKH"))
                            dgvKhachHang.Columns["HoTenKH"].HeaderText = "Họ Tên Khách Hàng";
                        if (dgvKhachHang.Columns.Contains("SoDienThoai"))
                            dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                        if (dgvKhachHang.Columns.Contains("Email"))
                            dgvKhachHang.Columns["Email"].HeaderText = "Email";
                        if (dgvKhachHang.Columns.Contains("DiaChi"))
                            dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách khách hàng.\n" + ex.Message,
                    "Thông báo lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!");
                txtMaKhachHang.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!");
                txtTenKhachHang.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtSoDienThoai.Focus();
                return false;
            }

            return true;
        }

        // Thêm khách hàng
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO KhachHang (MaKH, HoTenKH, SoDienThoai, Email, DiaChi)
                        VALUES (@MaKH, @HoTenKH, @SoDienThoai, @Email, @DiaChi)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@HoTenKH", txtTenKhachHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", (object)txtEmail.Text.Trim() ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DiaChi", (object)txtDiaChi.Text.Trim() ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadKhachHang();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật khách hàng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        UPDATE KhachHang
                        SET HoTenKH = @HoTenKH,
                            SoDienThoai = @SoDienThoai,
                            Email = @Email,
                            DiaChi = @DiaChi
                        WHERE MaKH = @MaKH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@HoTenKH", txtTenKhachHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", (object)txtEmail.Text.Trim() ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DiaChi", (object)txtDiaChi.Text.Trim() ?? DBNull.Value);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LamMoi();
                            LoadKhachHang();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa khách hàng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách hàng này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadKhachHang();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229 || ex.Message.Contains("permission was denied"))
                {
                    MessageBox.Show("CẢNH BÁO: Quyền [User] bị từ chối xóa dữ liệu!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Không thể xóa khách hàng đã có lịch sử đơn hàng!\n" + ex.Message, "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Tìm kiếm khách hàng
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadKhachHang(txtTimKiem.Text);
        }

        // Chọn dòng trên DataGridView
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                txtMaKhachHang.Text = row.Cells["MaKH"].Value?.ToString() ?? "";
                txtTenKhachHang.Text = row.Cells["HoTenKH"].Value?.ToString() ?? "";
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";

                txtMaKhachHang.Enabled = false;
            }
        }

        // Làm mới ô nhập
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadKhachHang();
        }

        private void LamMoi()
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();

            txtMaKhachHang.Enabled = true;
            txtMaKhachHang.Focus();
        }
    }
}
