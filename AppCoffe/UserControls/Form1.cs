using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCoffe.UserControls
{
    public partial class frmPopupTreo : Form
    {

        public string tenMonNhan;
        public decimal giaMonNhan;
        public int soLuongChot;
        public string ghiChuChot;

        public frmPopupTreo()
        {
            InitializeComponent();
        }
        private void frmPopupTreo_Load(object sender, EventArgs e)
        {
            lblMon.Text = tenMonNhan;
            lblGia.Text = giaMonNhan.ToString("#,##0") + " VNĐ";
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            soLuongChot = (int)numSoLuong.Value;
            ghiChuChot = txtGhiChu.Text;

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
    }
}
