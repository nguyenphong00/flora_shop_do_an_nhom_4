
namespace FloraShop
{
    partial class FrmKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaKhachHang;
        private System.Windows.Forms.Label lblTenKhachHang;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTimKiem;

        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvKhachHang;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaKhachHang = new System.Windows.Forms.Label();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();

            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvKhachHang = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Name = "FrmKhachHang";
            this.Text = "Quản lý khách hàng";
            this.Load += new System.EventHandler(this.FrmKhachHang_Load);

            // Tiêu đề
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor =
                System.Drawing.Color.FromArgb(45, 100, 75);
            this.lblTieuDe.Location =
                new System.Drawing.Point(25, 18);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "QUẢN LÝ KHÁCH HÀNG";

            // Mã khách hàng
            this.lblMaKhachHang.AutoSize = true;
            this.lblMaKhachHang.Location =
                new System.Drawing.Point(30, 85);
            this.lblMaKhachHang.Text = "Mã khách hàng:";

            this.txtMaKhachHang.Location =
                new System.Drawing.Point(155, 80);
            this.txtMaKhachHang.Size =
                new System.Drawing.Size(280, 23);
            this.txtMaKhachHang.Name = "txtMaKhachHang";

            // Tên khách hàng
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Location =
                new System.Drawing.Point(30, 125);
            this.lblTenKhachHang.Text = "Tên khách hàng:";

            this.txtTenKhachHang.Location =
                new System.Drawing.Point(155, 120);
            this.txtTenKhachHang.Size =
                new System.Drawing.Size(280, 23);
            this.txtTenKhachHang.Name = "txtTenKhachHang";

            // Số điện thoại
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location =
                new System.Drawing.Point(30, 165);
            this.lblSoDienThoai.Text = "Số điện thoại:";

            this.txtSoDienThoai.Location =
                new System.Drawing.Point(155, 160);
            this.txtSoDienThoai.Size =
                new System.Drawing.Size(280, 23);
            this.txtSoDienThoai.Name = "txtSoDienThoai";

            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location =
                new System.Drawing.Point(500, 85);
            this.lblEmail.Text = "Email:";

            this.txtEmail.Location =
                new System.Drawing.Point(590, 80);
            this.txtEmail.Size =
                new System.Drawing.Size(440, 23);
            this.txtEmail.Name = "txtEmail";

            // Địa chỉ
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location =
                new System.Drawing.Point(500, 125);
            this.lblDiaChi.Text = "Địa chỉ:";

            this.txtDiaChi.Location =
                new System.Drawing.Point(590, 120);
            this.txtDiaChi.Size =
                new System.Drawing.Size(440, 60);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";

            // Nút Thêm
            this.btnThem.Location =
                new System.Drawing.Point(30, 215);
            this.btnThem.Size =
                new System.Drawing.Size(110, 38);
            this.btnThem.Text = "Thêm";
            this.btnThem.Name = "btnThem";
            this.btnThem.BackColor =
                System.Drawing.Color.FromArgb(46, 125, 80);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);

            // Nút Sửa
            this.btnSua.Location =
                new System.Drawing.Point(155, 215);
            this.btnSua.Size =
                new System.Drawing.Size(110, 38);
            this.btnSua.Text = "Sửa";
            this.btnSua.Name = "btnSua";
            this.btnSua.BackColor =
                System.Drawing.Color.FromArgb(45, 110, 160);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            // Nút Xóa
            this.btnXoa.Location =
                new System.Drawing.Point(280, 215);
            this.btnXoa.Size =
                new System.Drawing.Size(110, 38);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.BackColor =
                System.Drawing.Color.FromArgb(190, 65, 65);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Click +=
                new System.EventHandler(this.btnXoa_Click);

            // Nút Làm mới
            this.btnLamMoi.Location =
                new System.Drawing.Point(405, 215);
            this.btnLamMoi.Size =
                new System.Drawing.Size(110, 38);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Click +=
                new System.EventHandler(this.btnLamMoi_Click);

            // Tìm kiếm
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location =
                new System.Drawing.Point(30, 280);
            this.lblTimKiem.Text = "Tìm khách hàng:";

            this.txtTimKiem.Location =
                new System.Drawing.Point(155, 275);
            this.txtTimKiem.Size =
                new System.Drawing.Size(390, 23);
            this.txtTimKiem.Name = "txtTimKiem";

            this.btnTimKiem.Location =
                new System.Drawing.Point(560, 270);
            this.btnTimKiem.Size =
                new System.Drawing.Size(110, 33);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.BackColor =
                System.Drawing.Color.FromArgb(45, 100, 75);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Click +=
                new System.EventHandler(this.btnTimKiem_Click);

            // Bảng danh sách khách hàng
            this.dgvKhachHang.Location =
                new System.Drawing.Point(30, 325);
            this.dgvKhachHang.Size =
                new System.Drawing.Size(1040, 340);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvKhachHang.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKhachHang.RowHeadersVisible = false;
            this.dgvKhachHang.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.MultiSelect = false;
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvKhachHang_CellClick);

            // Thêm các điều khiển vào Form
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaKhachHang);
            this.Controls.Add(this.lblTenKhachHang);
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblTimKiem);

            this.Controls.Add(this.txtMaKhachHang);
            this.Controls.Add(this.txtTenKhachHang);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTimKiem);

            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);

            this.Controls.Add(this.dgvKhachHang);

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
