using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();

            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            LoadThongKe();
        }

        // Kiểm tra khoảng ngày
        private bool KiemTraNgay()
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Tải toàn bộ thống kê
        private void LoadThongKe()
        {
            if (!KiemTraNgay())
                return;

            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();

                    DateTime tuNgay = dtpTuNgay.Value.Date;
                    DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

                    // 1. Tổng số đơn hàng và doanh thu trong khoảng ngày
                    string sqlDonHang = @"
                        SELECT
                            COUNT(*) AS TongDonHang,
                            ISNULL(SUM(TongTien), 0) AS TongDoanhThu
                        FROM DonHang
                        WHERE NgayDat >= @TuNgay
                          AND NgayDat < @DenNgay";

                    using (SqlCommand cmd = new SqlCommand(sqlDonHang, conn))
                    {
                        cmd.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = denNgay;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTongDonHang.Text =
                                    Convert.ToInt32(reader["TongDonHang"]).ToString("N0");

                                decimal doanhThu = Convert.ToDecimal(reader["TongDoanhThu"]);
                                lblTongDoanhThu.Text = doanhThu.ToString("N0") + " VNĐ";
                            }
                        }
                    }

                    // 2. Tổng số nhân viên
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM NhanVien", conn))
                    {
                        lblTongNhanVien.Text =
                            Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
                    }

                    // 3. Tổng số khách hàng
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM KhachHang", conn))
                    {
                        lblTongKhachHang.Text =
                            Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
                    }

                    // 4. Thống kê doanh thu theo ngày
                    string sqlDoanhThuNgay = @"
                        SELECT
                            CAST(NgayDat AS DATE) AS Ngay,
                            COUNT(*) AS SoDonHang,
                            ISNULL(SUM(TongTien), 0) AS DoanhThu
                        FROM DonHang
                        WHERE NgayDat >= @TuNgay
                          AND NgayDat < @DenNgay
                        GROUP BY CAST(NgayDat AS DATE)
                        ORDER BY CAST(NgayDat AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(sqlDoanhThuNgay, conn))
                    {
                        cmd.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = denNgay;

                        DataTable dt = new DataTable();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dgvDoanhThu.DataSource = dt;
                    }

                    // 5. Các sản phẩm hoa bán chạy
                    string sqlHoaBanChay = @"
                        SELECT TOP 10
                            h.MaHoa,
                            h.TenHoa,
                            ISNULL(SUM(ct.SoLuong), 0) AS TongSoLuongBan,
                            ISNULL(SUM(ct.SoLuong * ct.DonGiaBan), 0) AS TongTienBan
                        FROM ChiTietDonHang ct
                        INNER JOIN DonHang dh
                            ON ct.MaDH = dh.MaDH
                        INNER JOIN Hoa h
                            ON ct.MaHoa = h.MaHoa
                        WHERE dh.NgayDat >= @TuNgay
                          AND dh.NgayDat < @DenNgay
                        GROUP BY h.MaHoa, h.TenHoa
                        ORDER BY SUM(ct.SoLuong) DESC";

                    using (SqlCommand cmd = new SqlCommand(sqlHoaBanChay, conn))
                    {
                        cmd.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = tuNgay;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = denNgay;

                        DataTable dt = new DataTable();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dgvHoaBanChay.DataSource = dt;
                    }

                    DinhDangBang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thống kê.\n"
                    + "Hãy kiểm tra database và tên các cột trong bảng.\n\n"
                    + ex.Message,
                    "Lỗi thống kê",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Định dạng các bảng dữ liệu
        private void DinhDangBang()
        {
            if (dgvDoanhThu.Columns.Contains("Ngay"))
            {
                dgvDoanhThu.Columns["Ngay"].HeaderText = "Ngày";
                dgvDoanhThu.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvDoanhThu.Columns.Contains("SoDonHang"))
                dgvDoanhThu.Columns["SoDonHang"].HeaderText = "Số đơn hàng";

            if (dgvDoanhThu.Columns.Contains("DoanhThu"))
            {
                dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh thu";
                dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            }

            if (dgvHoaBanChay.Columns.Contains("MaHoa"))
                dgvHoaBanChay.Columns["MaHoa"].HeaderText = "Mã hoa";

            if (dgvHoaBanChay.Columns.Contains("TenHoa"))
                dgvHoaBanChay.Columns["TenHoa"].HeaderText = "Tên hoa";

            if (dgvHoaBanChay.Columns.Contains("TongSoLuongBan"))
                dgvHoaBanChay.Columns["TongSoLuongBan"].HeaderText = "Số lượng bán";

            if (dgvHoaBanChay.Columns.Contains("TongTienBan"))
            {
                dgvHoaBanChay.Columns["TongTienBan"].HeaderText = "Tổng tiền bán";
                dgvHoaBanChay.Columns["TongTienBan"].DefaultCellStyle.Format = "N0";
            }
        }

        // Nút thống kê
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        // Nút làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(
                DateTime.Today.Year, DateTime.Today.Month, 1);

            dtpDenNgay.Value = DateTime.Today;

            LoadThongKe();
        }
    }
}
