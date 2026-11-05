
namespace FloraShop
{
    partial class FrmDanhMucHoa
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhuDe;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Label lblMaDM;
        private System.Windows.Forms.Label lblTenDM;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Label lblDanhSach;
        private System.Windows.Forms.TextBox txtMaDM;
        private System.Windows.Forms.TextBox txtTenDM;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvDanhMuc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhuDe = new System.Windows.Forms.Label();

            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.lblMaDM = new System.Windows.Forms.Label();
            this.lblTenDM = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMaDM = new System.Windows.Forms.TextBox();
            this.txtTenDM = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.lblDanhSach = new System.Windows.Forms.Label();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlThongTin.SuspendLayout();
            this.pnlTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 243);
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmDanhMucHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloraShop - Danh mục hoa";
            this.Load += new System.EventHandler(this.FrmDanhMucHoa_Load);

            // HEADER
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(39, 83, 56);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 95;
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblPhuDe);

            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(25, 10);
            this.lblTieuDe.Text = "❀ DANH MỤC HOA";

            this.lblPhuDe.AutoSize = true;
            this.lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhuDe.ForeColor =
                System.Drawing.Color.FromArgb(225, 240, 227);
            this.lblPhuDe.Location = new System.Drawing.Point(30, 60);
            this.lblPhuDe.Text =
                "Quản lý và phân loại các sản phẩm hoa tại FloraShop";

            // PANEL THÔNG TIN
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.Location = new System.Drawing.Point(20, 115);
            this.pnlThongTin.Size = new System.Drawing.Size(650, 300);
            this.pnlThongTin.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left;

            this.pnlThongTin.Controls.Add(this.lblThongTin);
            this.pnlThongTin.Controls.Add(this.lblMaDM);
            this.pnlThongTin.Controls.Add(this.lblTenDM);
            this.pnlThongTin.Controls.Add(this.lblMoTa);
            this.pnlThongTin.Controls.Add(this.txtMaDM);
            this.pnlThongTin.Controls.Add(this.txtTenDM);
            this.pnlThongTin.Controls.Add(this.txtMoTa);
            this.pnlThongTin.Controls.Add(this.btnThem);
            this.pnlThongTin.Controls.Add(this.btnSua);
            this.pnlThongTin.Controls.Add(this.btnXoa);
            this.pnlThongTin.Controls.Add(this.btnLamMoi);

            this.lblThongTin.AutoSize = true;
            this.lblThongTin.Font = new System.Drawing.Font(
                "Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblThongTin.ForeColor =
                System.Drawing.Color.FromArgb(39, 83, 56);
            this.lblThongTin.Location = new System.Drawing.Point(20, 15);
            this.lblThongTin.Text = "THÔNG TIN DANH MỤC";

            TaoNhan(this.lblMaDM, "Mã danh mục", 25, 65);
            TaoNhan(this.lblTenDM, "Tên danh mục", 330, 65);
            TaoNhan(this.lblMoTa, "Mô tả danh mục", 25, 125);

            TaoTextBox(this.txtMaDM, 25, 90, 270);
            TaoTextBox(this.txtTenDM, 330, 90, 290);

            this.txtMoTa.Location = new System.Drawing.Point(25, 150);
            this.txtMoTa.Size = new System.Drawing.Size(595, 65);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.MaxLength = 500;
            this.txtMoTa.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            // BUTTON THÊM
            TaoNut(this.btnThem, "THÊM", 25, 235,
                System.Drawing.Color.FromArgb(57, 124, 84));

            // BUTTON SỬA
            TaoNut(this.btnSua, "SỬA", 180, 235,
                System.Drawing.Color.FromArgb(204, 153, 55));

            // BUTTON XÓA
            TaoNut(this.btnXoa, "XÓA", 335, 235,
                System.Drawing.Color.FromArgb(190, 75, 83));

            // BUTTON LÀM MỚI
            TaoNut(this.btnLamMoi, "LÀM MỚI", 490, 235,
                System.Drawing.Color.FromArgb(90, 116, 137));

            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click +=
                new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click +=
                new System.EventHandler(this.btnLamMoi_Click);

            // PANEL TÌM KIẾM
            this.pnlTimKiem.BackColor = System.Drawing.Color.White;
            this.pnlTimKiem.Location = new System.Drawing.Point(690, 115);
            this.pnlTimKiem.Size = new System.Drawing.Size(390, 300);
            this.pnlTimKiem.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.pnlTimKiem.Controls.Add(this.lblTimKiem);
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Controls.Add(this.btnTimKiem);

            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font(
                "Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor =
                System.Drawing.Color.FromArgb(39, 83, 56);
            this.lblTimKiem.Location = new System.Drawing.Point(20, 15);
            this.lblTimKiem.Text = "TÌM KIẾM DANH MỤC";

            this.txtTimKiem.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location =
                new System.Drawing.Point(20, 75);
            this.txtTimKiem.Size =
                new System.Drawing.Size(350, 27);
            this.txtTimKiem.PlaceholderText =
                "Nhập mã hoặc tên danh mục...";

            TaoNut(this.btnTimKiem, "TÌM KIẾM", 20, 125,
                System.Drawing.Color.FromArgb(57, 124, 84));
            this.btnTimKiem.Size = new System.Drawing.Size(350, 42);
            this.btnTimKiem.Click +=
                new System.EventHandler(this.btnTimKiem_Click);

            // TIÊU ĐỀ DANH SÁCH
            this.lblDanhSach.AutoSize = true;
            this.lblDanhSach.Font = new System.Drawing.Font(
                "Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblDanhSach.ForeColor =
                System.Drawing.Color.FromArgb(39, 83, 56);
            this.lblDanhSach.Location = new System.Drawing.Point(20, 430);
            this.lblDanhSach.Text = "DANH SÁCH DANH MỤC HOA";

            // DATAGRIDVIEW
            this.dgvDanhMuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhMuc.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvDanhMuc.Location = new System.Drawing.Point(20, 470);
            this.dgvDanhMuc.Size = new System.Drawing.Size(1060, 225);
            this.dgvDanhMuc.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.dgvDanhMuc.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.AllowUserToAddRows = false;
            this.dgvDanhMuc.AllowUserToDeleteRows = false;
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.MultiSelect = false;
            this.dgvDanhMuc.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.RowTemplate.Height = 35;
            this.dgvDanhMuc.ColumnHeadersHeight = 40;
            this.dgvDanhMuc.EnableHeadersVisualStyles = false;

            this.dgvDanhMuc.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(57, 124, 84);
            this.dgvDanhMuc.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvDanhMuc.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            this.dgvDanhMuc.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDanhMuc.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(242, 247, 241);

            this.dgvDanhMuc.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvDanhMuc_CellClick);

            // ADD CONTROLS
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.pnlTimKiem);
            this.Controls.Add(this.lblDanhSach);
            this.Controls.Add(this.dgvDanhMuc);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvDanhMuc)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void TaoNhan(
            System.Windows.Forms.Label lbl,
            string noiDung, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor =
                System.Drawing.Color.FromArgb(55, 75, 60);
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Text = noiDung;
        }

        private void TaoTextBox(
            System.Windows.Forms.TextBox txt,
            int x, int y, int width)
        {
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size = new System.Drawing.Size(width, 27);
        }

        private void TaoNut(
            System.Windows.Forms.Button btn,
            string noiDung, int x, int y,
            System.Drawing.Color mau)
        {
            btn.BackColor = mau;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(135, 38);
            btn.Text = noiDung;
            btn.UseVisualStyleBackColor = false;
        }
    }
}
