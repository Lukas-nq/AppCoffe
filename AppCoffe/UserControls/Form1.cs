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
        public string duongDanAnhNhan;

        public frmPopupTreo()
        {
            InitializeComponent();
        }

        private void frmPopupTreo_Load(object sender, EventArgs e)
        {
            lblMon.Text = tenMonNhan;
            lblGia.Text = giaMonNhan.ToString("#,##0") + " VNĐ";
            if (!string.IsNullOrEmpty(duongDanAnhNhan) && System.IO.File.Exists(duongDanAnhNhan))
            {
                picAnhMon.Image = Image.FromFile(duongDanAnhNhan);
                picAnhMon.SizeMode = PictureBoxSizeMode.StretchImage; 
            }

            if (numSoLuong.Value <= 0)
            {
                numSoLuong.Value = 1;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Ép kiểu chuẩn xác từ NumericUpDown sang INT
            this.soLuongChot = Convert.ToInt32(numSoLuong.Value);
            this.ghiChuChot = txtGhiChu.Text.Trim();

            // Kiểm tra nếu số lượng không hợp lệ
            if (this.soLuongChot <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng món lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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