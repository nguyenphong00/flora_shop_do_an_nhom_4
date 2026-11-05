
namespace FloraShop
{
    partial class FrmKhuyenMai
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaKM;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.Label lblPhanTramGiam;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTimKiem;

        private System.Windows.Forms.TextBox txtMaKM;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.TextBox txtPhanTramGiam;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvKhuyenMai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaKM = new System.Windows.Forms.Label();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.lblPhanTramGiam = new System.Windows.Forms.Label();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();

            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.txtPhanTramGiam = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.SuspendLayout();

            // Tiêu đề
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTieuDe.Location = new System.Drawing.Point(300, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(300, 32);
            this.lblTieuDe.Text = "QUẢN LÝ KHUYẾN MÃI";

            // Mã khuyến mãi
            this.lblMaKM.AutoSize = true;
            this.lblMaKM.Location = new System.Drawing.Point(25, 70);
            this.lblMaKM.Text = "Mã khuyến mãi:";

            this.txtMaKM.Location = new System.Drawing.Point(145, 67);
            this.txtMaKM.Name = "txtMaKM";
            this.txtMaKM.Size = new System.Drawing.Size(230, 23);

            // Tên khuyến mãi
            this.lblTenKM.AutoSize = true;
            this.lblTenKM.Location = new System.Drawing.Point(25, 110);
            this.lblTenKM.Text = "Tên khuyến mãi:";

            this.txtTenKM.Location = new System.Drawing.Point(145, 107);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(230, 23);

            // Phần trăm giảm
            this.lblPhanTramGiam.AutoSize = true;
            this.lblPhanTramGiam.Location = new System.Drawing.Point(25, 150);
            this.lblPhanTramGiam.Text = "Giảm giá (%):";

            this.txtPhanTramGiam.Location = new System.Drawing.Point(145, 147);
            this.txtPhanTramGiam.Name = "txtPhanTramGiam";
            this.txtPhanTramGiam.Size = new System.Drawing.Size(230, 23);

            // Ngày bắt đầu
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Location = new System.Drawing.Point(420, 70);
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";

            this.dtpNgayBatDau.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(530, 67);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(220, 23);

            // Ngày kết thúc
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Location = new System.Drawing.Point(420, 110);
            this.lblNgayKetThuc.Text = "Ngày kết thúc:";

            this.dtpNgayKetThuc.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(530, 107);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(220, 23);

            // Điều kiện tối thiểu
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(420, 150);
            this.lblMoTa.Text = "ĐK tối thiểu (đ):";

            this.txtMoTa.Location = new System.Drawing.Point(530, 147);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(220, 23);

            // Nút thêm
            this.btnThem.Location = new System.Drawing.Point(25, 220);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);

            // Nút sửa
            this.btnSua.Location = new System.Drawing.Point(140, 220);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            // Nút xóa
            this.btnXoa.Location = new System.Drawing.Point(255, 220);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click +=
                new System.EventHandler(this.btnXoa_Click);

            // Nút làm mới
            this.btnLamMoi.Location = new System.Drawing.Point(370, 220);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 35);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click +=
                new System.EventHandler(this.btnLamMoi_Click);

            // Tìm kiếm
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(25, 280);
            this.lblTimKiem.Text = "Tìm kiếm:";

            this.txtTimKiem.Location = new System.Drawing.Point(100, 277);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 23);
            this.txtTimKiem.KeyDown +=
                new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);

            this.btnTimKiem.Location = new System.Drawing.Point(415, 273);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 32);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click +=
                new System.EventHandler(this.btnTimKiem_Click);

            // Bảng khuyến mãi
            this.dgvKhuyenMai.AllowUserToAddRows = false;
            this.dgvKhuyenMai.AllowUserToDeleteRows = false;
            this.dgvKhuyenMai.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuyenMai.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Location = new System.Drawing.Point(25, 325);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.ReadOnly = true;
            this.dgvKhuyenMai.RowHeadersWidth = 51;
            this.dgvKhuyenMai.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhuyenMai.MultiSelect = false;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(900, 270);
            this.dgvKhuyenMai.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvKhuyenMai_CellClick);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(960, 620);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaKM);
            this.Controls.Add(this.lblTenKM);
            this.Controls.Add(this.lblPhanTramGiam);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.lblNgayKetThuc);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblTimKiem);

            this.Controls.Add(this.txtMaKM);
            this.Controls.Add(this.txtTenKM);
            this.Controls.Add(this.txtPhanTramGiam);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtTimKiem);

            this.Controls.Add(this.dtpNgayBatDau);
            this.Controls.Add(this.dtpNgayKetThuc);

            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgvKhuyenMai);

            this.Name = "FrmKhuyenMai";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khuyến mãi";

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
