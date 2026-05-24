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
        public string anhMonLuu;
     
        public Image AnhHinh
        {
            get { return picAnhMon.Image; }
            set { picAnhMon.Image = value; }
        }
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
            anhMonLuu = duongDanAnh;

            lblTenMon.Text = ten;
            lblGiaMon.Text = gia.ToString("#,##0") + " VNĐ";
            try
            {
                picAnhMon.Image = Image.FromFile(duongDanAnh);
                picAnhMon.SizeMode = PictureBoxSizeMode.StretchImage; // Tiện tay ép ảnh vừa vặn với khung luôn
            }
            catch (System.Exception ex)
            {
                // Thêm chữ System. là nó hết báo lỗi đỏ ngay
                MessageBox.Show("Món: " + ten + "\nĐang tìm tại: " + duongDanAnh + "\nLỗi thực tế: " + ex.Message);
            }
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
