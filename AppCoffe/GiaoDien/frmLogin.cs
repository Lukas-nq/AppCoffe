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
    public partial class frmLogin : Form
    {
        public static string Quyennguoidung = "";
        string connectionString = @"Data Source=.;Initial Catalog=QuanLyCafe;Integrated Security=True";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {// Sử dụng khối using để tự động đóng kết nối sau khi dùng xong
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // [2] Truy vấn kiểm tra tài khoản và mật khẩu
                string sql = "SELECT * FROM NguoiDung WHERE TaiKhoan=@user AND MatKhau=@pass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", txtdangnhap.Text);
                cmd.Parameters.AddWithValue("@pass", txtmatkhau.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Nếu tìm thấy tài khoản hợp lệ
                {
                    // [1, 2] Phân quyền: Mặc định admin là Quản trị, còn lại là Nhân viên
                    string role = (txtdangnhap.Text.ToLower() == "admin") ? "Admin" : "Staff";

                    // Chuyển sang màn hình chính và truyền quyền (role) sang đó
                    frmMainMenu main = new frmMainMenu(role);
                    main.Show();
                    this.Hide(); // Ẩn màn hình đăng nhập hiện tại
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo");
                }
            }
        }
    }
}
