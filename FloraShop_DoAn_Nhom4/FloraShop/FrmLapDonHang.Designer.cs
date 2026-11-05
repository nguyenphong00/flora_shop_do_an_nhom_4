namespace FloraShop
{
    partial class FrmLapDonHang
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabLapDon;
        private System.Windows.Forms.TabPage tabDanhSach;

        // Group 1: Main Form (Thông tin đơn hàng)
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Label lblMaDH;
        private System.Windows.Forms.TextBox txtMaDH;
        private System.Windows.Forms.Button btnSinhMaDH;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblNgayDat;
        private System.Windows.Forms.DateTimePicker dtpNgayDat;
        private System.Windows.Forms.Label lblNgayGiao;
        private System.Windows.Forms.DateTimePicker dtpNgayGiao;
        private System.Windows.Forms.Label lblNguoiNhan;
        private System.Windows.Forms.TextBox txtNguoiNhan;
        private System.Windows.Forms.Label lblSDTNhan;
        private System.Windows.Forms.TextBox txtSDTNhan;
        private System.Windows.Forms.Label lblDiaChiGiao;
        private System.Windows.Forms.TextBox txtDiaChiGiao;
        private System.Windows.Forms.Label lblKhuyenMai;
        private System.Windows.Forms.ComboBox cboKhuyenMai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblLoiChuc;
        private System.Windows.Forms.TextBox txtLoiChuc;

        // Group 2: Sub Form (Chi tiết giỏ hoa)
        private System.Windows.Forms.GroupBox grpSub;
        private System.Windows.Forms.Label lblChonHoa;
        private System.Windows.Forms.ComboBox cboChonHoa;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThemVaoLuoi;
        private System.Windows.Forms.Button btnXoaKhoiLuoi;
        private System.Windows.Forms.DataGridView dgvChiTietDonHang;

        // Payment / Transaction Summary Panel
        private System.Windows.Forms.Panel pnlThanhToan;
        private System.Windows.Forms.Label lblLabelTamTinh;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Label lblLabelGiamGia;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblLabelTongThanhToan;
        private System.Windows.Forms.Label lblTongThanhToan;
        private System.Windows.Forms.Button btnLuuDonHang;
        private System.Windows.Forms.Button btnLamMoi;

        // Tab Danh Sách Đơn Hàng
        private System.Windows.Forms.Panel pnlLocDonHang;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnLamMoiDanhSach;
        private System.Windows.Forms.DataGridView dgvDanhSachDonHang;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();

            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabLapDon = new System.Windows.Forms.TabPage();
            this.tabDanhSach = new System.Windows.Forms.TabPage();

            this.grpMain = new System.Windows.Forms.GroupBox();
            this.lblMaDH = new System.Windows.Forms.Label();
            this.txtMaDH = new System.Windows.Forms.TextBox();
            this.btnSinhMaDH = new System.Windows.Forms.Button();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblNgayDat = new System.Windows.Forms.Label();
            this.dtpNgayDat = new System.Windows.Forms.DateTimePicker();
            this.lblNgayGiao = new System.Windows.Forms.Label();
            this.dtpNgayGiao = new System.Windows.Forms.DateTimePicker();
            this.lblNguoiNhan = new System.Windows.Forms.Label();
            this.txtNguoiNhan = new System.Windows.Forms.TextBox();
            this.lblSDTNhan = new System.Windows.Forms.Label();
            this.txtSDTNhan = new System.Windows.Forms.TextBox();
            this.lblDiaChiGiao = new System.Windows.Forms.Label();
            this.txtDiaChiGiao = new System.Windows.Forms.TextBox();
            this.lblKhuyenMai = new System.Windows.Forms.Label();
            this.cboKhuyenMai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblLoiChuc = new System.Windows.Forms.Label();
            this.txtLoiChuc = new System.Windows.Forms.TextBox();

            this.grpSub = new System.Windows.Forms.GroupBox();
            this.lblChonHoa = new System.Windows.Forms.Label();
            this.cboChonHoa = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThemVaoLuoi = new System.Windows.Forms.Button();
            this.btnXoaKhoiLuoi = new System.Windows.Forms.Button();
            this.dgvChiTietDonHang = new System.Windows.Forms.DataGridView();

            this.pnlThanhToan = new System.Windows.Forms.Panel();
            this.lblLabelTamTinh = new System.Windows.Forms.Label();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.lblLabelGiamGia = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.lblLabelTongThanhToan = new System.Windows.Forms.Label();
            this.lblTongThanhToan = new System.Windows.Forms.Label();
            this.btnLuuDonHang = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.pnlLocDonHang = new System.Windows.Forms.Panel();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnLamMoiDanhSach = new System.Windows.Forms.Button();
            this.dgvDanhSachDonHang = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabLapDon.SuspendLayout();
            this.tabDanhSach.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.grpSub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonHang)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            this.pnlLocDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDonHang)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 246, 243);
            this.ClientSize = new System.Drawing.Size(1200, 740);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmLapDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloraShop - Lập Đơn Hàng & Giao Dịch Đồng Bộ (Transaction)";
            this.Load += new System.EventHandler(this.FrmLapDonHang_Load);

            // ================= pnlHeader =================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(24, 85, 55);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 65;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 10);
            this.lblHeaderTitle.Text = "🧾 LẬP ĐƠN HÀNG ĐIỆN HOA";

            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(210, 240, 225);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(22, 38);
            this.lblHeaderSubtitle.Text = "Tạo mới và quản lý chi tiết đơn hàng";

            // ================= tabMain =================
            this.tabMain.Controls.Add(this.tabLapDon);
            this.tabMain.Controls.Add(this.tabDanhSach);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 65);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1200, 675);

            // ================= tabLapDon =================
            this.tabLapDon.BackColor = System.Drawing.Color.FromArgb(245, 248, 245);
            this.tabLapDon.Controls.Add(this.pnlThanhToan);
            this.tabLapDon.Controls.Add(this.grpSub);
            this.tabLapDon.Controls.Add(this.grpMain);
            this.tabLapDon.Location = new System.Drawing.Point(4, 25);
            this.tabLapDon.Name = "tabLapDon";
            this.tabLapDon.Padding = new System.Windows.Forms.Padding(10);
            this.tabLapDon.Size = new System.Drawing.Size(1192, 646);
            this.tabLapDon.Text = "📝 Tạo Đơn Hàng Mới";

            // ================= grpMain (Thông tin đơn hàng) =================
            this.grpMain.Controls.Add(this.lblMaDH);
            this.grpMain.Controls.Add(this.txtMaDH);
            this.grpMain.Controls.Add(this.btnSinhMaDH);
            this.grpMain.Controls.Add(this.lblKhachHang);
            this.grpMain.Controls.Add(this.cboKhachHang);
            this.grpMain.Controls.Add(this.lblNgayDat);
            this.grpMain.Controls.Add(this.dtpNgayDat);
            this.grpMain.Controls.Add(this.lblNgayGiao);
            this.grpMain.Controls.Add(this.dtpNgayGiao);
            this.grpMain.Controls.Add(this.lblNguoiNhan);
            this.grpMain.Controls.Add(this.txtNguoiNhan);
            this.grpMain.Controls.Add(this.lblSDTNhan);
            this.grpMain.Controls.Add(this.txtSDTNhan);
            this.grpMain.Controls.Add(this.lblDiaChiGiao);
            this.grpMain.Controls.Add(this.txtDiaChiGiao);
            this.grpMain.Controls.Add(this.lblKhuyenMai);
            this.grpMain.Controls.Add(this.cboKhuyenMai);
            this.grpMain.Controls.Add(this.lblTrangThai);
            this.grpMain.Controls.Add(this.cboTrangThai);
            this.grpMain.Controls.Add(this.lblLoiChuc);
            this.grpMain.Controls.Add(this.txtLoiChuc);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMain.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpMain.ForeColor = System.Drawing.Color.FromArgb(25, 75, 50);
            this.grpMain.Location = new System.Drawing.Point(10, 10);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(1172, 195);
            this.grpMain.Text = "Thông Tin Đơn Hàng";

            // Row 1
            this.lblMaDH.AutoSize = true;
            this.lblMaDH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaDH.ForeColor = System.Drawing.Color.Black;
            this.lblMaDH.Location = new System.Drawing.Point(15, 25);
            this.lblMaDH.Text = "Mã đơn hàng:";
            this.txtMaDH.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaDH.Location = new System.Drawing.Point(15, 45);
            this.txtMaDH.Size = new System.Drawing.Size(110, 24);

            this.btnSinhMaDH.BackColor = System.Drawing.Color.FromArgb(230, 240, 235);
            this.btnSinhMaDH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSinhMaDH.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(160, 200, 180);
            this.btnSinhMaDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinhMaDH.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnSinhMaDH.ForeColor = System.Drawing.Color.FromArgb(20, 60, 40);
            this.btnSinhMaDH.Location = new System.Drawing.Point(130, 45);
            this.btnSinhMaDH.Size = new System.Drawing.Size(45, 24);
            this.btnSinhMaDH.Text = "🎲 Auto";
            this.btnSinhMaDH.Click += new System.EventHandler(this.btnSinhMaDH_Click);

            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhachHang.ForeColor = System.Drawing.Color.Black;
            this.lblKhachHang.Location = new System.Drawing.Point(190, 25);
            this.lblKhachHang.Text = "Khách hàng người đặt:";
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboKhachHang.Location = new System.Drawing.Point(190, 45);
            this.cboKhachHang.Size = new System.Drawing.Size(260, 24);
            this.cboKhachHang.SelectedIndexChanged += new System.EventHandler(this.cboKhachHang_SelectedIndexChanged);

            this.lblNgayDat.AutoSize = true;
            this.lblNgayDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayDat.ForeColor = System.Drawing.Color.Black;
            this.lblNgayDat.Location = new System.Drawing.Point(465, 25);
            this.lblNgayDat.Text = "Ngày đặt hàng:";
            this.dtpNgayDat.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayDat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDat.Location = new System.Drawing.Point(465, 45);
            this.dtpNgayDat.Size = new System.Drawing.Size(160, 24);

            this.lblNgayGiao.AutoSize = true;
            this.lblNgayGiao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayGiao.ForeColor = System.Drawing.Color.Black;
            this.lblNgayGiao.Location = new System.Drawing.Point(640, 25);
            this.lblNgayGiao.Text = "Ngày hẹn giao (Trigger test):";
            this.dtpNgayGiao.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayGiao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNgayGiao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayGiao.Location = new System.Drawing.Point(640, 45);
            this.dtpNgayGiao.Size = new System.Drawing.Size(160, 24);

            this.lblKhuyenMai.AutoSize = true;
            this.lblKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhuyenMai.ForeColor = System.Drawing.Color.Black;
            this.lblKhuyenMai.Location = new System.Drawing.Point(815, 25);
            this.lblKhuyenMai.Text = "Chương trình khuyến mãi:";
            this.cboKhuyenMai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboKhuyenMai.Location = new System.Drawing.Point(815, 45);
            this.cboKhuyenMai.Size = new System.Drawing.Size(340, 24);
            this.cboKhuyenMai.SelectedIndexChanged += new System.EventHandler(this.cboKhuyenMai_SelectedIndexChanged);

            // Row 2
            this.lblNguoiNhan.AutoSize = true;
            this.lblNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNguoiNhan.ForeColor = System.Drawing.Color.Black;
            this.lblNguoiNhan.Location = new System.Drawing.Point(15, 78);
            this.lblNguoiNhan.Text = "Họ tên người nhận hoa:";
            this.txtNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNguoiNhan.Location = new System.Drawing.Point(15, 98);
            this.txtNguoiNhan.Size = new System.Drawing.Size(220, 24);

            this.lblSDTNhan.AutoSize = true;
            this.lblSDTNhan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSDTNhan.ForeColor = System.Drawing.Color.Black;
            this.lblSDTNhan.Location = new System.Drawing.Point(245, 78);
            this.lblSDTNhan.Text = "SĐT người nhận:";
            this.txtSDTNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSDTNhan.Location = new System.Drawing.Point(245, 98);
            this.txtSDTNhan.Size = new System.Drawing.Size(140, 24);

            this.lblDiaChiGiao.AutoSize = true;
            this.lblDiaChiGiao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiaChiGiao.ForeColor = System.Drawing.Color.Black;
            this.lblDiaChiGiao.Location = new System.Drawing.Point(395, 78);
            this.lblDiaChiGiao.Text = "Địa chỉ giao hoa:";
            this.txtDiaChiGiao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiaChiGiao.Location = new System.Drawing.Point(395, 98);
            this.txtDiaChiGiao.Size = new System.Drawing.Size(405, 24);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.Black;
            this.lblTrangThai.Location = new System.Drawing.Point(815, 78);
            this.lblTrangThai.Text = "Trạng thái đơn:";
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTrangThai.Items.AddRange(new object[] { "Chờ xử lý", "Đang giao", "Hoàn thành", "Đã hủy" });
            this.cboTrangThai.Location = new System.Drawing.Point(815, 98);
            this.cboTrangThai.Size = new System.Drawing.Size(160, 24);

            // Row 3
            this.lblLoiChuc.AutoSize = true;
            this.lblLoiChuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoiChuc.ForeColor = System.Drawing.Color.Black;
            this.lblLoiChuc.Location = new System.Drawing.Point(15, 130);
            this.lblLoiChuc.Text = "Nội dung thiệp chúc mừng:";
            this.txtLoiChuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLoiChuc.Location = new System.Drawing.Point(15, 150);
            this.txtLoiChuc.Size = new System.Drawing.Size(1140, 24);

            // ================= grpSub (Khu vực Sub - Chi tiết giỏ hoa) =================
            this.grpSub.Controls.Add(this.dgvChiTietDonHang);
            this.grpSub.Controls.Add(this.lblChonHoa);
            this.grpSub.Controls.Add(this.cboChonHoa);
            this.grpSub.Controls.Add(this.lblDonGia);
            this.grpSub.Controls.Add(this.txtDonGia);
            this.grpSub.Controls.Add(this.lblTonKho);
            this.grpSub.Controls.Add(this.lblSoLuong);
            this.grpSub.Controls.Add(this.numSoLuong);
            this.grpSub.Controls.Add(this.lblGhiChu);
            this.grpSub.Controls.Add(this.txtGhiChu);
            this.grpSub.Controls.Add(this.btnThemVaoLuoi);
            this.grpSub.Controls.Add(this.btnXoaKhoiLuoi);
            this.grpSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSub.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpSub.ForeColor = System.Drawing.Color.FromArgb(25, 75, 50);
            this.grpSub.Location = new System.Drawing.Point(10, 205);
            this.grpSub.Name = "grpSub";
            this.grpSub.Size = new System.Drawing.Size(1172, 360);
            this.grpSub.Text = "Chi Tiết Giỏ Hoa";

            // Controls on Sub
            this.lblChonHoa.AutoSize = true;
            this.lblChonHoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChonHoa.ForeColor = System.Drawing.Color.Black;
            this.lblChonHoa.Location = new System.Drawing.Point(15, 25);
            this.lblChonHoa.Text = "Chọn hoa tươi:";
            this.cboChonHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChonHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboChonHoa.Location = new System.Drawing.Point(15, 45);
            this.cboChonHoa.Size = new System.Drawing.Size(270, 24);
            this.cboChonHoa.SelectedIndexChanged += new System.EventHandler(this.cboChonHoa_SelectedIndexChanged);

            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGia.ForeColor = System.Drawing.Color.Black;
            this.lblDonGia.Location = new System.Drawing.Point(295, 25);
            this.lblDonGia.Text = "Đơn giá niêm yết:";
            this.txtDonGia.BackColor = System.Drawing.Color.FromArgb(240, 245, 242);
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtDonGia.Location = new System.Drawing.Point(295, 45);
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(130, 24);
            this.txtDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblTonKho.AutoSize = true;
            this.lblTonKho.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblTonKho.ForeColor = System.Drawing.Color.FromArgb(140, 50, 20);
            this.lblTonKho.Location = new System.Drawing.Point(295, 72);
            this.lblTonKho.Text = "Tồn kho: 0";

            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuong.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuong.Location = new System.Drawing.Point(435, 25);
            this.lblSoLuong.Text = "Số lượng mua:";
            this.numSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numSoLuong.Location = new System.Drawing.Point(435, 45);
            this.numSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuong.Size = new System.Drawing.Size(90, 24);
            this.numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGhiChu.ForeColor = System.Drawing.Color.Black;
            this.lblGhiChu.Location = new System.Drawing.Point(535, 25);
            this.lblGhiChu.Text = "Ghi chú cách cắm / phối giấy:";
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGhiChu.Location = new System.Drawing.Point(535, 45);
            this.txtGhiChu.Size = new System.Drawing.Size(320, 24);

            this.btnThemVaoLuoi.BackColor = System.Drawing.Color.FromArgb(34, 112, 74);
            this.btnThemVaoLuoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemVaoLuoi.FlatAppearance.BorderSize = 0;
            this.btnThemVaoLuoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoLuoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemVaoLuoi.ForeColor = System.Drawing.Color.White;
            this.btnThemVaoLuoi.Location = new System.Drawing.Point(865, 42);
            this.btnThemVaoLuoi.Size = new System.Drawing.Size(140, 29);
            this.btnThemVaoLuoi.Text = "➕ Thêm Vào Lưới";
            this.btnThemVaoLuoi.UseVisualStyleBackColor = false;
            this.btnThemVaoLuoi.Click += new System.EventHandler(this.btnThemVaoLuoi_Click);

            this.btnXoaKhoiLuoi.BackColor = System.Drawing.Color.FromArgb(195, 60, 50);
            this.btnXoaKhoiLuoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaKhoiLuoi.FlatAppearance.BorderSize = 0;
            this.btnXoaKhoiLuoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaKhoiLuoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaKhoiLuoi.ForeColor = System.Drawing.Color.White;
            this.btnXoaKhoiLuoi.Location = new System.Drawing.Point(1015, 42);
            this.btnXoaKhoiLuoi.Size = new System.Drawing.Size(140, 29);
            this.btnXoaKhoiLuoi.Text = "🗑️ Xóa Khỏi Lưới";
            this.btnXoaKhoiLuoi.UseVisualStyleBackColor = false;
            this.btnXoaKhoiLuoi.Click += new System.EventHandler(this.btnXoaKhoiLuoi_Click);

            // dgvChiTietDonHang
            this.dgvChiTietDonHang.AllowUserToAddRows = false;
            this.dgvChiTietDonHang.AllowUserToDeleteRows = false;
            this.dgvChiTietDonHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietDonHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietDonHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChiTietDonHang.Location = new System.Drawing.Point(15, 95);
            this.dgvChiTietDonHang.MultiSelect = false;
            this.dgvChiTietDonHang.ReadOnly = true;
            this.dgvChiTietDonHang.RowHeadersVisible = false;
            this.dgvChiTietDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietDonHang.Size = new System.Drawing.Size(1140, 255);

            // ================= pnlThanhToan (Dưới cùng của Tab Lập đơn) =================
            this.pnlThanhToan.BackColor = System.Drawing.Color.FromArgb(235, 242, 238);
            this.pnlThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThanhToan.Controls.Add(this.btnLamMoi);
            this.pnlThanhToan.Controls.Add(this.btnLuuDonHang);
            this.pnlThanhToan.Controls.Add(this.lblTongThanhToan);
            this.pnlThanhToan.Controls.Add(this.lblLabelTongThanhToan);
            this.pnlThanhToan.Controls.Add(this.lblGiamGia);
            this.pnlThanhToan.Controls.Add(this.lblLabelGiamGia);
            this.pnlThanhToan.Controls.Add(this.lblTamTinh);
            this.pnlThanhToan.Controls.Add(this.lblLabelTamTinh);
            this.pnlThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThanhToan.Height = 70;
            this.pnlThanhToan.Location = new System.Drawing.Point(10, 565);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(1172, 70);

            this.lblLabelTamTinh.AutoSize = true;
            this.lblLabelTamTinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLabelTamTinh.ForeColor = System.Drawing.Color.FromArgb(60, 80, 70);
            this.lblLabelTamTinh.Location = new System.Drawing.Point(15, 12);
            this.lblLabelTamTinh.Text = "Tạm tính (Gốc):";
            this.lblTamTinh.AutoSize = true;
            this.lblTamTinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTamTinh.ForeColor = System.Drawing.Color.FromArgb(30, 80, 50);
            this.lblTamTinh.Location = new System.Drawing.Point(15, 33);
            this.lblTamTinh.Text = "0 VNĐ";

            this.lblLabelGiamGia.AutoSize = true;
            this.lblLabelGiamGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLabelGiamGia.ForeColor = System.Drawing.Color.FromArgb(60, 80, 70);
            this.lblLabelGiamGia.Location = new System.Drawing.Point(190, 12);
            this.lblLabelGiamGia.Text = "Khuyến mãi giảm:";
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGiamGia.ForeColor = System.Drawing.Color.FromArgb(180, 60, 20);
            this.lblGiamGia.Location = new System.Drawing.Point(190, 33);
            this.lblGiamGia.Text = "0% (0 VNĐ)";

            this.lblLabelTongThanhToan.AutoSize = true;
            this.lblLabelTongThanhToan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLabelTongThanhToan.ForeColor = System.Drawing.Color.FromArgb(60, 80, 70);
            this.lblLabelTongThanhToan.Location = new System.Drawing.Point(400, 12);
            this.lblLabelTongThanhToan.Text = "TỔNG THANH TOÁN:";
            this.lblTongThanhToan.AutoSize = true;
            this.lblTongThanhToan.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTongThanhToan.ForeColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.lblTongThanhToan.Location = new System.Drawing.Point(400, 30);
            this.lblTongThanhToan.Text = "0 VNĐ";

            this.btnLuuDonHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuDonHang.BackColor = System.Drawing.Color.FromArgb(24, 110, 65);
            this.btnLuuDonHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuDonHang.FlatAppearance.BorderSize = 0;
            this.btnLuuDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuDonHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuuDonHang.ForeColor = System.Drawing.Color.White;
            this.btnLuuDonHang.Location = new System.Drawing.Point(885, 12);
            this.btnLuuDonHang.Name = "btnLuuDonHang";
            this.btnLuuDonHang.Size = new System.Drawing.Size(270, 44);
            this.btnLuuDonHang.Text = "💾 LƯU ĐƠN HÀNG (Transaction)";
            this.btnLuuDonHang.UseVisualStyleBackColor = false;
            this.btnLuuDonHang.Click += new System.EventHandler(this.btnLuuDonHang_Click);

            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(220, 230, 225);
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(170, 195, 180);
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(40, 60, 50);
            this.btnLamMoi.Location = new System.Drawing.Point(740, 15);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 38);
            this.btnLamMoi.Text = "🔄 Làm Mới Đơn";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // ================= tabDanhSach =================
            this.tabDanhSach.BackColor = System.Drawing.Color.FromArgb(245, 248, 245);
            this.tabDanhSach.Controls.Add(this.dgvDanhSachDonHang);
            this.tabDanhSach.Controls.Add(this.pnlLocDonHang);
            this.tabDanhSach.Location = new System.Drawing.Point(4, 25);
            this.tabDanhSach.Name = "tabDanhSach";
            this.tabDanhSach.Padding = new System.Windows.Forms.Padding(10);
            this.tabDanhSach.Size = new System.Drawing.Size(1192, 646);
            this.tabDanhSach.Text = "📑 Danh Sách Tất Cả Đơn Hàng";

            // pnlLocDonHang
            this.pnlLocDonHang.Controls.Add(this.lblLocTrangThai);
            this.pnlLocDonHang.Controls.Add(this.cboLocTrangThai);
            this.pnlLocDonHang.Controls.Add(this.btnLamMoiDanhSach);
            this.pnlLocDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLocDonHang.Height = 50;
            this.pnlLocDonHang.Location = new System.Drawing.Point(10, 10);

            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Location = new System.Drawing.Point(10, 15);
            this.lblLocTrangThai.Text = "Lọc theo trạng thái:";

            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Items.AddRange(new object[] { "Tất cả trạng thái", "Chờ xử lý", "Đang giao", "Hoàn thành", "Đã hủy" });
            this.cboLocTrangThai.Location = new System.Drawing.Point(135, 12);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(180, 24);
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);

            this.btnLamMoiDanhSach.Location = new System.Drawing.Point(330, 10);
            this.btnLamMoiDanhSach.Name = "btnLamMoiDanhSach";
            this.btnLamMoiDanhSach.Size = new System.Drawing.Size(120, 28);
            this.btnLamMoiDanhSach.Text = "🔄 Làm mới";
            this.btnLamMoiDanhSach.Click += new System.EventHandler(this.btnLamMoiDanhSach_Click);

            // dgvDanhSachDonHang
            this.dgvDanhSachDonHang.AllowUserToAddRows = false;
            this.dgvDanhSachDonHang.AllowUserToDeleteRows = false;
            this.dgvDanhSachDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachDonHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachDonHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDanhSachDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachDonHang.MultiSelect = false;
            this.dgvDanhSachDonHang.ReadOnly = true;
            this.dgvDanhSachDonHang.RowHeadersVisible = false;
            this.dgvDanhSachDonHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Finish
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabLapDon.ResumeLayout(false);
            this.tabDanhSach.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.grpSub.ResumeLayout(false);
            this.grpSub.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonHang)).EndInit();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            this.pnlLocDonHang.ResumeLayout(false);
            this.pnlLocDonHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDonHang)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
