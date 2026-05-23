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

namespace AppCoffe.UserControls
{
    public partial class ucSoDoBan : Form 
    {
        string strCon = @"Data Source=.;Initial Catalog=QuanLyCafe;Integrated Security=True";
        public ucSoDoBan()
        {
            InitializeComponent();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            Button btnSelected = sender as Button;
            if (btnSelected == null) return;
            string tenBan = btnSelected.Text;

            if (btnSelected.BackColor == Color.Green)
            {
                DialogResult r = MessageBox.Show($"Xác nhận chọn {tenBan}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    // Thực thi lệnh đổi màu nền sang màu đỏ
                    if (UpdateTableStatus(tenBan, "có khách"))
                    {
                        btnSelected.BackColor = Color.Red;
                    }
                }
            }
            // Trường hợp 2: Bàn đang CÓ KHÁCH (Màu Đỏ) -> Khách về, dọn bàn
            else if (btnSelected.BackColor == Color.Red)
            {
                DialogResult r = MessageBox.Show("Xác nhận dọn bàn?", "Cảnh báo an toàn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (r == DialogResult.Yes)
                {
                    // Đưa màu nền nút bấm quay trở lại màu xanh
                    if (UpdateTableStatus(tenBan, "Trống"))
                    {
                        btnSelected.BackColor = Color.Green;
                    }
                }
                // Nếu chọn [Hủy] (DialogResult.No), hệ thống tự giữ nguyên trạng thái cũ
            }
        }

        private bool UpdateTableStatus(string tenBan, string trangThai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    // Cập nhật tức thì trạng thái vào cơ sở dữ liệu SQL Server [1]
                    string sql = "UPDATE Ban SET TrangThai = @status WHERE TenBan = @name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@status", trangThai);
                    cmd.Parameters.AddWithValue("@name", tenBan);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật dữ liệu: " + ex.Message);
                return false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucSoDoBan_Load(object sender, EventArgs e)
        {

        }
    }
}
