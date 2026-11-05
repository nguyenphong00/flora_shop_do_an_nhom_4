
namespace FloraShop
{
    partial class FrmNhanVien
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblTimKiem;

        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboVaiTro;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvNhanVien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe      = new System.Windows.Forms.Label();
            this.lblMa          = new System.Windows.Forms.Label();
            this.lblTen         = new System.Windows.Forms.Label();
            this.lblSDT         = new System.Windows.Forms.Label();
            this.lblEmail       = new System.Windows.Forms.Label();
            this.lblDiaChi      = new System.Windows.Forms.Label();
            this.lblChucVu      = new System.Windows.Forms.Label();
            this.lblLuong       = new System.Windows.Forms.Label();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblMatKhau     = new System.Windows.Forms.Label();
            this.lblVaiTro      = new System.Windows.Forms.Label();
            this.lblTimKiem     = new System.Windows.Forms.Label();

            this.txtMaNhanVien  = new System.Windows.Forms.TextBox();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtEmail       = new System.Windows.Forms.TextBox();
            this.txtDiaChi      = new System.Windows.Forms.TextBox();
            this.txtChucVu      = new System.Windows.Forms.TextBox();
            this.txtLuong       = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau     = new System.Windows.Forms.TextBox();
            this.txtTimKiem     = new System.Windows.Forms.TextBox();
            this.cboVaiTro      = new System.Windows.Forms.ComboBox();

            this.btnThem    = new System.Windows.Forms.Button();
            this.btnSua     = new System.Windows.Forms.Button();
            this.btnXoa     = new System.Windows.Forms.Button();
            this.btnLamMoi  = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvNhanVien = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            // ── Tiêu đề ──────────────────────────────────────────────
            this.lblTieuDe.AutoSize  = true;
            this.lblTieuDe.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.lblTieuDe.Location  = new System.Drawing.Point(260, 12);
            this.lblTieuDe.Text      = "👤 QUẢN LÝ NHÂN VIÊN";

            // ── Cột trái ─────────────────────────────────────────────
            // Mã NV
            this.lblMa.AutoSize  = true;
            this.lblMa.Location  = new System.Drawing.Point(15, 62);
            this.lblMa.Text      = "Mã nhân viên *:";
            this.txtMaNhanVien.Location = new System.Drawing.Point(145, 59);
            this.txtMaNhanVien.Name     = "txtMaNhanVien";
            this.txtMaNhanVien.Size     = new System.Drawing.Size(180, 23);

            // Tên NV
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(15, 100);
            this.lblTen.Text     = "Tên nhân viên *:";
            this.txtTenNhanVien.Location = new System.Drawing.Point(145, 97);
            this.txtTenNhanVien.Name     = "txtTenNhanVien";
            this.txtTenNhanVien.Size     = new System.Drawing.Size(180, 23);

