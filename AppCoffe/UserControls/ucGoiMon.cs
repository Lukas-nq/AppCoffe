using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CoffeePOSLite.Classes;

namespace AppCoffe.UserControls
{
    public partial class ucGoiMon : UserControl
    {
        // ĐÃ XÓA: Dòng viết cứng chuỗi kết nối lỗi thời (chuoiKetNoi)

        public ucGoiMon()
        {
            InitializeComponent();
        }

        private void ucGoiMon_Load(object sender, EventArgs e)
        {
            LoadThucDon("SELECT * FROM MonAn");
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sqlTimKiem = "SELECT * FROM MonAn WHERE TenMon LIKE N'%" + txtTimKiem.Text.Trim() + "%'";
            LoadThucDon(sqlTimKiem);
        }

        public void LoadThucDon(string cauLenhSQL)
        {
            flpMenu.Controls.Clear();

            // ĐÃ SỬA: Thay thế new SqlConnection(chuoiKetNoi) thành hàm dùng chung của nhóm
            using (SqlConnection conn = DbContext.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(cauLenhSQL, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                usCardMonAn theMonAn = new usCardMonAn();
                                string ten = rd["TenMon"].ToString();
                                decimal gia = Convert.ToDecimal(rd["Gia"]);

                                // Bọc bùa hộ mệnh tránh lỗi sập phần mềm nếu trường ảnh trong DB bị NULL
                                string tenAnh = rd["Anh"] != DBNull.Value ? rd["Anh"].ToString() : "";
                                string anh = !string.IsNullOrEmpty(tenAnh)
                                    ? System.IO.Path.Combine(Application.StartupPath, "Images", tenAnh)
                                    : ""; // Nếu không có ảnh thì để chuỗi rỗng

                                theMonAn.TruyenDuLieu(ten, gia, anh);
                                theMonAn.TheBiBam += SuKien_Mo_Popup;
                                flpMenu.Controls.Add(theMonAn);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi load món: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // ĐÃ TỐI ƯU: Sử dụng cấu trúc 'using' để C# tự động đóng kết nối (conn.Close) sạch sẽ, tránh kẹt RAM
                }
            }
        }

        private void SuKien_Mo_Popup(object sender, EventArgs e)
        {
            usCardMonAn theVuaBam = (usCardMonAn)sender;
            frmPopupTreo popup = new frmPopupTreo();
            popup.tenMonNhan = theVuaBam.tenMonLuu;
            popup.giaMonNhan = theVuaBam.giaMonLuu;

            if (popup.ShowDialog() == DialogResult.OK)
            {
                int soLuong = popup.soLuongChot;
                decimal donGia = theVuaBam.giaMonLuu;
                decimal thanhTien = soLuong * donGia;
                dgvGioHang.Rows.Add(theVuaBam.tenMonLuu, soLuong, donGia, thanhTien, popup.ghiChuChot);
                TinhTongTien();
            }
        }

        public void TinhTongTien()
        {
            decimal tong = 0;
            for (int i = 0; i < dgvGioHang.Rows.Count; i++)
            {
                if (dgvGioHang.Rows[i].Cells[3].Value != null)
                {
                    tong = tong + Convert.ToDecimal(dgvGioHang.Rows[i].Cells[3].Value);
                }
            }
            lblTongTien.Text = tong.ToString("#,##0") + " VNĐ";
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.Parent != null)
            {
                foreach (Control manHinh in this.Parent.Controls)
                {
                    if (manHinh is ucQuanLyMenu)
                    {
                        manHinh.Show();
                        manHinh.BringToFront();
                        return;
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có món nào trong giỏ hàng. Vui lòng chọn món trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult hopThoai = MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hopThoai == DialogResult.Yes)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvGioHang.Rows.Clear();
                TinhTongTien();
                this.Hide();
                if (this.Parent != null)
                {
                    foreach (Control manHinh in this.Parent.Controls)
                    {
                        if (manHinh is ucSoDoBan)
                        {
                            manHinh.Show();
                            manHinh.BringToFront();
                            return;
                        }
                    }
                }
            }
        }

        private void flpMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}