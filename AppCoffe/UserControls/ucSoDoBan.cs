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
using CoffeePOSLite.Classes;

namespace AppCoffe.UserControls
{
    public partial class ucSoDoBan : Form 
    {
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
                    if (UpdateTableStatus(tenBan, 1))
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
                    if (UpdateTableStatus(tenBan, 0))
                    {
                        btnSelected.BackColor = Color.Green;
                    }
                }
                // Nếu chọn [Hủy] (DialogResult.No), hệ thống tự giữ nguyên trạng thái cũ
            }
        }

        private bool UpdateTableStatus(string tenBan, int trangThai)
        {
            try
            {
                using (SqlConnection conn = DbContext.GetConnection())
                {
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
            TaiDanhSachBan();
        }

        private void TaiDanhSachBan()
        {
            try
            {
                Button[] buttons = { btnBan1, btnBan2, btnBan3, btnBan4, btnBan5 };
                foreach (Button button in buttons)
                {
                    button.Visible = false;
                }

                using (SqlConnection conn = DbContext.GetConnection())
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 5 TenBan, TrangThai FROM Ban ORDER BY MaBan", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int index = 0;
                        while (reader.Read() && index < buttons.Length)
                        {
                            Button button = buttons[index];
                            button.Text = reader["TenBan"].ToString();
                            button.BackColor = Convert.ToInt32(reader["TrangThai"]) == 1 ? Color.Red : Color.Green;
                            button.Visible = true;
                            index++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sơ đồ bàn: " + ex.Message);
            }
        }
    }
}
