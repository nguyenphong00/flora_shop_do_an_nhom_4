namespace FloraShop
{
    partial class FrmQuanLyHoa
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaHoa;
        private System.Windows.Forms.TextBox txtMaHoa;
        private System.Windows.Forms.Label lblTenHoa;
        private System.Windows.Forms.TextBox txtTenHoa;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.NumericUpDown numSoLuongTon;

        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblLocDanhMuc;
        private System.Windows.Forms.ComboBox cboLocDanhMuc;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.DataGridView dgvHoa;

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

            this.pnlControls = new System.Windows.Forms.Panel();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaHoa = new System.Windows.Forms.Label();
            this.txtMaHoa = new System.Windows.Forms.TextBox();
            this.lblTenHoa = new System.Windows.Forms.Label();
            this.txtTenHoa = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.numSoLuongTon = new System.Windows.Forms.NumericUpDown();

            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblLocDanhMuc = new System.Windows.Forms.Label();
            this.cboLocDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.dgvHoa = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).BeginInit();
            this.grpChucNang.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoa)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 246, 243);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmQuanLyHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloraShop - Quản Lý Sản Phẩm Hoa Tươi";
            this.Load += new System.EventHandler(this.FrmQuanLyHoa_Load);

            // ================= pnlHeader =================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(32, 95, 63);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 10);
            this.lblHeaderTitle.Text = "🌸 QUẢN LÝ DANH MỤC HOA TƯƠI";

            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(210, 235, 220);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(22, 40);
            this.lblHeaderSubtitle.Text = "Quản lý thông tin và số lượng tồn kho các mặt hàng hoa tươi";

            // ================= pnlControls =================
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Height = 230;
            this.pnlControls.Padding = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.pnlControls.Controls.Add(this.grpThongTin);
            this.pnlControls.Controls.Add(this.grpChucNang);
            this.pnlControls.Controls.Add(this.grpTimKiem);

            // ================= grpThongTin =================
            this.grpThongTin.Controls.Add(this.lblMaHoa);
            this.grpThongTin.Controls.Add(this.txtMaHoa);
            this.grpThongTin.Controls.Add(this.lblTenHoa);
            this.grpThongTin.Controls.Add(this.txtTenHoa);
            this.grpThongTin.Controls.Add(this.lblDVT);
            this.grpThongTin.Controls.Add(this.txtDVT);
            this.grpThongTin.Controls.Add(this.lblDanhMuc);
            this.grpThongTin.Controls.Add(this.cboDanhMuc);
            this.grpThongTin.Controls.Add(this.lblDonGia);
            this.grpThongTin.Controls.Add(this.numDonGia);
            this.grpThongTin.Controls.Add(this.lblSoLuongTon);
            this.grpThongTin.Controls.Add(this.numSoLuongTon);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.ForeColor = System.Drawing.Color.FromArgb(30, 80, 50);
            this.grpThongTin.Location = new System.Drawing.Point(15, 10);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(650, 140);
            this.grpThongTin.Text = "Thông Tin Chi Tiết Mặt Hàng Hoa";

            // Row 1
            this.lblMaHoa.AutoSize = true;
            this.lblMaHoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaHoa.ForeColor = System.Drawing.Color.Black;
            this.lblMaHoa.Location = new System.Drawing.Point(15, 28);
            this.lblMaHoa.Text = "Mã hoa:";
            this.txtMaHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaHoa.Location = new System.Drawing.Point(15, 48);
            this.txtMaHoa.Size = new System.Drawing.Size(100, 24);

            this.lblTenHoa.AutoSize = true;
            this.lblTenHoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenHoa.ForeColor = System.Drawing.Color.Black;
            this.lblTenHoa.Location = new System.Drawing.Point(130, 28);
            this.lblTenHoa.Text = "Tên mặt hàng hoa:";
            this.txtTenHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTenHoa.Location = new System.Drawing.Point(130, 48);
            this.txtTenHoa.Size = new System.Drawing.Size(260, 24);

            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.lblDanhMuc.Location = new System.Drawing.Point(405, 28);
            this.lblDanhMuc.Text = "Danh mục hoa:";
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDanhMuc.Location = new System.Drawing.Point(405, 48);
            this.cboDanhMuc.Size = new System.Drawing.Size(230, 24);

            // Row 2
            this.lblDVT.AutoSize = true;
            this.lblDVT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDVT.ForeColor = System.Drawing.Color.Black;
            this.lblDVT.Location = new System.Drawing.Point(15, 80);
            this.lblDVT.Text = "Đơn vị tính:";
            this.txtDVT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDVT.Location = new System.Drawing.Point(15, 100);
            this.txtDVT.Size = new System.Drawing.Size(100, 24);
            this.txtDVT.Text = "Bông";

            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGia.ForeColor = System.Drawing.Color.Black;
            this.lblDonGia.Location = new System.Drawing.Point(130, 80);
            this.lblDonGia.Text = "Đơn giá (VNĐ):";
            this.numDonGia.DecimalPlaces = 0;
            this.numDonGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numDonGia.Increment = new decimal(new int[] { 5000, 0, 0, 0 });
            this.numDonGia.Location = new System.Drawing.Point(130, 100);
            this.numDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numDonGia.Size = new System.Drawing.Size(150, 24);
            this.numDonGia.ThousandsSeparator = true;

            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoLuongTon.ForeColor = System.Drawing.Color.Black;
            this.lblSoLuongTon.Location = new System.Drawing.Point(295, 80);
            this.lblSoLuongTon.Text = "Số lượng tồn kho:";
            this.numSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numSoLuongTon.Location = new System.Drawing.Point(295, 100);
            this.numSoLuongTon.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numSoLuongTon.Size = new System.Drawing.Size(120, 24);
            this.numSoLuongTon.ThousandsSeparator = true;

            // ================= grpTimKiem =================
            this.grpTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTimKiem.Controls.Add(this.lblLocDanhMuc);
            this.grpTimKiem.Controls.Add(this.cboLocDanhMuc);
            this.grpTimKiem.Controls.Add(this.lblTuKhoa);
            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpTimKiem.ForeColor = System.Drawing.Color.FromArgb(30, 80, 50);
            this.grpTimKiem.Location = new System.Drawing.Point(675, 10);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(410, 140);
            this.grpTimKiem.Text = "Lọc & Tra Cứu Sản Phẩm";

            this.lblLocDanhMuc.AutoSize = true;
            this.lblLocDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.lblLocDanhMuc.Location = new System.Drawing.Point(15, 28);
            this.lblLocDanhMuc.Text = "Lọc theo danh mục:";
            this.cboLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLocDanhMuc.Location = new System.Drawing.Point(15, 48);
            this.cboLocDanhMuc.Size = new System.Drawing.Size(380, 24);
            this.cboLocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboLocDanhMuc_SelectedIndexChanged);

            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTuKhoa.ForeColor = System.Drawing.Color.Black;
            this.lblTuKhoa.Location = new System.Drawing.Point(15, 80);
            this.lblTuKhoa.Text = "Nhập mã hoặc tên hoa:";
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(15, 100);
            this.txtTimKiem.Size = new System.Drawing.Size(260, 24);

            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(40, 110, 75);
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(285, 98);
            this.btnTimKiem.Size = new System.Drawing.Size(110, 28);
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // ================= grpChucNang =================
            this.grpChucNang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChucNang.Controls.Add(this.btnThem);
            this.grpChucNang.Controls.Add(this.btnSua);
            this.grpChucNang.Controls.Add(this.btnXoa);
            this.grpChucNang.Controls.Add(this.btnLamMoi);
            this.grpChucNang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpChucNang.ForeColor = System.Drawing.Color.FromArgb(30, 80, 50);
            this.grpChucNang.Location = new System.Drawing.Point(15, 155);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(1070, 65);
            this.grpChucNang.Text = "Thao Tác Nghiệp Vụ";

            // Buttons
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(34, 112, 74);
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(15, 23);
            this.btnThem.Size = new System.Drawing.Size(130, 32);
            this.btnThem.Text = "➕ Thêm Hoa";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.BackColor = System.Drawing.Color.FromArgb(200, 130, 30);
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(155, 23);
            this.btnSua.Size = new System.Drawing.Size(130, 32);
            this.btnSua.Text = "✏️ Cập Nhật";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(190, 50, 45);
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(295, 23);
            this.btnXoa.Size = new System.Drawing.Size(170, 32);
            this.btnXoa.Text = "🗑️ Xóa Mặt Hàng";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(230, 238, 232);
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(170, 195, 180);
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(40, 60, 50);
            this.btnLamMoi.Location = new System.Drawing.Point(475, 23);
            this.btnLamMoi.Size = new System.Drawing.Size(130, 32);
            this.btnLamMoi.Text = "🔄 Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // ================= pnlGrid =================
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.pnlGrid.Controls.Add(this.dgvHoa);
            this.pnlGrid.Controls.Add(this.lblGridTitle);

            this.lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(30, 80, 50);
            this.lblGridTitle.Height = 30;
            this.lblGridTitle.Text = "📋 DANH SÁCH MẶT HÀNG HOA TƯƠI ĐANG KINH DOANH";

            this.dgvHoa.AllowUserToAddRows = false;
            this.dgvHoa.AllowUserToDeleteRows = false;
            this.dgvHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoa.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoa.MultiSelect = false;
            this.dgvHoa.ReadOnly = true;
            this.dgvHoa.RowHeadersVisible = false;
            this.dgvHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoa_CellClick);

            // Finish
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).EndInit();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpChucNang.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoa)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
