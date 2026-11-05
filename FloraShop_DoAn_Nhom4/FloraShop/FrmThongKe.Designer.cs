
namespace FloraShop
{
    partial class FrmThongKe
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;

        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;

        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.GroupBox grpDonHang;
        private System.Windows.Forms.GroupBox grpDoanhThu;
        private System.Windows.Forms.GroupBox grpNhanVien;
        private System.Windows.Forms.GroupBox grpKhachHang;

        private System.Windows.Forms.Label lblTongDonHang;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblTongNhanVien;
        private System.Windows.Forms.Label lblTongKhachHang;

        private System.Windows.Forms.GroupBox grpBangDoanhThu;
        private System.Windows.Forms.GroupBox grpBangHoaBanChay;

        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.DataGridView dgvHoaBanChay;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();

            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();

            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.grpDonHang = new System.Windows.Forms.GroupBox();
            this.grpDoanhThu = new System.Windows.Forms.GroupBox();
            this.grpNhanVien = new System.Windows.Forms.GroupBox();
            this.grpKhachHang = new System.Windows.Forms.GroupBox();

            this.lblTongDonHang = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTongNhanVien = new System.Windows.Forms.Label();
            this.lblTongKhachHang = new System.Windows.Forms.Label();

            this.grpBangDoanhThu = new System.Windows.Forms.GroupBox();
            this.grpBangHoaBanChay = new System.Windows.Forms.GroupBox();

            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.dgvHoaBanChay = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaBanChay)).BeginInit();

            this.grpDonHang.SuspendLayout();
            this.grpDoanhThu.SuspendLayout();
            this.grpNhanVien.SuspendLayout();
            this.grpKhachHang.SuspendLayout();
            this.grpBangDoanhThu.SuspendLayout();
            this.grpBangHoaBanChay.SuspendLayout();
            this.SuspendLayout();

            // Tiêu đề
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTieuDe.Location = new System.Drawing.Point(340, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "THỐNG KÊ CỬA HÀNG HOA";

            // Ngày bắt đầu
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(25, 75);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Text = "Từ ngày:";

            this.dtpTuNgay.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(90, 70);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 23);

            // Ngày kết thúc
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(270, 75);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Text = "Đến ngày:";

            this.dtpDenNgay.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(345, 70);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 23);

            // Nút thống kê
            this.btnThongKe.Location = new System.Drawing.Point(525, 65);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(110, 35);
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click +=
                new System.EventHandler(this.btnThongKe_Click);

            // Nút làm mới
            this.btnLamMoi.Location = new System.Drawing.Point(650, 65);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 35);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click +=
                new System.EventHandler(this.btnLamMoi_Click);

            // Tổng đơn hàng
            this.grpDonHang.Location = new System.Drawing.Point(25, 120);
            this.grpDonHang.Name = "grpDonHang";
            this.grpDonHang.Size = new System.Drawing.Size(235, 90);
            this.grpDonHang.Text = "Tổng đơn hàng";
            this.grpDonHang.Controls.Add(this.lblTongDonHang);

            this.lblTongDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongDonHang.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongDonHang.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTongDonHang.Text = "0";
            this.lblTongDonHang.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // Tổng doanh thu
            this.grpDoanhThu.Location = new System.Drawing.Point(280, 120);
            this.grpDoanhThu.Name = "grpDoanhThu";
            this.grpDoanhThu.Size = new System.Drawing.Size(280, 90);
            this.grpDoanhThu.Text = "Tổng doanh thu";
            this.grpDoanhThu.Controls.Add(this.lblTongDoanhThu);

            this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongDoanhThu.Font = new System.Drawing.Font(
                "Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTongDoanhThu.Text = "0 VNĐ";
            this.lblTongDoanhThu.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // Tổng nhân viên
            this.grpNhanVien.Location = new System.Drawing.Point(580, 120);
            this.grpNhanVien.Name = "grpNhanVien";
            this.grpNhanVien.Size = new System.Drawing.Size(235, 90);
            this.grpNhanVien.Text = "Tổng nhân viên";
            this.grpNhanVien.Controls.Add(this.lblTongNhanVien);

            this.lblTongNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongNhanVien.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongNhanVien.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTongNhanVien.Text = "0";
            this.lblTongNhanVien.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // Tổng khách hàng
            this.grpKhachHang.Location = new System.Drawing.Point(835, 120);
            this.grpKhachHang.Name = "grpKhachHang";
            this.grpKhachHang.Size = new System.Drawing.Size(235, 90);
            this.grpKhachHang.Text = "Tổng khách hàng";
            this.grpKhachHang.Controls.Add(this.lblTongKhachHang);

            this.lblTongKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongKhachHang.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongKhachHang.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblTongKhachHang.Text = "0";
            this.lblTongKhachHang.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // Bảng doanh thu theo ngày
            this.grpBangDoanhThu.Location = new System.Drawing.Point(25, 230);
            this.grpBangDoanhThu.Name = "grpBangDoanhThu";
            this.grpBangDoanhThu.Size = new System.Drawing.Size(510, 400);
            this.grpBangDoanhThu.Text = "DOANH THU THEO NGÀY";
            this.grpBangDoanhThu.Controls.Add(this.dgvDoanhThu);

            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu.MultiSelect = false;
            this.dgvDoanhThu.RowHeadersVisible = false;

            // Bảng hoa bán chạy
            this.grpBangHoaBanChay.Location = new System.Drawing.Point(555, 230);
            this.grpBangHoaBanChay.Name = "grpBangHoaBanChay";
            this.grpBangHoaBanChay.Size = new System.Drawing.Size(515, 400);
            this.grpBangHoaBanChay.Text = "TOP 10 HOA BÁN CHẠY";
            this.grpBangHoaBanChay.Controls.Add(this.dgvHoaBanChay);

            this.dgvHoaBanChay.AllowUserToAddRows = false;
            this.dgvHoaBanChay.AllowUserToDeleteRows = false;
            this.dgvHoaBanChay.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaBanChay.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaBanChay.ReadOnly = true;
            this.dgvHoaBanChay.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaBanChay.MultiSelect = false;
            this.dgvHoaBanChay.RowHeadersVisible = false;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 660);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnLamMoi);

            this.Controls.Add(this.grpDonHang);
            this.Controls.Add(this.grpDoanhThu);
            this.Controls.Add(this.grpNhanVien);
            this.Controls.Add(this.grpKhachHang);

            this.Controls.Add(this.grpBangDoanhThu);
            this.Controls.Add(this.grpBangHoaBanChay);

            this.Name = "FrmThongKe";
            this.Text = "Thống kê FloraShop";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.grpDonHang.ResumeLayout(false);
            this.grpDoanhThu.ResumeLayout(false);
            this.grpNhanVien.ResumeLayout(false);
            this.grpKhachHang.ResumeLayout(false);
            this.grpBangDoanhThu.ResumeLayout(false);
            this.grpBangHoaBanChay.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaBanChay)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
