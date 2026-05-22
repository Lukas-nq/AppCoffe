using CoffeePOSLite.Classes;
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
    public partial class ucQuanLyMenu : UserControl
    {
        public ucQuanLyMenu()
        {
            InitializeComponent();
        }
        private void TaiDanhSachMenu()
        {
            try
            {
                string sql = "SELECT MaMon AS [Mã Món], TenMon AS [Tên Món], Gia AS [Đơn Giá], MaLoai AS [Mã Loại], Anh FROM MonAn"; DataTable dt = DbContext.GetDataTable(sql);
                dgvMenu.DataSource = dt;
                if (dgvMenu.Columns["Anh"] != null)
                {
                    dgvMenu.Columns["Anh"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải mdanh sách món ăn: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucQuanLyMenu_Load(object sender, EventArgs e)
        {
            TaiDanhSachMenu();
        }
    }
}
