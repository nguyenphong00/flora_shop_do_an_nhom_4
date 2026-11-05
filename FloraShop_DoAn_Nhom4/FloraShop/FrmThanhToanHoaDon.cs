using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QRCoder;

namespace FloraShop
{
    public partial class FrmThanhToanHoaDon : Form
    {
        // Thay bằng thông tin tài khoản nhận tiền thật của cửa hàng trước khi sử dụng.
        private const string TenNganHang = "Vietcombank";
        private const string SoTaiKhoanNhan = "NHAP_SO_TAI_KHOAN";
        private const string TenChuTaiKhoan = "FLORASHOP";

        private DataTable _donHang = new DataTable();
        private decimal _tongTien = 0m;
        private decimal _giamGia = 0m;
        private bool _dangNapDuLieu = false;

        public FrmThanhToanHoaDon()
        {
            InitializeComponent();
        }

        private void FrmThanhToanHoaDon_Load(object sender, EventArgs e)
        {
            txtNganHang.Text = TenNganHang;
            txtSoTaiKhoan.Text = SoTaiKhoanNhan;
            TaoBangThanhToanNeuChuaCo();
            TaiDanhSachDonHang();
        }

        private void TaoBangThanhToanNeuChuaCo()
        {
            const string sql = @"
IF OBJECT_ID(N'dbo.ThanhToan', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ThanhToan
    (
        MaThanhToan INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        MaDH NVARCHAR(20) NOT NULL UNIQUE,
        SoTien DECIMAL(18,2) NOT NULL,
        PhuongThuc NVARCHAR(30) NOT NULL,
        NgayThanhToan DATETIME NOT NULL DEFAULT GETDATE(),
        TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Đã xác nhận',
        CONSTRAINT FK_ThanhToan_DonHang FOREIGN KEY (MaDH) REFERENCES dbo.DonHang(MaDH)
    );
END";
            using SqlConnection conn = Session.CreateConnection();
            conn.Open();
            using SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        private void TaiDanhSachDonHang()
        {
            try
            {
                _dangNapDuLieu = true;
                using SqlConnection conn = Session.CreateConnection();
                conn.Open();

                const string sql = @"
SELECT dh.MaDH, kh.HoTenKH, nv.HoTenNV, dh.NgayDat, dh.TongTien
FROM dbo.DonHang dh
INNER JOIN dbo.KhachHang kh ON kh.MaKH = dh.MaKH
INNER JOIN dbo.NhanVien nv ON nv.MaNV = dh.MaNV
WHERE dh.TrangThai <> N'Đã hủy'
  AND NOT EXISTS (SELECT 1 FROM dbo.ThanhToan tt WHERE tt.MaDH = dh.MaDH)
ORDER BY dh.NgayDat DESC;";

                using SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                _donHang = new DataTable();
                da.Fill(_donHang);

                cboMaDH.DataSource = null;
                cboMaDH.DisplayMember = "MaDH";
                cboMaDH.ValueMember = "MaDH";
                cboMaDH.DataSource = _donHang;
                cboMaDH.SelectedIndex = _donHang.Rows.Count > 0 ? 0 : -1;

                if (_donHang.Rows.Count == 0)
                {
                    XoaThongTinHoaDon();
                    lblTrangThai.Text = "Hiện không có đơn hàng chưa thanh toán.";
                    TaoQR("FLORASHOP|CHUA_CO_DON_HANG");
                }
                else
                {
                    HienThiHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách đơn hàng.\n" + ex.Message,
                    "FloraShop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        private void cboMaDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dangNapDuLieu && cboMaDH.SelectedIndex >= 0)
                HienThiHoaDon();
        }

        private void HienThiHoaDon()
        {
            if (cboMaDH.SelectedValue == null) return;
            string maDH = cboMaDH.SelectedValue.ToString() ?? "";
            if (maDH.Length == 0) return;

            try
            {
                using SqlConnection conn = Session.CreateConnection();
                conn.Open();

                const string sqlInfo = @"
SELECT dh.MaDH, kh.HoTenKH, nv.HoTenNV, dh.NgayDat, dh.TongTien
FROM dbo.DonHang dh
INNER JOIN dbo.KhachHang kh ON kh.MaKH = dh.MaKH
INNER JOIN dbo.NhanVien nv ON nv.MaNV = dh.MaNV
WHERE dh.MaDH = @MaDH;";
                using SqlCommand cmd = new SqlCommand(sqlInfo, conn);
                cmd.Parameters.AddWithValue("@MaDH", maDH);
                using SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.Read()) return;

                txtKhachHang.Text = Convert.ToString(rd["HoTenKH"]) ?? "";
                txtNhanVien.Text = Convert.ToString(rd["HoTenNV"]) ?? "";
                txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                _tongTien = Convert.ToDecimal(rd["TongTien"]);
                rd.Close();

                const string sqlDetail = @"
SELECT h.TenHoa AS [Tên hoa], c.SoLuong AS [Số lượng],
       c.DonGiaBan AS [Đơn giá],
       (c.SoLuong * c.DonGiaBan) AS [Thành tiền]
FROM dbo.ChiTietDonHang c
INNER JOIN dbo.Hoa h ON h.MaHoa = c.MaHoa
WHERE c.MaDH = @MaDH;";
                using SqlDataAdapter da = new SqlDataAdapter(sqlDetail, conn);
                da.SelectCommand!.Parameters.AddWithValue("@MaDH", maDH);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvChiTiet.DataSource = dt;

                decimal tamTinh = 0m;
                foreach (DataRow row in dt.Rows)
                    tamTinh += Convert.ToDecimal(row["Thành tiền"]);

                _giamGia = Math.Max(0m, tamTinh - _tongTien);
                lblTongValue.Text = tamTinh.ToString("N0") + " đ";
                lblGiamValue.Text = _giamGia.ToString("N0") + " đ";
                lblThanhToanValue.Text = _tongTien.ToString("N0") + " đ";
                lblTrangThai.Text = "Đơn hàng đang chờ thanh toán. Vui lòng kiểm tra thông tin trước khi xác nhận.";

                txtNoiDungCK.Text = "FLORASHOP " + maDH;
                TaoQR(TaoNoiDungQR(maDH, _tongTien));
                DinhDangCotTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin hóa đơn.\n" + ex.Message,
                    "FloraShop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TaoNoiDungQR(string maDH, decimal soTien)
        {
            return "FLORASHOP PAYMENT\n" +
                   "Ngan hang: " + TenNganHang + "\n" +
                   "So tai khoan: " + SoTaiKhoanNhan + "\n" +
                   "Chu tai khoan: " + TenChuTaiKhoan + "\n" +
                   "So tien: " + soTien.ToString("0") + " VND\n" +
                   "Noi dung: FLORASHOP " + maDH;
        }

        private void TaoQR(string noiDung)
        {
            try
            {
                using QRCodeGenerator generator = new QRCodeGenerator();
                using QRCodeData data = generator.CreateQrCode(noiDung, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qr = new PngByteQRCode(data);
                byte[] bytes = qr.GetGraphic(10, new byte[] { 24, 85, 55 }, new byte[] { 255, 255, 255 });
                using MemoryStream ms = new MemoryStream(bytes);
                using Image temp = Image.FromStream(ms);
                picQR.Image?.Dispose();
                picQR.Image = new Bitmap(temp);
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Không tạo được mã QR: " + ex.Message;
            }
        }

        private void DinhDangCotTien()
        {
            foreach (string tenCot in new[] { "Đơn giá", "Thành tiền" })
            {
                if (dgvChiTiet.Columns.Contains(tenCot))
                {
                    dgvChiTiet.Columns[tenCot].DefaultCellStyle.Format = "N0";
                    dgvChiTiet.Columns[tenCot].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            if (dgvChiTiet.Columns.Contains("Số lượng"))
                dgvChiTiet.Columns["Số lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnThanhToanQR_Click(object sender, EventArgs e)
        {
            XacNhanThanhToan("Chuyển khoản QR");
        }

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            XacNhanThanhToan("Tiền mặt");
        }

        private void XacNhanThanhToan(string phuongThuc)
        {
            if (cboMaDH.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần thanh toán.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maDH = cboMaDH.SelectedValue.ToString() ?? "";
            if (maDH.Length == 0 || _tongTien <= 0)
            {
                MessageBox.Show("Thông tin đơn hàng hoặc số tiền thanh toán không hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string noiDung = phuongThuc == "Chuyển khoản QR"
                ? "Bạn đã kiểm tra giao dịch chuyển khoản trong tài khoản ngân hàng và muốn ghi nhận thanh toán?"
                : "Xác nhận đã nhận đủ tiền mặt từ khách hàng?";

            if (MessageBox.Show(noiDung, "Xác nhận thanh toán",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection conn = Session.CreateConnection();
                conn.Open();
                using SqlTransaction tran = conn.BeginTransaction();

                const string sql = @"
INSERT INTO dbo.ThanhToan(MaDH, SoTien, PhuongThuc, TrangThai)
VALUES(@MaDH, @SoTien, @PhuongThuc, N'Đã xác nhận');";
                using SqlCommand cmd = new SqlCommand(sql, conn, tran);
                cmd.Parameters.AddWithValue("@MaDH", maDH);
                cmd.Parameters.AddWithValue("@SoTien", _tongTien);
                cmd.Parameters.AddWithValue("@PhuongThuc", phuongThuc);
                cmd.ExecuteNonQuery();
                tran.Commit();

                MessageBox.Show("Đã ghi nhận thanh toán cho đơn hàng " + maDH + ".",
                    "Thanh toán thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachDonHang();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Đơn hàng này đã được ghi nhận thanh toán trước đó.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TaiDanhSachDonHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể ghi nhận thanh toán.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDanhSachDonHang();
        }

        private void XoaThongTinHoaDon()
        {
            txtKhachHang.Clear();
            txtNhanVien.Clear();
            txtNgay.Clear();
            txtNoiDungCK.Clear();
            dgvChiTiet.DataSource = null;
            lblTongValue.Text = "0 đ";
            lblGiamValue.Text = "0 đ";
            lblThanhToanValue.Text = "0 đ";
            _tongTien = 0m;
            _giamGia = 0m;
        }
    }
}
