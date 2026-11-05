using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmDanhMucHoa : Form
    {
        private string maDanhMucDangChon = "";

        public FrmDanhMucHoa()
        {
            InitializeComponent();
        }

        private void FrmDanhMucHoa_Load(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        // Hiển thị danh sách danh mục hoa
        private void TaiDanhSach(string tuKhoa = "")
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT MaDM, TenDM, MoTa
                        FROM DanhMucHoa
                        WHERE 1=1 ";

                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        sql += " AND (MaDM LIKE @TuKhoa OR TenDM LIKE @TuKhoa)";
                    }

                    sql += " ORDER BY MaDM";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(tuKhoa))
                        {
                            cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa.Trim() + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvDanhMuc.DataSource = dt;
                        }
                    }
                }

                if (dgvDanhMuc.Columns.Contains("MaDM"))
                    dgvDanhMuc.Columns["MaDM"].HeaderText = "Mã danh mục";

                if (dgvDanhMuc.Columns.Contains("TenDM"))
                    dgvDanhMuc.Columns["TenDM"].HeaderText = "Tên danh mục";

                if (dgvDanhMuc.Columns.Contains("MoTa"))
                    dgvDanhMuc.Columns["MoTa"].HeaderText = "Mô tả";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh mục hoa.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDanhSach(txtTimKiem.Text.Trim());
        }

        // Kiểm tra dữ liệu nhập
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaDM.Text))
            {
                MessageBox.Show("Vui lòng nhập mã danh mục.");
                txtMaDM.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenDM.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục.");
                txtTenDM.Focus();
                return false;
            }

            return true;
        }

        // Thêm danh mục
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
                        INSERT INTO DanhMucHoa (MaDM, TenDM, MoTa)
                        VALUES (@MaDM, @TenDM, @MoTa)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDM", txtMaDM.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenDM", txtTenDM.Text.Trim());
                        cmd.Parameters.AddWithValue("@MoTa", (object)txtMoTa.Text.Trim() ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm danh mục thành công.");
                LamMoi();
                TaiDanhSach();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        // Sửa danh mục
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDanhMucDangChon))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa từ bảng.");
                return;
            }

            if (!KiemTraDuLieu())
                return;

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        UPDATE DanhMucHoa
                        SET TenDM = @TenDM,
                            MoTa = @MoTa
                        WHERE MaDM = @MaDM";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDM", txtMaDM.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenDM", txtTenDM.Text.Trim());
                        cmd.Parameters.AddWithValue("@MoTa", (object)txtMoTa.Text.Trim() ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật danh mục thành công.");
                LamMoi();
                TaiDanhSach();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        // Xóa danh mục
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDanhMucDangChon))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa từ bảng.");
                return;
            }

            DialogResult kq = MessageBox.Show(
                $"Bạn có chắc muốn xóa danh mục {maDanhMucDangChon} không?",
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
                    string sql = "DELETE FROM DanhMucHoa WHERE MaDM = @MaDM";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDM", maDanhMucDangChon);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Xóa danh mục thành công.");
                LamMoi();
                TaiDanhSach();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229 || ex.Message.Contains("permission was denied"))
                {
                    MessageBox.Show("CẢNH BÁO: Tài khoản [User] bị từ chối quyền XÓA trên bảng DanhMucHoa!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Không thể xóa danh mục vì đang chứa các mặt hàng hoa liên quan.\n" + ex.Message, "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            TaiDanhSach();
        }

        private void LamMoi()
        {
            maDanhMucDangChon = "";
            txtMaDM.Clear();
            txtTenDM.Clear();
            txtMoTa.Clear();
            txtMaDM.Enabled = true;
            txtMaDM.Focus();
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhMuc.Rows.Count)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];

                maDanhMucDangChon = row.Cells["MaDM"].Value?.ToString() ?? "";
                txtMaDM.Text = maDanhMucDangChon;
                txtTenDM.Text = row.Cells["TenDM"].Value?.ToString() ?? "";
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

                txtMaDM.Enabled = false;
            }
        }
    }
}
