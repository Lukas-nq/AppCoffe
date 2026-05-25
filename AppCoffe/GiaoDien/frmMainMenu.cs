using AppCoffe.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            using(Form formSoDo = new Form())
            {
                formSoDo.FormBorderStyle = FormBorderStyle.None;
                formSoDo.Size = new Size(850,600);
                formSoDo.StartPosition = FormStartPosition.CenterParent;
                ucSoDoBan sodo = new ucSoDoBan();
                sodo.Dock = DockStyle.Fill;
                formSoDo.Controls.Add(sodo);
                formSoDo.ShowDialog(this);
            }

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


        private void btnMenu_Click(object sender, EventArgs e)
        {
            // KHÔNG chặn quyền ở đây nữa, để Staff bấm vào vẫn mở được giao diện xem danh sách món
            using (Form formMenu = new Form())
            {
                formMenu.Text = "HỆ THỐNG QUẢN LÝ THỰC ĐƠN - MENU";

                formMenu.AutoScaleMode = AutoScaleMode.None;

                formMenu.ClientSize = new Size(900, 550);

                formMenu.StartPosition = FormStartPosition.CenterParent;
                formMenu.MaximizeBox = true; 
                formMenu.MinimizeBox = false;

                ucQuanLyMenu quanLyMenu = new ucQuanLyMenu(this.userRole);

                quanLyMenu.Dock = DockStyle.Fill;

                formMenu.Controls.Add(quanLyMenu);

                formMenu.ShowDialog(this);
            }
        }

        private void GtnGoimon_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra kết nối trước khi làm bất cứ việc gì khác
            try
            {
                using (SqlConnection conn = CoffeePOSLite.Classes.DbContext.GetConnection())
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối Database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng luôn ở đây, không chạy code bên dưới nữa
            }

            // 2. Chỉ khi kết nối OK mới tạo và hiện Form
            using (Form formGoiMon = new Form())
            {
                formGoiMon.Text = "HỆ THỐNG PHỤC VỤ KHÁCH HÀNG - GỌI MÓN";
                formGoiMon.Size = new Size(1200, 750);
                formGoiMon.StartPosition = FormStartPosition.CenterParent;

                ucGoiMon goimon = new ucGoiMon();
                goimon.Dock = DockStyle.Fill;
                formGoiMon.Controls.Add(goimon);

                formGoiMon.ShowDialog(this);
            }
        }

        
    }
}
