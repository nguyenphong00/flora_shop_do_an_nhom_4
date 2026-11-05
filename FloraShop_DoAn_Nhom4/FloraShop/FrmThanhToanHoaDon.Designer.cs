namespace FloraShop
{
    partial class FrmThanhToanHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader, pnlThongTin, pnlDanhSach, pnlQR, pnlThongTinNH, pnlTongKet, pnlButtons;
        private System.Windows.Forms.Label lblTitle, lblSubTitle, lblMaDH, lblKhachHang, lblNhanVien, lblNgay, lblTong, lblGiam, lblThanhToan, lblQRTitle, lblHuongDan, lblNganHang, lblSoTaiKhoan, lblNoiDungCK, lblTrangThai;
        private System.Windows.Forms.ComboBox cboMaDH;
        private System.Windows.Forms.TextBox txtKhachHang, txtNhanVien, txtNgay, txtNganHang, txtSoTaiKhoan, txtNoiDungCK;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Button btnThanhToanQR, btnTienMat, btnLamMoi;
        private System.Windows.Forms.Label lblTongValue, lblGiamValue, lblThanhToanValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.lblMaDH = new System.Windows.Forms.Label();
            this.cboMaDH = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.txtNgay = new System.Windows.Forms.TextBox();
            this.pnlDanhSach = new System.Windows.Forms.Panel();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.pnlTongKet = new System.Windows.Forms.Panel();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblTongValue = new System.Windows.Forms.Label();
            this.lblGiam = new System.Windows.Forms.Label();
            this.lblGiamValue = new System.Windows.Forms.Label();
            this.lblThanhToan = new System.Windows.Forms.Label();
            this.lblThanhToanValue = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThanhToanQR = new System.Windows.Forms.Button();
            this.btnTienMat = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlQR = new System.Windows.Forms.Panel();
            this.lblQRTitle = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.pnlThongTinNH = new System.Windows.Forms.Panel();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.txtNganHang = new System.Windows.Forms.TextBox();
            this.lblSoTaiKhoan = new System.Windows.Forms.Label();
            this.txtSoTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblNoiDungCK = new System.Windows.Forms.Label();
            this.txtNoiDungCK = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlThongTin.SuspendLayout();
            this.pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlTongKet.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlQR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.pnlThongTinNH.SuspendLayout();
            this.SuspendLayout();
            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 246, 243);
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.MinimumSize = new System.Drawing.Size(1050, 680);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmThanhToanHoaDon";
            this.Text = "FloraShop - Thanh Toán Hóa Đơn";
            this.Load += new System.EventHandler(this.FrmThanhToanHoaDon_Load);

            // Header
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(24, 85, 55);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 76;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 8);
            this.lblTitle.Text = "▣  THANH TOÁN HÓA ĐƠN";
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(220, 240, 225);
            this.lblSubTitle.Location = new System.Drawing.Point(26, 47);
            this.lblSubTitle.Text = "Quản lý thanh toán đơn hàng tại FloraShop";

            // Invoice information
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTin.Location = new System.Drawing.Point(18, 92);
            this.pnlThongTin.Size = new System.Drawing.Size(625, 172);
            this.pnlThongTin.Controls.AddRange(new System.Windows.Forms.Control[] { lblMaDH, cboMaDH, lblKhachHang, txtKhachHang, lblNhanVien, txtNhanVien, lblNgay, txtNgay });
            AddLabel(this.lblMaDH, "Mã hóa đơn / đơn hàng:", 18, 18, 175);
            AddLabel(this.lblKhachHang, "Khách hàng:", 18, 58, 175);
            AddLabel(this.lblNhanVien, "Nhân viên:", 18, 98, 175);
            AddLabel(this.lblNgay, "Ngày thanh toán:", 18, 138, 175);
            AddCombo(this.cboMaDH, 200, 14, 390);
            AddText(this.txtKhachHang, 200, 54, 390);
            AddText(this.txtNhanVien, 200, 94, 390);
            AddText(this.txtNgay, 200, 134, 390);

            // Product detail
            this.pnlDanhSach.BackColor = System.Drawing.Color.White;
            this.pnlDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDanhSach.Location = new System.Drawing.Point(18, 278);
            this.pnlDanhSach.Size = new System.Drawing.Size(625, 245);
            this.pnlDanhSach.Controls.Add(this.dgvChiTiet);
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(24, 85, 55);
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvChiTiet.ColumnHeadersHeight = 38;
            this.dgvChiTiet.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 235, 218);
            this.dgvChiTiet.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // Total summary
            this.pnlTongKet.BackColor = System.Drawing.Color.White;
            this.pnlTongKet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongKet.Location = new System.Drawing.Point(18, 537);
            this.pnlTongKet.Size = new System.Drawing.Size(625, 105);
            this.pnlTongKet.Controls.AddRange(new System.Windows.Forms.Control[] { lblTong, lblTongValue, lblGiam, lblGiamValue, lblThanhToan, lblThanhToanValue });
            AddLabel(this.lblTong, "Tổng tiền:", 300, 8, 120);
            AddLabel(this.lblGiam, "Giảm giá:", 300, 38, 120);
            AddLabel(this.lblThanhToan, "Thành tiền:", 300, 68, 120);
            AddValue(this.lblTongValue, 435, 8, 170);
            AddValue(this.lblGiamValue, 435, 38, 170);
            AddValue(this.lblThanhToanValue, 435, 68, 170);
            this.lblThanhToanValue.ForeColor = System.Drawing.Color.FromArgb(24, 85, 55);
            this.lblThanhToanValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);

            // Buttons
            this.pnlButtons.Location = new System.Drawing.Point(18, 655);
            this.pnlButtons.Size = new System.Drawing.Size(625, 48);
            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnThanhToanQR, btnTienMat, btnLamMoi });
            AddButton(this.btnThanhToanQR, "Thanh toán QR", 0, 0, 190);
            AddButton(this.btnTienMat, "Thanh toán tiền mặt", 202, 0, 205);
            AddButton(this.btnLamMoi, "Làm mới", 419, 0, 190);
            this.btnThanhToanQR.Click += new System.EventHandler(this.btnThanhToanQR_Click);
            this.btnTienMat.Click += new System.EventHandler(this.btnTienMat_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // QR area
            this.pnlQR.BackColor = System.Drawing.Color.White;
            this.pnlQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQR.Location = new System.Drawing.Point(660, 92);
            this.pnlQR.Size = new System.Drawing.Size(500, 611);
            this.pnlQR.Controls.AddRange(new System.Windows.Forms.Control[] { lblQRTitle, lblHuongDan, picQR, pnlThongTinNH, lblTrangThai });
            this.lblQRTitle.BackColor = System.Drawing.Color.FromArgb(24, 85, 55);
            this.lblQRTitle.ForeColor = System.Drawing.Color.White;
            this.lblQRTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQRTitle.Location = new System.Drawing.Point(0, 0);
            this.lblQRTitle.Size = new System.Drawing.Size(498, 48);
            this.lblQRTitle.Text = "▣  THANH TOÁN QUA MÃ QR";
            this.lblQRTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQRTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblHuongDan.AutoSize = false;
            this.lblHuongDan.BackColor = System.Drawing.Color.FromArgb(232, 244, 235);
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(24, 85, 55);
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHuongDan.Location = new System.Drawing.Point(15, 60);
            this.lblHuongDan.Size = new System.Drawing.Size(468, 45);
            this.lblHuongDan.Text = "Quét mã QR bằng ứng dụng ngân hàng để xem thông tin thanh toán";
            this.lblHuongDan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.picQR.BackColor = System.Drawing.Color.White;
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(112, 118);
            this.picQR.Size = new System.Drawing.Size(275, 275);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pnlThongTinNH.BackColor = System.Drawing.Color.FromArgb(238, 247, 240);
            this.pnlThongTinNH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinNH.Location = new System.Drawing.Point(15, 408);
            this.pnlThongTinNH.Size = new System.Drawing.Size(468, 122);
            this.pnlThongTinNH.Controls.AddRange(new System.Windows.Forms.Control[] { lblNganHang, txtNganHang, lblSoTaiKhoan, txtSoTaiKhoan, lblNoiDungCK, txtNoiDungCK });
            AddLabel(this.lblNganHang, "Ngân hàng:", 12, 8, 115);
            AddText(this.txtNganHang, 130, 5, 320);
            AddLabel(this.lblSoTaiKhoan, "Số tài khoản:", 12, 45, 115);
            AddText(this.txtSoTaiKhoan, 130, 42, 320);
            AddLabel(this.lblNoiDungCK, "Nội dung CK:", 12, 82, 115);
            AddText(this.txtNoiDungCK, 130, 79, 320);
            this.lblTrangThai.AutoSize = false;
            this.lblTrangThai.BackColor = System.Drawing.Color.FromArgb(232, 244, 235);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(24, 85, 55);
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrangThai.Location = new System.Drawing.Point(15, 545);
            this.lblTrangThai.Size = new System.Drawing.Size(468, 48);
            this.lblTrangThai.Text = "Mã QR hiển thị nội dung thanh toán. Xác nhận giao dịch sau khi kiểm tra tài khoản ngân hàng.";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlTongKet.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlQR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.pnlThongTinNH.ResumeLayout(false);
            this.ResumeLayout(false);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.pnlDanhSach);
            this.Controls.Add(this.pnlTongKet);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlQR);
        }

        private void AddLabel(System.Windows.Forms.Label label, string text, int x, int y, int width)
        {
            label.AutoSize = false; label.Text = text; label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(width, 28); label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(35, 75, 50);
        }
        private void AddText(System.Windows.Forms.TextBox box, int x, int y, int width)
        {
            box.Location = new System.Drawing.Point(x, y); box.Size = new System.Drawing.Size(width, 29);
            box.ReadOnly = true; box.Font = new System.Drawing.Font("Segoe UI", 10F);
            box.BackColor = System.Drawing.Color.FromArgb(250, 252, 250);
        }
        private void AddCombo(System.Windows.Forms.ComboBox box, int x, int y, int width)
        {
            box.Location = new System.Drawing.Point(x, y); box.Size = new System.Drawing.Size(width, 30);
            box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            box.Font = new System.Drawing.Font("Segoe UI", 10F);
            box.SelectedIndexChanged += new System.EventHandler(this.cboMaDH_SelectedIndexChanged);
        }
        private void AddValue(System.Windows.Forms.Label label, int x, int y, int width)
        {
            label.Location = new System.Drawing.Point(x, y); label.Size = new System.Drawing.Size(width, 27);
            label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(35, 75, 50);
        }
        private void AddButton(System.Windows.Forms.Button button, string text, int x, int y, int width)
        {
            button.Text = text; button.Location = new System.Drawing.Point(x, y); button.Size = new System.Drawing.Size(width, 42);
            button.BackColor = System.Drawing.Color.FromArgb(24, 85, 55); button.ForeColor = System.Drawing.Color.White;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat; button.FlatAppearance.BorderSize = 0;
            button.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            button.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}
