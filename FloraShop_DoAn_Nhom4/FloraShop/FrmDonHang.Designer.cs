namespace FloraShop
{
    partial class FrmDonHang
    {
        private System.ComponentModel.IContainer components = null;

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
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Name = "FrmDonHang";
            this.Text = "FloraShop - Lập Đơn Hàng";
            this.Load += new System.EventHandler(this.FrmDonHang_Load);
            this.ResumeLayout(false);
        }
    }
}
