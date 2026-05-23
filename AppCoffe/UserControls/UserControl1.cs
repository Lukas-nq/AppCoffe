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
    public partial class usCardMonAn : UserControl
    {
        public event EventHandler TheBiBam;
        public string tenMonLuu;
        public decimal giaMonLuu;
        public usCardMonAn()
        {
            InitializeComponent();
            this.Click += usCardMonAn_Click;
            lblTenMon.Click += usCardMonAn_Click;
            lblGiaMon.Click += usCardMonAn_Click;
            picAnhMon.Click += usCardMonAn_Click;
        }    
        public void TruyenDuLieu(string ten, decimal gia, string duongDanAnh)
        {
            tenMonLuu = ten;
            giaMonLuu = gia;

            lblTenMon.Text = ten;
            lblGiaMon.Text = gia.ToString("#,##0") + " VNĐ";
            try
            {
                picAnhMon.Image = Image.FromFile(duongDanAnh);
            }
            catch { }
        }
        private void usCardMonAn_Click(object sender, EventArgs e)
        {
            if (TheBiBam != null)
            {
                TheBiBam(this, e);
            }
        }
    }
}
