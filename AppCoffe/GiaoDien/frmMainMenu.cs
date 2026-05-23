using AppCoffe.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCoffe.GiaoDien
{
    public partial class frmMainMenu : Form
    {
        private string userRole;
        public frmMainMenu(string role)
        {
            InitializeComponent();
            this.userRole = role;
            this.btnThongke.Click += btnThongke_Click;
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            if (!string.Equals(userRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnThongke.Visible = false;
                btnThongke.Enabled = false;
            }
        }

        private void btnKtraban_Click(object sender, EventArgs e)
        {
            ucSoDoBan sodo = new ucSoDoBan();
            sodo.ShowDialog();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            if (!string.Equals(userRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Chỉ tài khoản Admin mới được xem thống kê doanh thu.", "Không có quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form formThongKe = new Form())
            {
                formThongKe.Text = "Báo cáo thống kê doanh thu";
                formThongKe.StartPosition = FormStartPosition.CenterParent;
                formThongKe.WindowState = FormWindowState.Maximized;

                ucThongKe thongKe = new ucThongKe();
                thongKe.Dock = DockStyle.Fill;
                formThongKe.Controls.Add(thongKe);

                formThongKe.ShowDialog(this);
            }
        }
    }
}
