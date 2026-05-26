using CoffeePOSLite.Classes;
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
    public partial class ucQuanLyMenu : UserControl
    {
        private string quyenNguoiDung = "";
        private string tenFileAnhDuocChon = "";

        public ucQuanLyMenu(string role)
        {
            InitializeComponent();
            this.quyenNguoiDung = role;
        }

        // 🛠️ SỬA LỖI CHÍNH TẢ: Thiếu tên biến "e" ở sự kiện Load
        private void ucQuanLyMenu_Load(object sender, EventArgs e)
        {
            TaiDanhSachLoaiMon();
            TaiDanhSachMenu();
            TrangThaiBanDau();

            if (!string.Equals(quyenNguoiDung, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnChonAnh.Visible = false;
            }
        }

        private void TaiDanhSachLoaiMon()
        {
            try
            {
                string sql = "SELECT MaLoai, TenLoai FROM DanhMuc"; // Sửa chữ viết hoa câu lệnh SQL cho chuẩn
                DataTable dt = DbContext.GetDataTable(sql);

                DataRow dr = dt.NewRow();
                dr["MaLoai"] = "ALL";
                dr["TenLoai"] = "Tất cả";
                dt.Rows.InsertAt(dr, 0);

                cboLocLoai.DataSource = dt;
                cboLocLoai.DisplayMember = "TenLoai";
                cboLocLoai.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSachMenu()
        {
            try
            {
                string sql = "SELECT MaMon, TenMon, Gia, MaLoai, Anh FROM MonAn WHERE 1=1";
                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    // 🛠️ SỬA LỖI CHÍNH TẢ: Thiếu dấu nháy đơn (') ở cuối câu lệnh LIKE
                    sql += " AND TenMon LIKE N'%" + txtTimKiem.Text.Trim() + "%'";
                }
                if (cboLocLoai.SelectedValue != null && cboLocLoai.SelectedValue.ToString() != "ALL")
                {
                    sql += " AND MaLoai = '" + cboLocLoai.SelectedValue.ToString() + "'";
                }
                DataTable dt = DbContext.GetDataTable(sql);
                dgvMenu.AutoGenerateColumns = false;
                dgvMenu.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách món: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrangThaiBanDau()
        {
            btnThem.Text = "Thêm";
            btnSua.Text = "Sửa";
            btnXoa.Text = "Xóa";

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            txtMaLoai.ReadOnly = true;
            txtMaMon.ReadOnly = true;
            txtTenMon.ReadOnly = true;
            txtDonGia.ReadOnly = true;

            TaiDanhSachMenu();
            tenFileAnhDuocChon = "";
        }

        private bool KiemTraMaLoaiHopLe(string maLoai)
        {
            // 🛠️ SỬA LỖI CHÍNH TẢ NGHIÊM TRỌNG: Câu lệnh gốc gõ sai cụm "whwrw Maloai = '" 
            // Sử dụng tham số @MaLoai truyền vào an toàn chống tấn công SQL Injection
            string sql = "SELECT COUNT(*) FROM [DanhMuc] WHERE MaLoai = @MaLoai";
            using (SqlConnection conn = DbContext.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai.Trim());
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void HienThiAnhMonAn(string tenFileAnh)
        {
            if (string.IsNullOrEmpty(tenFileAnh))
            {
                picAnhMonAn.Image = null;
                return;
            }

            string thuMucAnh = System.IO.Path.Combine(Application.StartupPath, "HinhAnhMonAn");
            string duongDanhAnh = System.IO.Path.Combine(thuMucAnh, tenFileAnh);

            if (!System.IO.File.Exists(duongDanhAnh))
            {
                picAnhMonAn.Image = null;
                return;
            }
            using (System.IO.FileStream fs = new System.IO.FileStream(duongDanhAnh, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                picAnhMonAn.Image = Image.FromStream(fs);
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvMenu.Rows[e.RowIndex].IsNewRow)
            {
                if (string.Equals(quyenNguoiDung, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    btnThem.Text = "Thêm";
                    btnSua.Text = "Sửa";
                    btnXoa.Text = "Xóa";

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }

                // 🛠️ SỬA LỖI CHÍNH TẢ: `dgvEmu` sửa thành `dgvMenu`, `e.Index` sửa thành `e.RowIndex` (Nguyên nhân gây sập Null)
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];

                txtMaMon.Text = row.Cells[0].Value?.ToString() ?? "";
                txtTenMon.Text = row.Cells[1].Value?.ToString() ?? "";
                txtDonGia.Text = row.Cells[2].Value?.ToString() ?? "";
                txtMaLoai.Text = row.Cells[3].Value?.ToString() ?? "";

                string tenFileAnh = "";
                // 🛠️ SỬA LỖI CHÍNH TẢ: Khai báo ép kiểu DataRowView thiếu tên biến đại diện và sai chữ hoa thường ["ANh"]
                if (row.DataBoundItem is DataRowView rowView)
                {
                    tenFileAnh = rowView["Anh"] == DBNull.Value ? "" : rowView["Anh"].ToString();
                }

                HienThiAnhMonAn(tenFileAnh);
                tenFileAnhDuocChon = "";
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
            {
                cboLocLoai.SelectedValue = "ALL"; // 🛠️ SỬA LỖI: Đồng bộ chữ viết hoa "ALL" thay vì "All"
            }
            TaiDanhSachMenu();
        }

        // 🛠️ SỬA LỖI CHÍNH TẢ: Thiếu tên biến "e" ở sự kiện thay đổi ComboBox
        private void cboLocLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocLoai.SelectedValue != null && cboLocLoai.SelectedValue.ToString() != "ALL")
            {
                txtTimKiem.TextChanged -= txtTimKiem_TextChanged;
                txtTimKiem.Text = "";
                txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            }
            TaiDanhSachMenu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnSua.Enabled = false;

                txtMaMon.Text = "";
                txtTenMon.Text = "";
                txtDonGia.Text = "";
                txtMaLoai.Text = "";
                picAnhMonAn.Image = null;

                txtMaMon.ReadOnly = false; // 🛠️ SỬA LỖI: Sửa dòng trùng txtMaLoai thành txtMaMon
                txtMaLoai.ReadOnly = false;
                txtTenMon.ReadOnly = false;
                txtDonGia.ReadOnly = false;
            }
            else if (btnThem.Text == "Lưu")
            {
                // 🛠️ SỬA LỖI: Sửa điều kiện gõ lặp 2 lần txtDonGia thành kiểm tra ô txtMaMon
                if (string.IsNullOrEmpty(txtMaLoai.Text.Trim()) || string.IsNullOrEmpty(txtMaMon.Text.Trim()) || string.IsNullOrEmpty(txtTenMon.Text.Trim()) || string.IsNullOrEmpty(txtDonGia.Text.Trim()))
                {
                    MessageBox.Show("Điền đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!KiemTraMaLoaiHopLe(txtMaLoai.Text.Trim()))
                {
                    MessageBox.Show("Mã loại [" + txtMaLoai.Text + "] không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (SqlConnection conn = DbContext.GetConnection())
                    {
                        // 🛠️ SỬA LỖI TRÙNG KHÓA NGOẠI: Bổ sung cột trường `@Anh` vào câu lệnh values mà gốc bị thiếu
                        string sqlInsert = "INSERT INTO MonAn (MaMon, TenMon, Gia, MaLoai, Anh) VALUES (@MaMon, @TenMon, @Gia, @MaLoai, @Anh)";
                        using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaMon", txtMaMon.Text.Trim());
                            cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text.Trim());
                            cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = Convert.ToInt32(txtDonGia.Text.Trim());
                            cmd.Parameters.AddWithValue("@MaLoai", txtMaLoai.Text.Trim());
                            cmd.Parameters.Add("@Anh", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(tenFileAnhDuocChon) ? (object)DBNull.Value : tenFileAnhDuocChon;

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Thêm món ăn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TrangThaiBanDau();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã món đã tồn tại hoặc lỗi hệ thống, vui lòng chọn mã khác!\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn một món ăn từ bảng trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnThem.Enabled = false;

                txtTenMon.ReadOnly = false;
                txtDonGia.ReadOnly = false;
            }
            else
            {
                if (string.IsNullOrEmpty(txtTenMon.Text.Trim()) || string.IsNullOrEmpty(txtDonGia.Text.Trim()))
                {
                    MessageBox.Show("Không được để trống thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (SqlConnection conn = DbContext.GetConnection())
                    {
                        string sqlUpdate = "UPDATE MonAn SET TenMon = @TenMon, Gia = @Gia, Anh = @Anh WHERE MaMon = @MaMon";
                        using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text.Trim());
                            cmd.Parameters.Add("@Gia", SqlDbType.Int).Value = Convert.ToInt32(txtDonGia.Text.Trim());
                            cmd.Parameters.AddWithValue("@MaMon", txtMaMon.Text.Trim());
                            object anhHienTai = dgvMenu.CurrentRow == null ? DBNull.Value : dgvMenu.CurrentRow.Cells["Anh"].Value;
                            string tenAnhLuu = !string.IsNullOrEmpty(tenFileAnhDuocChon)
                                ? tenFileAnhDuocChon
                                : (anhHienTai == DBNull.Value ? "" : anhHienTai.ToString());
                            cmd.Parameters.Add("@Anh", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(tenAnhLuu) ? (object)DBNull.Value : tenAnhLuu;

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Cập nhật thông tin món ăn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TrangThaiBanDau();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật hệ thống: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Hủy")
            {
                TrangThaiBanDau();
                return;
            }

            if (string.IsNullOrEmpty(txtMaMon.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa trên bảng dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa món [" + txtTenMon.Text + "] ra khỏi thực đơn không?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                try
                {
                    using (SqlConnection conn = DbContext.GetConnection())
                    {
                        string sqlDelete = "DELETE FROM MonAn WHERE MaMon = @MaMon";
                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaMon", txtMaMon.Text.Trim());
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Xóa món ăn ra khỏi thực đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMaLoai.Clear(); txtMaMon.Clear(); txtTenMon.Clear(); txtDonGia.Clear();
                    picAnhMonAn.Image = null;

                    TrangThaiBanDau();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Món ăn này đã tồn tại trong lịch sử hóa đơn bán hàng của quán, không thể xóa bừa bãi để giữ toàn vẹn dữ liệu doanh thu!\nChi tiết lỗi: " + ex.Message, "Lỗi Ràng Buộc Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            if (btnThem.Text != "Lưu" && btnSua.Text != "Lưu")
            {
                MessageBox.Show("Vui lòng chọn chức năng Thêm hoặc Sửa trước khi chọn ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh sản phẩm (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Chọn ảnh cho món ăn";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            picAnhMonAn.Image = Image.FromStream(fs);
                        }

                        tenFileAnhDuocChon = System.IO.Path.GetFileName(ofd.FileName);
                        string thuMucAnh = System.IO.Path.Combine(Application.StartupPath, "HinhAnhMonAn");

                        if (!System.IO.Directory.Exists(thuMucAnh))
                        {
                            System.IO.Directory.CreateDirectory(thuMucAnh);
                        }

                        string duongDanDich = System.IO.Path.Combine(thuMucAnh, tenFileAnhDuocChon);
                        System.IO.File.Copy(ofd.FileName, duongDanDich, true);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi khi chọn ảnh. Vui lòng thử lại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form fr = this.FindForm();
            if (fr != null)
            {
                fr.Close();
            }
        }
    }
}