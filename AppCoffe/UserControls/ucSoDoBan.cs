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
    public partial class ucSoDoBan : UserControl
    {
        public ucSoDoBan()
        {
            InitializeComponent();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            Button btnSelected = sender as Button;
            if (btnSelected == null) return;

            // THIẾT LẬP CẤU TRÚC KIỂM TRA MÀU NỀN
            // Trường hợp 1: Bàn đang TRỐNG (Màu Xanh) -> Khách vào ngồi
            if (btnSelected.BackColor == Color.Green)
            {
                DialogResult r = MessageBox.Show($"Xác nhận chọn {btnSelected.Text}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    // Thực thi lệnh đổi màu nền sang màu đỏ
                    btnSelected.BackColor = Color.Red;
                }
            }
            // Trường hợp 2: Bàn đang CÓ KHÁCH (Màu Đỏ) -> Khách về, dọn bàn
            else if (btnSelected.BackColor == Color.Red)
            {
                DialogResult r = MessageBox.Show("Xác nhận dọn bàn?", "Cảnh báo an toàn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (r == DialogResult.Yes)
                {
                    // Đưa màu nền nút bấm quay trở lại màu xanh
                    btnSelected.BackColor = Color.Green;
                }
                // Nếu chọn [Hủy] (DialogResult.No), hệ thống tự giữ nguyên trạng thái cũ
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
