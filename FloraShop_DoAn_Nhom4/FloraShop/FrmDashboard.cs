using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FloraShop
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            CapNhatThongTinPhanQuyen();
            TaiDuLieuThongKeViews();
            timerClock.Start();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            tslThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Hiển thị thông tin người dùng đang đăng nhập và thiết lập phân quyền menu
        /// </summary>
        public void CapNhatThongTinPhanQuyen()
        {
            lblUserInfo.Text = $"Xin chào: {Session.HoTenNV}";

            bool laAdmin = Session.IsAdmin();

            if (laAdmin)
            {
                lblRoleBadge.Text = "ADMIN";
                lblRoleBadge.BackColor = Color.FromArgb(235, 195, 85);
                lblRoleBadge.ForeColor = Color.FromArgb(70, 45, 0);

                tslQuyenHan.Text = "Vai trò: Quản trị viên";
                tslQuyenHan.ForeColor = Color.DarkGreen;

                btnMenuNhanVien.Visible = true;
                btnMenuNhanVien.Enabled = true;
            }
            else
            {
                lblRoleBadge.Text = "NHÂN VIÊN";
                lblRoleBadge.BackColor = Color.FromArgb(170, 215, 240);
                lblRoleBadge.ForeColor = Color.FromArgb(10, 50, 80);

                tslQuyenHan.Text = "Vai trò: Nhân viên bán hàng";
                tslQuyenHan.ForeColor = Color.DarkBlue;

                btnMenuNhanVien.Visible = false;
                btnMenuNhanVien.Enabled = false;
            }

            tslNguoiDung.Text = $"Người dùng: {Session.HoTenNV}";
            lblConnectionInfo.Text = $"Chức vụ: {Session.ChucVu}";
            tslKetNoi.Text = "Hệ thống: Sẵn sàng";
        }

        /// <summary>
        /// Tải dữ liệu trực tiếp từ 2 View SQL Server: V_DanhSachChuaXuLy và V_ThongKeTongHop
        /// </summary>
        public void TaiDuLieuThongKeViews()
        {
            try
            {
                using (SqlConnection conn = Session.CreateConnection())
                {
                    conn.Open();

                    // 1. Tải bảng chỉ số tổng hợp từ View: V_ThongKeTongHop
                    string sqlThongKe = "SELECT * FROM V_ThongKeTongHop";
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlThongKe, conn))
                    {
                        DataTable dtThongKe = new DataTable();
                        da.Fill(dtThongKe);
                        dgvThongKeTongHop.DataSource = dtThongKe;

                        if (dtThongKe.Rows.Count > 0)
                        {
                            DataRow row = dtThongKe.Rows[0];

                            decimal doanhThu = row["Doanh Thu Hoàn Tất"] != DBNull.Value 
                                ? Convert.ToDecimal(row["Doanh Thu Hoàn Tất"]) : 0;
                            int tongDon = row["Tổng Đơn Hàng"] != DBNull.Value 
                                ? Convert.ToInt32(row["Tổng Đơn Hàng"]) : 0;
                            int donCho = row["Đơn Chờ Xử Lý"] != DBNull.Value 
                                ? Convert.ToInt32(row["Đơn Chờ Xử Lý"]) : 0;
                            int tongKhach = row["Tổng Khách Hàng"] != DBNull.Value 
                                ? Convert.ToInt32(row["Tổng Khách Hàng"]) : 0;
                            int tongHoa = row["Tổng Mặt Hàng Hoa"] != DBNull.Value 
                                ? Convert.ToInt32(row["Tổng Mặt Hàng Hoa"]) : 0;

                            lblKpiDoanhThuVal.Text = string.Format("{0:N0} đ", doanhThu);
                            lblKpiDonHangVal.Text = $"{tongDon} đơn ({donCho} chờ)";
                            lblKpiKhachHangVal.Text = $"{tongKhach} khách";
                            lblKpiHoaVal.Text = $"{tongHoa} mẫu hoa";
                        }
                    }

                    // 2. Tải bảng danh sách đơn hàng cần xử lý từ View: V_DanhSachChuaXuLy
                    string sqlChuaXuLy = "SELECT * FROM V_DanhSachChuaXuLy";
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlChuaXuLy, conn))
                    {
                        DataTable dtChuaXuLy = new DataTable();
                        da.Fill(dtChuaXuLy);
                        dgvDonChuaXuLy.DataSource = dtChuaXuLy;

                        // Định dạng cột tiền tệ nếu có
                        if (dgvDonChuaXuLy.Columns.Contains("Tổng Tiền (VNĐ)"))
                        {
                            dgvDonChuaXuLy.Columns["Tổng Tiền (VNĐ)"].DefaultCellStyle.Format = "N0";
                            dgvDonChuaXuLy.Columns["Tổng Tiền (VNĐ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải số liệu thống kê từ Views SQL Server!\n" + ex.Message,
                    "Thông báo thống kê",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Hiển thị Form con lồng ghép bên trong panel nội dung
        /// </summary>
        private void MoFormTrongPanel(Form formCon)
        {
            // Đóng các control/form cũ đang mở
            foreach (Control ctrl in pnlNoiDung.Controls)
            {
                if (ctrl != pnlTongQuan && ctrl is Form f)
                {
                    f.Close();
                    f.Dispose();
                }
            }

            pnlTongQuan.Visible = false;
            pnlNoiDung.Controls.Clear();

            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            pnlNoiDung.Controls.Add(formCon);
            formCon.Show();
            formCon.BringToFront();
        }

        private void btnMenuTongQuan_Click(object sender, EventArgs e)
        {
            // Đóng Form con nếu có
            foreach (Control ctrl in pnlNoiDung.Controls)
            {
                if (ctrl != pnlTongQuan && ctrl is Form f)
                {
                    f.Close();
                    f.Dispose();
                }
            }

            pnlNoiDung.Controls.Clear();
            pnlNoiDung.Controls.Add(pnlTongQuan);
            pnlTongQuan.Visible = true;
            pnlTongQuan.BringToFront();

            TaiDuLieuThongKeViews();
        }

        private void btnMenuHoa_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmQuanLyHoa());
        }

        private void btnMenuLapDon_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmLapDonHang());
        }

        private void btnMenuThanhToan_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmThanhToanHoaDon());
        }

        private void btnMenuDanhMuc_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmDanhMucHoa());
        }

        private void btnMenuKhachHang_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmKhachHang());
        }

        private void btnMenuKhuyenMai_Click(object sender, EventArgs e)
        {
            MoFormTrongPanel(new FrmKhuyenMai());
        }

        private void btnMenuNhanVien_Click(object sender, EventArgs e)
        {
            if (!Session.IsAdmin())
            {
                MessageBox.Show(
                    "Bạn không có quyền quản trị (Admin) để truy cập phân hệ Quản lý Nhân viên!",
                    "Phân quyền hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            MoFormTrongPanel(new FrmNhanVien());
        }

        private void btnLamMoiThongKe_Click(object sender, EventArgs e)
        {
            TaiDuLieuThongKeViews();
        }

        private void btnMenuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi hệ thống FloraShop không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                timerClock.Stop();
                Session.Clear();

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();

                this.Hide();
                frmLogin.FormClosed += (s, args) => this.Close();
            }
        }

        private void FrmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
