namespace FloraShop
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        // Header controls
        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblHeaderLogo;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlUserHeader;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblRoleBadge;
        private System.Windows.Forms.Label lblConnectionInfo;

        // Sidebar controls
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblMenuHeader;
        private System.Windows.Forms.Button btnMenuTongQuan;
        private System.Windows.Forms.Button btnMenuHoa;
        private System.Windows.Forms.Button btnMenuLapDon;
        private System.Windows.Forms.Button btnMenuThanhToan;
        private System.Windows.Forms.Button btnMenuDanhMuc;
        private System.Windows.Forms.Button btnMenuKhachHang;
        private System.Windows.Forms.Button btnMenuKhuyenMai;
        private System.Windows.Forms.Button btnMenuNhanVien;
        private System.Windows.Forms.Button btnMenuDangXuat;

        // Main content panel
        private System.Windows.Forms.Panel pnlNoiDung;

        // Overview panel (embedded inside pnlNoiDung)
        private System.Windows.Forms.Panel pnlTongQuan;
        private System.Windows.Forms.TableLayoutPanel tlpKpiCards;
        private System.Windows.Forms.Panel pnlCardDoanhThu;
        private System.Windows.Forms.Label lblKpiDoanhThuVal;
        private System.Windows.Forms.Label lblKpiDoanhThuTitle;
        private System.Windows.Forms.Panel pnlCardDonHang;
        private System.Windows.Forms.Label lblKpiDonHangVal;
        private System.Windows.Forms.Label lblKpiDonHangTitle;
        private System.Windows.Forms.Panel pnlCardKhachHang;
        private System.Windows.Forms.Label lblKpiKhachHangVal;
        private System.Windows.Forms.Label lblKpiKhachHangTitle;
        private System.Windows.Forms.Panel pnlCardHoa;
        private System.Windows.Forms.Label lblKpiHoaVal;
        private System.Windows.Forms.Label lblKpiHoaTitle;

        // Statistics Views section
        private System.Windows.Forms.SplitContainer splitThongKe;
        private System.Windows.Forms.Panel pnlViewDonChuaXuLy;
        private System.Windows.Forms.Label lblTitleDonChuaXuLy;
        private System.Windows.Forms.DataGridView dgvDonChuaXuLy;
        private System.Windows.Forms.Panel pnlViewThongKeTongHop;
        private System.Windows.Forms.Label lblTitleThongKeTongHop;
        private System.Windows.Forms.DataGridView dgvThongKeTongHop;
        private System.Windows.Forms.Button btnLamMoiThongKe;

        // Status strip
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tslNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel tslQuyenHan;
        private System.Windows.Forms.ToolStripStatusLabel tslKetNoi;
        private System.Windows.Forms.ToolStripStatusLabel tslThoiGian;
        private System.Windows.Forms.Timer timerClock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblHeaderLogo = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlUserHeader = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblRoleBadge = new System.Windows.Forms.Label();
            this.lblConnectionInfo = new System.Windows.Forms.Label();

            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblMenuHeader = new System.Windows.Forms.Label();
            this.btnMenuTongQuan = new System.Windows.Forms.Button();
            this.btnMenuHoa = new System.Windows.Forms.Button();
            this.btnMenuLapDon = new System.Windows.Forms.Button();
            this.btnMenuThanhToan = new System.Windows.Forms.Button();
            this.btnMenuDanhMuc = new System.Windows.Forms.Button();
            this.btnMenuKhachHang = new System.Windows.Forms.Button();
            this.btnMenuKhuyenMai = new System.Windows.Forms.Button();
            this.btnMenuNhanVien = new System.Windows.Forms.Button();
            this.btnMenuDangXuat = new System.Windows.Forms.Button();

            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.pnlTongQuan = new System.Windows.Forms.Panel();
            this.tlpKpiCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardDoanhThu = new System.Windows.Forms.Panel();
            this.lblKpiDoanhThuVal = new System.Windows.Forms.Label();
            this.lblKpiDoanhThuTitle = new System.Windows.Forms.Label();
            this.pnlCardDonHang = new System.Windows.Forms.Panel();
            this.lblKpiDonHangVal = new System.Windows.Forms.Label();
            this.lblKpiDonHangTitle = new System.Windows.Forms.Label();
            this.pnlCardKhachHang = new System.Windows.Forms.Panel();
            this.lblKpiKhachHangVal = new System.Windows.Forms.Label();
            this.lblKpiKhachHangTitle = new System.Windows.Forms.Label();
            this.pnlCardHoa = new System.Windows.Forms.Panel();
            this.lblKpiHoaVal = new System.Windows.Forms.Label();
            this.lblKpiHoaTitle = new System.Windows.Forms.Label();

            this.splitThongKe = new System.Windows.Forms.SplitContainer();
            this.pnlViewDonChuaXuLy = new System.Windows.Forms.Panel();
            this.lblTitleDonChuaXuLy = new System.Windows.Forms.Label();
            this.dgvDonChuaXuLy = new System.Windows.Forms.DataGridView();
            this.pnlViewThongKeTongHop = new System.Windows.Forms.Panel();
            this.btnLamMoiThongKe = new System.Windows.Forms.Button();
            this.lblTitleThongKeTongHop = new System.Windows.Forms.Label();
            this.dgvThongKeTongHop = new System.Windows.Forms.DataGridView();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tslNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslQuyenHan = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslKetNoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslThoiGian = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            this.pnlTopHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.pnlTongQuan.SuspendLayout();
            this.tlpKpiCards.SuspendLayout();
            this.pnlCardDoanhThu.SuspendLayout();
            this.pnlCardDonHang.SuspendLayout();
            this.pnlCardKhachHang.SuspendLayout();
            this.pnlCardHoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitThongKe)).BeginInit();
            this.splitThongKe.Panel1.SuspendLayout();
            this.splitThongKe.Panel2.SuspendLayout();
            this.splitThongKe.SuspendLayout();
            this.pnlViewDonChuaXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonChuaXuLy)).BeginInit();
            this.pnlViewThongKeTongHop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeTongHop)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 246, 243);
            this.ClientSize = new System.Drawing.Size(1260, 750);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTopHeader);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloraShop - Hệ Thống Quản Lý Cửa Hàng Điện Hoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDashboard_FormClosed);
            this.Load += new System.EventHandler(this.FrmDashboard_Load);

            // ================= pnlTopHeader =================
            this.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(24, 78, 52);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Height = 65;
            this.pnlTopHeader.Controls.Add(this.lblHeaderLogo);
            this.pnlTopHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlTopHeader.Controls.Add(this.pnlUserHeader);

            // lblHeaderLogo
            this.lblHeaderLogo.AutoSize = true;
            this.lblHeaderLogo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeaderLogo.ForeColor = System.Drawing.Color.FromArgb(245, 215, 120);
            this.lblHeaderLogo.Location = new System.Drawing.Point(15, 8);
            this.lblHeaderLogo.Name = "lblHeaderLogo";
            this.lblHeaderLogo.Size = new System.Drawing.Size(50, 45);
            this.lblHeaderLogo.Text = "❀";

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(68, 17);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(430, 30);
            this.lblHeaderTitle.Text = "FLORASHOP - QUẢN LÝ CỬA HÀNG ĐIỆN HOA";

            // ================= pnlUserHeader (Right docked container) =================
            this.pnlUserHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserHeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUserHeader.Width = 470;
            this.pnlUserHeader.Controls.Add(this.lblRoleBadge);
            this.pnlUserHeader.Controls.Add(this.lblUserInfo);
            this.pnlUserHeader.Controls.Add(this.lblConnectionInfo);

            // lblRoleBadge (Fixed on right side of pnlUserHeader)
            this.lblRoleBadge.BackColor = System.Drawing.Color.FromArgb(235, 195, 85);
            this.lblRoleBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleBadge.ForeColor = System.Drawing.Color.FromArgb(70, 45, 0);
            this.lblRoleBadge.Location = new System.Drawing.Point(350, 10);
            this.lblRoleBadge.Name = "lblRoleBadge";
            this.lblRoleBadge.Size = new System.Drawing.Size(105, 24);
            this.lblRoleBadge.Text = "ADMIN";
            this.lblRoleBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblUserInfo (Left of lblRoleBadge with safe gap)
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUserInfo.ForeColor = System.Drawing.Color.White;
            this.lblUserInfo.Location = new System.Drawing.Point(10, 11);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(335, 22);
            this.lblUserInfo.Text = "Xin chào: Lê Quản Trị";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblConnectionInfo
            this.lblConnectionInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblConnectionInfo.ForeColor = System.Drawing.Color.FromArgb(200, 230, 215);
            this.lblConnectionInfo.Location = new System.Drawing.Point(10, 36);
            this.lblConnectionInfo.Name = "lblConnectionInfo";
            this.lblConnectionInfo.Size = new System.Drawing.Size(445, 20);
            this.lblConnectionInfo.Text = "Chức vụ: Cửa hàng trưởng";
            this.lblConnectionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ================= pnlSidebar =================
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(32, 95, 63);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 220;
            this.pnlSidebar.Controls.Add(this.btnMenuDangXuat);
            this.pnlSidebar.Controls.Add(this.btnMenuNhanVien);
            this.pnlSidebar.Controls.Add(this.btnMenuKhuyenMai);
            this.pnlSidebar.Controls.Add(this.btnMenuKhachHang);
            this.pnlSidebar.Controls.Add(this.btnMenuDanhMuc);
            this.pnlSidebar.Controls.Add(this.btnMenuLapDon);
            this.pnlSidebar.Controls.Add(this.btnMenuThanhToan);
            this.pnlSidebar.Controls.Add(this.btnMenuHoa);
            this.pnlSidebar.Controls.Add(this.btnMenuTongQuan);
            this.pnlSidebar.Controls.Add(this.lblMenuHeader);

            // lblMenuHeader
            this.lblMenuHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMenuHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMenuHeader.ForeColor = System.Drawing.Color.FromArgb(180, 220, 195);
            this.lblMenuHeader.Location = new System.Drawing.Point(0, 0);
            this.lblMenuHeader.Name = "lblMenuHeader";
            this.lblMenuHeader.Padding = new System.Windows.Forms.Padding(15, 12, 0, 5);
            this.lblMenuHeader.Size = new System.Drawing.Size(220, 35);
            this.lblMenuHeader.Text = "DANH MỤC TÁC VỤ";

            // btnMenuTongQuan
            this.btnMenuTongQuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuTongQuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuTongQuan.FlatAppearance.BorderSize = 0;
            this.btnMenuTongQuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTongQuan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnMenuTongQuan.ForeColor = System.Drawing.Color.White;
            this.btnMenuTongQuan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuTongQuan.Location = new System.Drawing.Point(0, 35);
            this.btnMenuTongQuan.Name = "btnMenuTongQuan";
            this.btnMenuTongQuan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuTongQuan.Size = new System.Drawing.Size(220, 48);
            this.btnMenuTongQuan.Text = "📊   Tổng Quan";
            this.btnMenuTongQuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuTongQuan.UseVisualStyleBackColor = true;
            this.btnMenuTongQuan.Click += new System.EventHandler(this.btnMenuTongQuan_Click);

            // btnMenuHoa
            this.btnMenuHoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuHoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuHoa.FlatAppearance.BorderSize = 0;
            this.btnMenuHoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHoa.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMenuHoa.ForeColor = System.Drawing.Color.White;
            this.btnMenuHoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuHoa.Location = new System.Drawing.Point(0, 83);
            this.btnMenuHoa.Name = "btnMenuHoa";
            this.btnMenuHoa.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuHoa.Size = new System.Drawing.Size(220, 48);
            this.btnMenuHoa.Text = "🌸   Quản Lý Hoa";
            this.btnMenuHoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuHoa.UseVisualStyleBackColor = true;
            this.btnMenuHoa.Click += new System.EventHandler(this.btnMenuHoa_Click);

            // btnMenuLapDon
            this.btnMenuLapDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuLapDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuLapDon.FlatAppearance.BorderSize = 0;
            this.btnMenuLapDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLapDon.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMenuLapDon.ForeColor = System.Drawing.Color.White;
            this.btnMenuLapDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuLapDon.Location = new System.Drawing.Point(0, 131);
            this.btnMenuLapDon.Name = "btnMenuLapDon";
            this.btnMenuLapDon.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuLapDon.Size = new System.Drawing.Size(220, 48);
            this.btnMenuLapDon.Text = "🧾   Lập Đơn Hàng";
            this.btnMenuLapDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuLapDon.UseVisualStyleBackColor = true;
            this.btnMenuLapDon.Click += new System.EventHandler(this.btnMenuLapDon_Click);

            // btnMenuThanhToan
            this.btnMenuThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuThanhToan.FlatAppearance.BorderSize = 0;
            this.btnMenuThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMenuThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnMenuThanhToan.Location = new System.Drawing.Point(0, 179);
            this.btnMenuThanhToan.Name = "btnMenuThanhToan";
            this.btnMenuThanhToan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuThanhToan.Size = new System.Drawing.Size(220, 48);
            this.btnMenuThanhToan.Text = "💳   Thanh Toán Hóa Đơn";
            this.btnMenuThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuThanhToan.UseVisualStyleBackColor = true;
            this.btnMenuThanhToan.Click += new System.EventHandler(this.btnMenuThanhToan_Click);

            // btnMenuDanhMuc
            this.btnMenuDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnMenuDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMenuDanhMuc.ForeColor = System.Drawing.Color.White;
            this.btnMenuDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuDanhMuc.Location = new System.Drawing.Point(0, 179);
            this.btnMenuDanhMuc.Name = "btnMenuDanhMuc";
            this.btnMenuDanhMuc.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuDanhMuc.Size = new System.Drawing.Size(220, 48);
            this.btnMenuDanhMuc.Text = "📁   Danh Mục Hoa";
            this.btnMenuDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuDanhMuc.UseVisualStyleBackColor = true;
            this.btnMenuDanhMuc.Click += new System.EventHandler(this.btnMenuDanhMuc_Click);

            // btnMenuKhachHang
            this.btnMenuKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuKhachHang.FlatAppearance.BorderSize = 0;
            this.btnMenuKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMenuKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnMenuKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuKhachHang.Location = new System.Drawing.Point(0, 227);
            this.btnMenuKhachHang.Name = "btnMenuKhachHang";
            this.btnMenuKhachHang.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuKhachHang.Size = new System.Drawing.Size(220, 48);
            this.btnMenuKhachHang.Text = "👥   Khách Hàng";
            this.btnMenuKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuKhachHang.UseVisualStyleBackColor = true;
            this.btnMenuKhachHang.Click += new System.EventHandler(this.btnMenuKhachHang_Click);

            // btnMenuKhuyenMai
            this.btnMenuKhuyenMai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuKhuyenMai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuKhuyenMai.FlatAppearance.BorderSize = 0;
            this.btnMenuKhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMenuKhuyenMai.ForeColor = System.Drawing.Color.White;
            this.btnMenuKhuyenMai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuKhuyenMai.Location = new System.Drawing.Point(0, 275);
            this.btnMenuKhuyenMai.Name = "btnMenuKhuyenMai";
            this.btnMenuKhuyenMai.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuKhuyenMai.Size = new System.Drawing.Size(220, 48);
            this.btnMenuKhuyenMai.Text = "🎁   Khuyến Mãi";
            this.btnMenuKhuyenMai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuKhuyenMai.UseVisualStyleBackColor = true;
            this.btnMenuKhuyenMai.Click += new System.EventHandler(this.btnMenuKhuyenMai_Click);

            // btnMenuNhanVien
            this.btnMenuNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuNhanVien.FlatAppearance.BorderSize = 0;
            this.btnMenuNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuNhanVien.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMenuNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnMenuNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuNhanVien.Location = new System.Drawing.Point(0, 323);
            this.btnMenuNhanVien.Name = "btnMenuNhanVien";
            this.btnMenuNhanVien.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuNhanVien.Size = new System.Drawing.Size(220, 48);
            this.btnMenuNhanVien.Text = "🛡️   Quản Lý Nhân Viên";
            this.btnMenuNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuNhanVien.UseVisualStyleBackColor = true;
            this.btnMenuNhanVien.Click += new System.EventHandler(this.btnMenuNhanVien_Click);

            // btnMenuDangXuat
            this.btnMenuDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMenuDangXuat.FlatAppearance.BorderSize = 0;
            this.btnMenuDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDangXuat.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnMenuDangXuat.ForeColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.btnMenuDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuDangXuat.Location = new System.Drawing.Point(0, 610);
            this.btnMenuDangXuat.Name = "btnMenuDangXuat";
            this.btnMenuDangXuat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuDangXuat.Size = new System.Drawing.Size(220, 48);
            this.btnMenuDangXuat.Text = "🚪   Đăng Xuất";
            this.btnMenuDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuDangXuat.UseVisualStyleBackColor = true;
            this.btnMenuDangXuat.Click += new System.EventHandler(this.btnMenuDangXuat_Click);

            // ================= pnlNoiDung =================
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Controls.Add(this.pnlTongQuan);
            this.pnlNoiDung.Location = new System.Drawing.Point(220, 65);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Size = new System.Drawing.Size(1040, 663);

            // ================= pnlTongQuan =================
            this.pnlTongQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTongQuan.Controls.Add(this.splitThongKe);
            this.pnlTongQuan.Controls.Add(this.tlpKpiCards);
            this.pnlTongQuan.Location = new System.Drawing.Point(0, 0);
            this.pnlTongQuan.Name = "pnlTongQuan";
            this.pnlTongQuan.Padding = new System.Windows.Forms.Padding(15);
            this.pnlTongQuan.Size = new System.Drawing.Size(1040, 663);

            // tlpKpiCards
            this.tlpKpiCards.ColumnCount = 4;
            this.tlpKpiCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpiCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpiCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpiCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpiCards.Controls.Add(this.pnlCardDoanhThu, 0, 0);
            this.tlpKpiCards.Controls.Add(this.pnlCardDonHang, 1, 0);
            this.tlpKpiCards.Controls.Add(this.pnlCardKhachHang, 2, 0);
            this.tlpKpiCards.Controls.Add(this.pnlCardHoa, 3, 0);
            this.tlpKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKpiCards.Location = new System.Drawing.Point(15, 15);
            this.tlpKpiCards.Name = "tlpKpiCards";
            this.tlpKpiCards.RowCount = 1;
            this.tlpKpiCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpiCards.Height = 100;

            // Card 1: Doanh Thu
            this.pnlCardDoanhThu.BackColor = System.Drawing.Color.FromArgb(24, 110, 75);
            this.pnlCardDoanhThu.Controls.Add(this.lblKpiDoanhThuVal);
            this.pnlCardDoanhThu.Controls.Add(this.lblKpiDoanhThuTitle);
            this.pnlCardDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardDoanhThu.Margin = new System.Windows.Forms.Padding(5);
            this.lblKpiDoanhThuTitle.AutoSize = true;
            this.lblKpiDoanhThuTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiDoanhThuTitle.ForeColor = System.Drawing.Color.FromArgb(210, 240, 220);
            this.lblKpiDoanhThuTitle.Location = new System.Drawing.Point(15, 12);
            this.lblKpiDoanhThuTitle.Text = "DOANH THU HOÀN TẤT";
            this.lblKpiDoanhThuVal.AutoSize = true;
            this.lblKpiDoanhThuVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiDoanhThuVal.ForeColor = System.Drawing.Color.White;
            this.lblKpiDoanhThuVal.Location = new System.Drawing.Point(15, 40);
            this.lblKpiDoanhThuVal.Text = "0 đ";

            // Card 2: Đơn Hàng
            this.pnlCardDonHang.BackColor = System.Drawing.Color.FromArgb(35, 130, 160);
            this.pnlCardDonHang.Controls.Add(this.lblKpiDonHangVal);
            this.pnlCardDonHang.Controls.Add(this.lblKpiDonHangTitle);
            this.pnlCardDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardDonHang.Margin = new System.Windows.Forms.Padding(5);
            this.lblKpiDonHangTitle.AutoSize = true;
            this.lblKpiDonHangTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiDonHangTitle.ForeColor = System.Drawing.Color.FromArgb(215, 240, 250);
            this.lblKpiDonHangTitle.Location = new System.Drawing.Point(15, 12);
            this.lblKpiDonHangTitle.Text = "TỔNG ĐƠN HÀNG";
            this.lblKpiDonHangVal.AutoSize = true;
            this.lblKpiDonHangVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiDonHangVal.ForeColor = System.Drawing.Color.White;
            this.lblKpiDonHangVal.Location = new System.Drawing.Point(15, 40);
            this.lblKpiDonHangVal.Text = "0 đơn";

            // Card 3: Khách Hàng
            this.pnlCardKhachHang.BackColor = System.Drawing.Color.FromArgb(170, 105, 45);
            this.pnlCardKhachHang.Controls.Add(this.lblKpiKhachHangVal);
            this.pnlCardKhachHang.Controls.Add(this.lblKpiKhachHangTitle);
            this.pnlCardKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardKhachHang.Margin = new System.Windows.Forms.Padding(5);
            this.lblKpiKhachHangTitle.AutoSize = true;
            this.lblKpiKhachHangTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiKhachHangTitle.ForeColor = System.Drawing.Color.FromArgb(250, 235, 215);
            this.lblKpiKhachHangTitle.Location = new System.Drawing.Point(15, 12);
            this.lblKpiKhachHangTitle.Text = "TỔNG KHÁCH HÀNG";
            this.lblKpiKhachHangVal.AutoSize = true;
            this.lblKpiKhachHangVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiKhachHangVal.ForeColor = System.Drawing.Color.White;
            this.lblKpiKhachHangVal.Location = new System.Drawing.Point(15, 40);
            this.lblKpiKhachHangVal.Text = "0 khách";

            // Card 4: Mặt Hàng Hoa
            this.pnlCardHoa.BackColor = System.Drawing.Color.FromArgb(120, 60, 140);
            this.pnlCardHoa.Controls.Add(this.lblKpiHoaVal);
            this.pnlCardHoa.Controls.Add(this.lblKpiHoaTitle);
            this.pnlCardHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardHoa.Margin = new System.Windows.Forms.Padding(5);
            this.lblKpiHoaTitle.AutoSize = true;
            this.lblKpiHoaTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKpiHoaTitle.ForeColor = System.Drawing.Color.FromArgb(245, 225, 250);
            this.lblKpiHoaTitle.Location = new System.Drawing.Point(15, 12);
            this.lblKpiHoaTitle.Text = "SẢN PHẨM HOA TƯƠI";
            this.lblKpiHoaVal.AutoSize = true;
            this.lblKpiHoaVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKpiHoaVal.ForeColor = System.Drawing.Color.White;
            this.lblKpiHoaVal.Location = new System.Drawing.Point(15, 40);
            this.lblKpiHoaVal.Text = "0 mẫu";

            // ================= splitThongKe (2 Views) =================
            this.splitThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitThongKe.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitThongKe.Location = new System.Drawing.Point(15, 115);
            this.splitThongKe.Name = "splitThongKe";
            this.splitThongKe.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.splitThongKe.Size = new System.Drawing.Size(1010, 533);
            this.splitThongKe.SplitterDistance = 340;

            // Panel View 1: V_DanhSachChuaXuLy
            this.pnlViewDonChuaXuLy.BackColor = System.Drawing.Color.White;
            this.pnlViewDonChuaXuLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewDonChuaXuLy.Controls.Add(this.dgvDonChuaXuLy);
            this.pnlViewDonChuaXuLy.Controls.Add(this.lblTitleDonChuaXuLy);
            this.splitThongKe.Panel1.Controls.Add(this.pnlViewDonChuaXuLy);

            this.lblTitleDonChuaXuLy.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleDonChuaXuLy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleDonChuaXuLy.ForeColor = System.Drawing.Color.FromArgb(30, 80, 55);
            this.lblTitleDonChuaXuLy.Height = 38;
            this.lblTitleDonChuaXuLy.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.lblTitleDonChuaXuLy.Text = "⚡ DANH SÁCH ĐƠN HÀNG CHỜ XỬ LÝ & ĐANG GIAO (Truy vấn View: V_DanhSachChuaXuLy)";

            this.dgvDonChuaXuLy.AllowUserToAddRows = false;
            this.dgvDonChuaXuLy.AllowUserToDeleteRows = false;
            this.dgvDonChuaXuLy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonChuaXuLy.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonChuaXuLy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonChuaXuLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonChuaXuLy.ReadOnly = true;
            this.dgvDonChuaXuLy.RowHeadersVisible = false;
            this.dgvDonChuaXuLy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Panel View 2: V_ThongKeTongHop
            this.pnlViewThongKeTongHop.BackColor = System.Drawing.Color.White;
            this.pnlViewThongKeTongHop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewThongKeTongHop.Controls.Add(this.dgvThongKeTongHop);
            this.pnlViewThongKeTongHop.Controls.Add(this.btnLamMoiThongKe);
            this.pnlViewThongKeTongHop.Controls.Add(this.lblTitleThongKeTongHop);
            this.splitThongKe.Panel2.Controls.Add(this.pnlViewThongKeTongHop);

            this.lblTitleThongKeTongHop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleThongKeTongHop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleThongKeTongHop.ForeColor = System.Drawing.Color.FromArgb(30, 80, 55);
            this.lblTitleThongKeTongHop.Height = 38;
            this.lblTitleThongKeTongHop.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            this.lblTitleThongKeTongHop.Text = "📈 BẢNG CHỈ SỐ THỐNG KÊ TỔNG HỢP TOÀN HỆ THỐNG (Truy vấn View: V_ThongKeTongHop)";

            this.btnLamMoiThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoiThongKe.BackColor = System.Drawing.Color.FromArgb(240, 245, 242);
            this.btnLamMoiThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoiThongKe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 200, 190);
            this.btnLamMoiThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiThongKe.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnLamMoiThongKe.Location = new System.Drawing.Point(880, 5);
            this.btnLamMoiThongKe.Name = "btnLamMoiThongKe";
            this.btnLamMoiThongKe.Size = new System.Drawing.Size(120, 28);
            this.btnLamMoiThongKe.Text = "🔄 Làm mới số liệu";
            this.btnLamMoiThongKe.UseVisualStyleBackColor = false;
            this.btnLamMoiThongKe.Click += new System.EventHandler(this.btnLamMoiThongKe_Click);

            this.dgvThongKeTongHop.AllowUserToAddRows = false;
            this.dgvThongKeTongHop.AllowUserToDeleteRows = false;
            this.dgvThongKeTongHop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKeTongHop.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKeTongHop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThongKeTongHop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKeTongHop.ReadOnly = true;
            this.dgvThongKeTongHop.RowHeadersVisible = false;

            // ================= statusStrip =================
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslNguoiDung,
            this.tslQuyenHan,
            this.tslKetNoi,
            this.tslThoiGian});
            this.statusStrip.Location = new System.Drawing.Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1260, 22);

            this.tslNguoiDung.Name = "tslNguoiDung";
            this.tslNguoiDung.Size = new System.Drawing.Size(150, 17);
            this.tslNguoiDung.Text = "Người dùng: Lê Quản Trị";

            this.tslQuyenHan.Name = "tslQuyenHan";
            this.tslQuyenHan.Size = new System.Drawing.Size(120, 17);
            this.tslQuyenHan.Text = "Vai trò: [ADMIN]";

            this.tslKetNoi.Name = "tslKetNoi";
            this.tslKetNoi.Size = new System.Drawing.Size(300, 17);
            this.tslKetNoi.Text = "Kết nối: SQL Login [Flora_Admin] | DB: FloraShopDB";

            this.tslThoiGian.Name = "tslThoiGian";
            this.tslThoiGian.Size = new System.Drawing.Size(675, 17);
            this.tslThoiGian.Spring = true;
            this.tslThoiGian.Text = "2026-10-27 00:00:00";
            this.tslThoiGian.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // timerClock
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // Finish
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlNoiDung.ResumeLayout(false);
            this.pnlTongQuan.ResumeLayout(false);
            this.tlpKpiCards.ResumeLayout(false);
            this.pnlCardDoanhThu.ResumeLayout(false);
            this.pnlCardDoanhThu.PerformLayout();
            this.pnlCardDonHang.ResumeLayout(false);
            this.pnlCardDonHang.PerformLayout();
            this.pnlCardKhachHang.ResumeLayout(false);
            this.pnlCardKhachHang.PerformLayout();
            this.pnlCardHoa.ResumeLayout(false);
            this.pnlCardHoa.PerformLayout();
            this.splitThongKe.Panel1.ResumeLayout(false);
            this.splitThongKe.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitThongKe)).EndInit();
            this.splitThongKe.ResumeLayout(false);
            this.pnlViewDonChuaXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonChuaXuLy)).EndInit();
            this.pnlViewThongKeTongHop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeTongHop)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
