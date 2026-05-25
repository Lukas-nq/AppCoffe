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
        public ucGoiMon()
        {
            InitializeComponent();
        }
        private void ucGoiMon_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                LoadThucDon("SELECT * FROM MonAn");
            }));
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string sqlTimKiem = "SELECT * FROM MonAn WHERE TenMon LIKE N'%" + txtTimKiem.Text.Trim() + "%'";
            LoadThucDon(sqlTimKiem);
        }
        public void LoadThucDon(string cauLenhSQL)
        {
            flpMenu.Controls.Clear();
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
                                string tenAnh = rd["Anh"] != DBNull.Value ? rd["Anh"].ToString() : "";
                                string anh = !string.IsNullOrEmpty(tenAnh) ? System.IO.Path.Combine(Application.StartupPath, "HinhAnhMonAn", tenAnh) : "";
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
                }
            }
        }
        private void SuKien_Mo_Popup(object sender, EventArgs e)
        {
            usCardMonAn theVuaBam = (usCardMonAn)sender;
            using (frmPopupTreo popup = new frmPopupTreo())
            {
                popup.tenMonNhan = theVuaBam.tenMonLuu;
                popup.giaMonNhan = theVuaBam.giaMonLuu;
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.duongDanAnhNhan = theVuaBam.anhMonLuu;
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    int soLuong = popup.soLuongChot;
                    decimal donGia = theVuaBam.giaMonLuu;
                    decimal thanhTien = soLuong * donGia;
                    dgvGioHang.Rows.Add(theVuaBam.tenMonLuu, soLuong, donGia, thanhTien, popup.ghiChuChot);
                    TinhTongTien();
                }
            }
        }
        public void TinhTongTien()
        {
            decimal tong = 0;
            for (int i = 0; i < dgvGioHang.Rows.Count; i++)
            {
                if (dgvGioHang.Rows[i].Cells[3].Value != null)
                {
                    tong += Convert.ToDecimal(dgvGioHang.Rows[i].Cells[3].Value);
                }
            }
            lblTongTien.Text = "TỔNG TIỀN: " + tong.ToString("#,##0") + " VNĐ";
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form formChuaNo = this.FindForm();

            if (formChuaNo != null)
            {
                formChuaNo.Close();
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
                string maHD = "HD" + DateTime.Now.ToString("ddHHmmss");
                int tongTienHD = 0;
                for (int i = 0; i < dgvGioHang.Rows.Count; i++)
                {
                    if (dgvGioHang.Rows[i].Cells[3].Value != null)
                    {
                        tongTienHD += Convert.ToInt32(dgvGioHang.Rows[i].Cells[3].Value);
                    }
                }
                using (SqlConnection conn = DbContext.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string sqlHoaDon = "INSERT INTO HoaDon (MaHD, NgayLap, TongTien, TaiKhoan, MaBan) VALUES (@ma, GETDATE(), @tong, 'admin', 'B01')";
                        using (SqlCommand cmdHD = new SqlCommand(sqlHoaDon, conn))
                        {
                            cmdHD.Parameters.AddWithValue("@ma", maHD);
                            cmdHD.Parameters.AddWithValue("@tong", tongTienHD);
                            cmdHD.ExecuteNonQuery();
                        }
                        for (int i = 0; i < dgvGioHang.Rows.Count; i++)
                        {
                            if (dgvGioHang.Rows[i].Cells[0].Value != null)
                            {
                                string tenMon = dgvGioHang.Rows[i].Cells[0].Value.ToString();
                                int soLuong = Convert.ToInt32(dgvGioHang.Rows[i].Cells[1].Value);
                                int thanhTien = Convert.ToInt32(dgvGioHang.Rows[i].Cells[3].Value);
                                string maMon = "";
                                string sqlTimMa = "SELECT MaMon FROM MonAn WHERE TenMon = @tenMon";
                                using (SqlCommand cmdTim = new SqlCommand(sqlTimMa, conn))
                                {
                                    cmdTim.Parameters.AddWithValue("@tenMon", tenMon);
                                    object ketQua = cmdTim.ExecuteScalar();
                                    if (ketQua != null) maMon = ketQua.ToString();
                                }
                                if (!string.IsNullOrEmpty(maMon))
                                {
                                    string sqlChiTiet = "INSERT INTO ChiTietHD (MaHD, MaMon, SoLuong, ThanhTien) VALUES (@maHD, @maMon, @sl, @tien)";
                                    using (SqlCommand cmdCT = new SqlCommand(sqlChiTiet, conn))
                                    {
                                        cmdCT.Parameters.AddWithValue("@maHD", maHD);
                                        cmdCT.Parameters.AddWithValue("@maMon", maMon);
                                        cmdCT.Parameters.AddWithValue("@sl", soLuong);
                                        cmdCT.Parameters.AddWithValue("@tien", thanhTien);
                                        cmdCT.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        dgvGioHang.Rows.Clear();
                        TinhTongTien();
                        DialogResult dieuHuong = MessageBox.Show("Lưu hóa đơn thành công!\n\n- Chọn [YES] để tiếp tục bán đơn mới.\n- Chọn [NO] để đóng màn hình.", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dieuHuong == DialogResult.No)
                        {
                            Form formCong = this.FindForm();
                            if (formCong != null)
                            {
                                formCong.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu hóa đơn: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM MonAn";
            string luaChon = cbDanhMuc.Text.Trim().ToLower();
            if (luaChon == "đồ uống")
            {
                sql = "SELECT * FROM MonAn WHERE MaLoai = 'L01' OR MaLoai = 'L02'";
            }
            else if (luaChon == "đồ ăn")
            {
                sql = "SELECT * FROM MonAn WHERE MaLoai = 'L03'";
            }
            LoadThucDon(sql);
        }
    }
}