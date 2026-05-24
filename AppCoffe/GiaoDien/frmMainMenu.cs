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

        private void GtnGoimon_Click(object sender, EventArgs e)
        {
            using (Form formGoiMon = new Form())
            {
                formGoiMon.Text = "HỆ THỐNG PHỤC VỤ KHÁCH HÀNG - GỌI MÓN";

                // Đặt kích thước mặc định to một chút để chứa đủ cả cụm thực đơn và hóa đơn
                formGoiMon.Size = new Size(1200, 750);
                formGoiMon.StartPosition = FormStartPosition.CenterParent;

                // Cho phép phóng to toàn màn hình nếu nhân viên muốn nhìn rõ hơn
                formGoiMon.MaximizeBox = true;
                formGoiMon.MinimizeBox = false;

                // Nạp giao diện ucGoiMon vào
                ucGoiMon goimon = new ucGoiMon();
                goimon.Dock = DockStyle.Fill;
                formGoiMon.Controls.Add(goimon);

                formGoiMon.ShowDialog(this);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            // KHÔNG chặn quyền ở đây nữa, để Staff bấm vào vẫn mở được giao diện xem danh sách món
            using (Form formMenu = new Form())
            {
                formMenu.Text = "HỆ THỐNG QUẢN LÝ THỰC ĐƠN - MENU";
                formMenu.Size = new Size(1100, 680);
                formMenu.StartPosition = FormStartPosition.CenterParent;
                formMenu.MaximizeBox = true;
                formMenu.MinimizeBox = false;

                ucQuanLyMenu quanLyMenu = new ucQuanLyMenu(this.userRole);
                quanLyMenu.Dock = DockStyle.Fill;
                formMenu.Controls.Add(quanLyMenu);

                formMenu.ShowDialog(this);
            }
        }
    }
}
