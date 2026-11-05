using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmQuanLyHoa : Form
    {
        private string maHoaDangChon = "";

        public FrmQuanLyHoa()
        {
            InitializeComponent();
        }

        private void FrmQuanLyHoa_Load(object sender, EventArgs e)
        {
            // Thiết lập trạng thái ban đầu của DataGridView
            dgvHoa.AutoGenerateColumns = true;
            dgvHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoa.MultiSelect = false;
            dgvHoa.ReadOnly = true;
            dgvHoa.AllowUserToAddRows = false;

            TaiDanhMucHoa();
            TaiDanhSachHoa();
        }

        /// <summary>
        /// Tải danh mục hoa từ bảng DanhMucHoa vào cboDanhMuc và cboLocDanhMuc
        /// </summary>
        private void TaiDanhMucHoa()
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaDM, TenDM FROM DanhMucHoa ORDER BY TenDM";
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Gán vào ComboBox nhập liệu
                        cboDanhMuc.DataSource = dt.Copy();
                        cboDanhMuc.DisplayMember = "TenDM";
                        cboDanhMuc.ValueMember = "MaDM";
                        cboDanhMuc.SelectedIndex = -1;

                        // Gán vào ComboBox lọc dữ liệu
                        DataTable dtLoc = dt.Copy();
                        DataRow rowTatCa = dtLoc.NewRow();
                        rowTatCa["MaDM"] = "ALL";
                        rowTatCa["TenDM"] = "-- Tất cả danh mục --";
                        dtLoc.Rows.InsertAt(rowTatCa, 0);

                        cboLocDanhMuc.DataSource = dtLoc;
                        cboLocDanhMuc.DisplayMember = "TenDM";
                        cboLocDanhMuc.ValueMember = "MaDM";
                        cboLocDanhMuc.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục hoa: " + ex.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách mặt hàng hoa hiển thị lên DataGridView
        /// </summary>
        private void TaiDanhSachHoa(string maDM = "ALL", string tuKhoa = "")
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            h.MaHoa AS [Mã Hoa],
                            h.TenHoa AS [Tên Mặt Hàng Hoa],
                            dm.TenDM AS [Danh Mục],
                            h.DonViTinh AS [Đơn Vị Tính],
                            h.DonGia AS [Đơn Giá (VNĐ)],
                            h.SoLuongTon AS [Tồn Kho],
                            h.MaDM AS [Mã DM]
                        FROM Hoa h
                        INNER JOIN DanhMucHoa dm ON h.MaDM = dm.MaDM
                        WHERE 1=1 ";

                    if (maDM != "ALL" && !string.IsNullOrEmpty(maDM))
                    {
                        sql += " AND h.MaDM = @MaDM";
                    }

                    if (!string.IsNullOrWhiteSpace(tuKhoa))
                    {
                        sql += " AND (h.MaHoa LIKE @TuKhoa OR h.TenHoa LIKE @TuKhoa)";
                    }

                    sql += " ORDER BY h.MaHoa";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (maDM != "ALL" && !string.IsNullOrEmpty(maDM))
                        {
                            cmd.Parameters.AddWithValue("@MaDM", maDM);
                        }
                        if (!string.IsNullOrWhiteSpace(tuKhoa))
                        {
                            cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa.Trim() + "%");
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvHoa.DataSource = dt;

                            // Ẩn cột Mã DM kỹ thuật nếu có
                            if (dgvHoa.Columns.Contains("Mã DM"))
                                dgvHoa.Columns["Mã DM"].Visible = false;

                            // Định dạng cột tiền tệ
                            if (dgvHoa.Columns.Contains("Đơn Giá (VNĐ)"))
                            {
                                dgvHoa.Columns["Đơn Giá (VNĐ)"].DefaultCellStyle.Format = "N0";
                                dgvHoa.Columns["Đơn Giá (VNĐ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }

                            if (dgvHoa.Columns.Contains("Tồn Kho"))
                            {
                                dgvHoa.Columns["Tồn Kho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvHoa.Rows.Count)
            {
                DataGridViewRow row = dgvHoa.Rows[e.RowIndex];

                maHoaDangChon = row.Cells["Mã Hoa"].Value?.ToString() ?? "";
                txtMaHoa.Text = maHoaDangChon;
                txtTenHoa.Text = row.Cells["Tên Mặt Hàng Hoa"].Value?.ToString() ?? "";
                txtDVT.Text = row.Cells["Đơn Vị Tính"].Value?.ToString() ?? "Bông";

                if (decimal.TryParse(row.Cells["Đơn Giá (VNĐ)"].Value?.ToString(), out decimal donGia))
                    numDonGia.Value = Math.Min(numDonGia.Maximum, Math.Max(numDonGia.Minimum, donGia));

                if (int.TryParse(row.Cells["Tồn Kho"].Value?.ToString(), out int tonKho))
                    numSoLuongTon.Value = Math.Min(numSoLuongTon.Maximum, Math.Max(numSoLuongTon.Minimum, tonKho));

                string maDM = row.Cells["Mã DM"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(maDM))
                    cboDanhMuc.SelectedValue = maDM;
            }
        }

        /// <summary>
        /// Gọi Stored Procedure P_ThemSuaXoa_Hoa để thực thi nghiệp vụ
        /// </summary>
        private void GoiStoredProcedureHoa(string action)
        {
            string maHoa = txtMaHoa.Text.Trim();
            string tenHoa = txtTenHoa.Text.Trim();
            string dvt = txtDVT.Text.Trim();
            decimal donGia = numDonGia.Value;
            int tonKho = (int)numSoLuongTon.Value;
            string? maDM = cboDanhMuc.SelectedValue?.ToString();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maHoa))
            {
                MessageBox.Show("Vui lòng nhập Mã hoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHoa.Focus();
                return;
            }

            if (action != "DELETE")
            {
                if (string.IsNullOrWhiteSpace(tenHoa))
                {
                    MessageBox.Show("Vui lòng nhập Tên hoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenHoa.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(maDM))
                {
                    MessageBox.Show("Vui lòng chọn Danh mục hoa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboDanhMuc.Focus();
                    return;
                }
            }

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();

                    // THỰC THI TRỰC TIẾP STORED PROCEDURE P_ThemSuaXoa_Hoa
                    using (SqlCommand cmd = new SqlCommand("dbo.P_ThemSuaXoa_Hoa", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@MaHoa", maHoa);
                        cmd.Parameters.AddWithValue("@TenHoa", (object)tenHoa ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DonViTinh", (object)dvt ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DonGia", donGia);
                        cmd.Parameters.AddWithValue("@SoLuongTon", tonKho);
                        cmd.Parameters.AddWithValue("@MaDM", (object)maDM ?? DBNull.Value);

                        // Tham số đầu ra @KetQua
                        SqlParameter paramKetQua = new SqlParameter("@KetQua", SqlDbType.NVarChar, 250);
                        paramKetQua.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramKetQua);

                        cmd.ExecuteNonQuery();

                        string ketQua = paramKetQua.Value?.ToString() ?? "Đã xử lý xong.";

                        if (ketQua.StartsWith("Thất bại", StringComparison.OrdinalIgnoreCase) ||
                            ketQua.StartsWith("Lỗi", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show(ketQua, "Kết quả thực thi SP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(ketQua, "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LamMoiForm();
                            TaiDanhSachHoa();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // BẮT LỖI PHÂN QUYỀN DENY DELETE CỦA SQL SERVER (Mã lỗi 229: The DELETE permission was denied...)
                if (ex.Number == 229 || ex.Message.IndexOf("permission was denied", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ex.Message.IndexOf("DENY", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show(
                        "Bạn không có quyền thực hiện thao tác xóa dữ liệu này.\n\n" +
                        "Vui lòng liên hệ Quản trị viên để được cấp quyền.",
                        "Thông báo phân quyền",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Lỗi thực thi SQL Server:\n" + ex.Message,
                        "Lỗi cơ sở dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ứng dụng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GoiStoredProcedureHoa("INSERT");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            GoiStoredProcedureHoa("UPDATE");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHoa = txtMaHoa.Text.Trim();
            if (string.IsNullOrWhiteSpace(maHoa))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã hoa cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa mặt hàng hoa [{maHoa}] không?\n\n" +
                (Session.IsAdmin() ? "• Bạn đang thao tác với quyền ADMIN." : "• Chú ý: Tài khoản USER sẽ bị chặn bởi quyền DENY DELETE của SQL Server!"),
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // Nếu người dùng đang chạy dưới phân quyền User, thử gọi lệnh DELETE trực tiếp
            // hoặc gọi SP để minh họa cơ chế kiểm soát truy cập mức database
            if (!Session.IsAdmin())
            {
                try
                {
                    using (SqlConnection conn = Session.CreateConnection())
                    {
                        conn.Open();
                        // Thực thi lệnh DELETE trực tiếp để kích hoạt lỗi DENY DELETE trên SQL Server
                        string sqlDirectDelete = "DELETE FROM dbo.Hoa WHERE MaHoa = @MaHoa";
                        using (SqlCommand cmd = new SqlCommand(sqlDirectDelete, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHoa", maHoa);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Đã xóa hoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiForm();
                    TaiDanhSachHoa();
                }
                catch (SqlException ex)
                {
                    // BẮT LỖI SqlException VÀ MINH HỌA DENY DELETE
                    MessageBox.Show(
                        "⛔ CẢNH BÁO BẢO MẬT & PHÂN QUYỀN SQL SERVER:\n\n" +
                        $"Tài khoản hiện tại [{Session.TenDangNhap} / Flora_User] " +
                        "bị máy chủ SQL Server TỪ CHỐI QUYỀN XÓA (DENY DELETE) trên bảng [Hoa]!\n\n" +
                        "• Mã lỗi SQL: " + ex.Number + "\n" +
                        "• Thông báo máy chủ: " + ex.Message,
                        "Bảo vệ dữ liệu - Phân quyền DENY DELETE",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
            else
            {
                // Tài khoản Admin gọi Stored Procedure
                GoiStoredProcedureHoa("DELETE");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            TaiDanhSachHoa();
        }

        private void LamMoiForm()
        {
            maHoaDangChon = "";
            txtMaHoa.Clear();
            txtTenHoa.Clear();
            txtDVT.Text = "Bông";
            numDonGia.Value = 0;
            numSoLuongTon.Value = 0;
            cboDanhMuc.SelectedIndex = -1;
            txtTimKiem.Clear();
            txtMaHoa.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maDM = cboLocDanhMuc.SelectedValue?.ToString() ?? "ALL";
            string tuKhoa = txtTimKiem.Text.Trim();
            TaiDanhSachHoa(maDM, tuKhoa);
        }

        private void cboLocDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocDanhMuc.SelectedValue != null)
            {
                string maDM = cboLocDanhMuc.SelectedValue.ToString() ?? "ALL";
                TaiDanhSachHoa(maDM, txtTimKiem.Text.Trim());
            }
        }
    }
}