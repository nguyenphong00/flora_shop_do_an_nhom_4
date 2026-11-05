using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmKhuyenMai : Form
    {
        public FrmKhuyenMai()
        {
            InitializeComponent();
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today.AddDays(30);
            LoadKhuyenMai();
        }

        // Hiển thị danh sách khuyến mãi
        private void LoadKhuyenMai(string tuKhoa = "")
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT MaKM, TenKM, PhanTramGiam,
                               NgayBatDau, NgayKetThuc, DieuKienToiThieu
                        FROM KhuyenMai
                        WHERE 1=1 ";

                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        sql += " AND (MaKM LIKE @TuKhoa OR TenKM LIKE @TuKhoa)";
                    }

                    sql += " ORDER BY NgayBatDau DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(tuKhoa))
                        {
                            cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa.Trim() + "%");
                        }

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dgvKhuyenMai.DataSource = dt;
                        DinhDangBang();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách khuyến mãi.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Định dạng tiêu đề cột
        private void DinhDangBang()
        {
            if (dgvKhuyenMai.Columns.Contains("MaKM"))
                dgvKhuyenMai.Columns["MaKM"].HeaderText = "Mã KM";

            if (dgvKhuyenMai.Columns.Contains("TenKM"))
                dgvKhuyenMai.Columns["TenKM"].HeaderText = "Tên khuyến mãi";

            if (dgvKhuyenMai.Columns.Contains("PhanTramGiam"))
            {
                dgvKhuyenMai.Columns["PhanTramGiam"].HeaderText = "% Giảm";
                dgvKhuyenMai.Columns["PhanTramGiam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvKhuyenMai.Columns.Contains("NgayBatDau"))
            {
                dgvKhuyenMai.Columns["NgayBatDau"].HeaderText = "Bắt đầu";
                dgvKhuyenMai.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvKhuyenMai.Columns.Contains("NgayKetThuc"))
            {
                dgvKhuyenMai.Columns["NgayKetThuc"].HeaderText = "Kết thúc";
                dgvKhuyenMai.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvKhuyenMai.Columns.Contains("DieuKienToiThieu"))
            {
                dgvKhuyenMai.Columns["DieuKienToiThieu"].HeaderText = "ĐK Tối Thiểu (đ)";
                dgvKhuyenMai.Columns["DieuKienToiThieu"].DefaultCellStyle.Format = "N0";
                dgvKhuyenMai.Columns["DieuKienToiThieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuyenMai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhuyenMai.MultiSelect = false;
            dgvKhuyenMai.ReadOnly = true;
            dgvKhuyenMai.AllowUserToAddRows = false;
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaKM.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi!");
                txtMaKM.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenKM.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chương trình!");
                txtTenKM.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPhanTramGiam.Text.Trim(), out decimal pt) || pt < 0 || pt > 100)
            {
                MessageBox.Show("Phần trăm giảm phải từ 0 đến 100!");
                txtPhanTramGiam.Focus();
                return false;
            }

            if (dtpNgayKetThuc.Value < dtpNgayBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!");
                dtpNgayKetThuc.Focus();
                return false;
            }

            return true;
        }

        // Thêm khuyến mãi
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            decimal dieuKien = 0;
            decimal.TryParse(txtMoTa.Text.Trim(), out dieuKien);

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO KhuyenMai 
                        (MaKM, TenKM, PhanTramGiam, NgayBatDau, NgayKetThuc, DieuKienToiThieu)
                        VALUES 
                        (@MaKM, @TenKM, @PhanTramGiam, @NgayBatDau, @NgayKetThuc, @DieuKienToiThieu)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKM", txtMaKM.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenKM", txtTenKM.Text.Trim());
                        cmd.Parameters.AddWithValue("@PhanTramGiam", decimal.Parse(txtPhanTramGiam.Text.Trim()));
                        cmd.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value.Date);
                        cmd.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value.Date);
                        cmd.Parameters.AddWithValue("@DieuKienToiThieu", dieuKien);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadKhuyenMai();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa khuyến mãi
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            decimal dieuKien = 0;
            decimal.TryParse(txtMoTa.Text.Trim(), out dieuKien);

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        UPDATE KhuyenMai
                        SET TenKM = @TenKM,
                            PhanTramGiam = @PhanTramGiam,
                            NgayBatDau = @NgayBatDau,
                            NgayKetThuc = @NgayKetThuc,
                            DieuKienToiThieu = @DieuKienToiThieu
                        WHERE MaKM = @MaKM";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKM", txtMaKM.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenKM", txtTenKM.Text.Trim());
                        cmd.Parameters.AddWithValue("@PhanTramGiam", decimal.Parse(txtPhanTramGiam.Text.Trim()));
                        cmd.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value.Date);
                        cmd.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value.Date);
                        cmd.Parameters.AddWithValue("@DieuKienToiThieu", dieuKien);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LamMoi();
                            LoadKhuyenMai();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa khuyến mãi
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKM.Text))
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa mã khuyến mãi này không?",
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
                    string sql = "DELETE FROM KhuyenMai WHERE MaKM = @MaKM";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKM", txtMaKM.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
                LoadKhuyenMai();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229 || ex.Message.Contains("permission was denied"))
                {
                    MessageBox.Show("CẢNH BÁO: Quyền [User] bị từ chối xóa dữ liệu!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Không thể xóa mã khuyến mãi vì đang được áp dụng trong đơn hàng!\n" + ex.Message, "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadKhuyenMai(txtTimKiem.Text);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadKhuyenMai(txtTimKiem.Text.Trim());
            }
        }

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhuyenMai.Rows.Count)
            {
                DataGridViewRow row = dgvKhuyenMai.Rows[e.RowIndex];

                txtMaKM.Text = row.Cells["MaKM"].Value?.ToString() ?? "";
                txtTenKM.Text = row.Cells["TenKM"].Value?.ToString() ?? "";
                txtPhanTramGiam.Text = row.Cells["PhanTramGiam"].Value?.ToString() ?? "0";

                if (DateTime.TryParse(row.Cells["NgayBatDau"].Value?.ToString(), out DateTime ngayBD))
                    dtpNgayBatDau.Value = ngayBD;

                if (DateTime.TryParse(row.Cells["NgayKetThuc"].Value?.ToString(), out DateTime ngayKT))
                    dtpNgayKetThuc.Value = ngayKT;

                txtMoTa.Text = row.Cells["DieuKienToiThieu"].Value?.ToString() ?? "0";

                txtMaKM.Enabled = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadKhuyenMai();
        }

        private void LamMoi()
        {
            txtMaKM.Clear();
            txtTenKM.Clear();
            txtPhanTramGiam.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();

            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today.AddDays(30);

            txtMaKM.Enabled = true;
            txtMaKM.Focus();
        }
    }
}