            // SĐT
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(15, 138);
            this.lblSDT.Text     = "Số điện thoại:";
            this.txtSoDienThoai.Location = new System.Drawing.Point(145, 135);
            this.txtSoDienThoai.Name     = "txtSoDienThoai";
            this.txtSoDienThoai.Size     = new System.Drawing.Size(180, 23);

            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 176);
            this.lblEmail.Text     = "Email:";
            this.txtEmail.Location = new System.Drawing.Point(145, 173);
            this.txtEmail.Name     = "txtEmail";
            this.txtEmail.Size     = new System.Drawing.Size(180, 23);

            // Địa chỉ
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 214);
            this.lblDiaChi.Text     = "Địa chỉ:";
            this.txtDiaChi.Location = new System.Drawing.Point(145, 211);
            this.txtDiaChi.Name     = "txtDiaChi";
            this.txtDiaChi.Size     = new System.Drawing.Size(180, 23);

            // ── Cột phải ─────────────────────────────────────────────
            // Chức vụ
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new System.Drawing.Point(365, 62);
            this.lblChucVu.Text     = "Chức vụ:";
            this.txtChucVu.Location = new System.Drawing.Point(470, 59);
            this.txtChucVu.Name     = "txtChucVu";
            this.txtChucVu.Size     = new System.Drawing.Size(200, 23);

            // Lương
            this.lblLuong.AutoSize = true;
            this.lblLuong.Location = new System.Drawing.Point(365, 100);
            this.lblLuong.Text     = "Lương (VNĐ) *:";
            this.txtLuong.Location = new System.Drawing.Point(470, 97);
            this.txtLuong.Name     = "txtLuong";
            this.txtLuong.Size     = new System.Drawing.Size(200, 23);

            // Tên đăng nhập
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(365, 138);
            this.lblTenDangNhap.Text     = "Tên đăng nhập *:";
            this.txtTenDangNhap.Location = new System.Drawing.Point(470, 135);
            this.txtTenDangNhap.Name     = "txtTenDangNhap";
            this.txtTenDangNhap.Size     = new System.Drawing.Size(200, 23);

            // Mật khẩu
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(365, 176);
            this.lblMatKhau.Text     = "Mật khẩu *:";
            this.txtMatKhau.Location  = new System.Drawing.Point(470, 173);
            this.txtMatKhau.Name      = "txtMatKhau";
            this.txtMatKhau.Size      = new System.Drawing.Size(200, 23);
            this.txtMatKhau.UseSystemPasswordChar = true;

            // Vai trò
            this.lblVaiTro.AutoSize = true;
            this.lblVaiTro.Location = new System.Drawing.Point(365, 214);
            this.lblVaiTro.Text     = "Vai trò:";
            this.cboVaiTro.Location     = new System.Drawing.Point(470, 211);
            this.cboVaiTro.Name         = "cboVaiTro";
            this.cboVaiTro.Size         = new System.Drawing.Size(200, 23);
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // ── Nút chức năng ─────────────────────────────────────────
            this.btnThem.Location = new System.Drawing.Point(15, 252);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 33);
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(115, 252);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 33);
            this.btnSua.Text = "✏ Sửa";
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(215, 252);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 33);
            this.btnXoa.Text = "🗑 Xóa";
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(315, 252);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 33);
            this.btnLamMoi.Text = "🔄 Mới";
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // ── Tìm kiếm ─────────────────────────────────────────────
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(15, 305);
            this.lblTimKiem.Text     = "🔍 Tìm kiếm:";

            this.txtTimKiem.Location = new System.Drawing.Point(105, 302);
            this.txtTimKiem.Name     = "txtTimKiem";
            this.txtTimKiem.Size     = new System.Drawing.Size(280, 23);
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);

            this.btnTimKiem.Location = new System.Drawing.Point(400, 298);
            this.btnTimKiem.Name     = "btnTimKiem";
            this.btnTimKiem.Size     = new System.Drawing.Size(100, 31);
            this.btnTimKiem.Text     = "Tìm kiếm";
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // ── DataGridView ─────────────────────────────────────────
            this.dgvNhanVien.AllowUserToAddRows    = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor        = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location        = new System.Drawing.Point(15, 345);
            this.dgvNhanVien.Name            = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly        = true;
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.SelectionMode   = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.MultiSelect     = false;
            this.dgvNhanVien.Size            = new System.Drawing.Size(950, 280);
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);

            // ── Form ─────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.WhiteSmoke;
            this.ClientSize          = new System.Drawing.Size(990, 645);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMa);        this.Controls.Add(this.txtMaNhanVien);
            this.Controls.Add(this.lblTen);       this.Controls.Add(this.txtTenNhanVien);
            this.Controls.Add(this.lblSDT);       this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.lblEmail);     this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblDiaChi);    this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblChucVu);    this.Controls.Add(this.txtChucVu);
            this.Controls.Add(this.lblLuong);     this.Controls.Add(this.txtLuong);
            this.Controls.Add(this.lblTenDangNhap);this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblMatKhau);   this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblVaiTro);    this.Controls.Add(this.cboVaiTro);
            this.Controls.Add(this.lblTimKiem);   this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgvNhanVien);

            this.Name          = "FrmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Quản lý nhân viên - FloraShop";

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
