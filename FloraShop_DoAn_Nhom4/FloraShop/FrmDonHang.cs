using System;
using System.Windows.Forms;

namespace FloraShop
{
    public partial class FrmDonHang : Form
    {
        public FrmDonHang()
        {
            InitializeComponent();
        }

        private void FrmDonHang_Load(object sender, EventArgs e)
        {
            // Nhúng trực tiếp FrmLapDonHang vào form
            FrmLapDonHang frm = new FrmLapDonHang();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.Controls.Add(frm);
            frm.Show();
        }
    }
}
