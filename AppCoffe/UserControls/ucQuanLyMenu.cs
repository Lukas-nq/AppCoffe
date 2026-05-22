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
using System.Data.SqlClient;

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
                string sql = "SELECT MaMon AS 'Mã Món', TenMon AS 'Tên Món', Gia AS 'Đơn Giá', MaLoai AS 'Mã Loại', Anh FROM MonAn WHERE 1=1";
                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    sql += " AND TenMon LIKE N'%"+ txtTimKiem.Text.Trim()+"%'";
                }
                    if (cboLocLoai.SelectedValue != null && cboLocLoai.SelectedValue.ToString() != "ALL")
                    {
                        sql += " AND MaLoai = '" + cboLocLoai.SelectedValue.ToString() + "'";
    
                    }
                    DataTable dt = DbContext.GetDataTable(sql);
                    dgvMenu.DataSource = dt;
                    if (dgvMenu.Columns["Anh"] != null)
                    {
                        dgvMenu.Columns["Anh"].Visible = false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách món: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TaiDanhSachLoaiMon()
        {
            try
            {
                string sql = "SELECT MaLoai,TenLoai FROM DanhMuc";
                DataTable dt = DbContext.GetDataTable(sql);

                DataRow dr = dt.NewRow();
                dr["MaLoai"] = "ALL";
                dr["TenLoai"] = "Tất cả";
                dt.Rows.InsertAt(dr, 0);

                cboLocLoai.DataSource = dt;
                cboLocLoai.DisplayMember = "TenLoai";
                    cboLocLoai.ValueMember = "MaLoai";
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi tải danh mục: " + e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ucQuanLyMenu_Load(object sender, EventArgs e)
        {
            TaiDanhSachLoaiMon();
            TaiDanhSachMenu();
            
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];

                txtMaMon.Text = row.Cells["Mã Món"].Value.ToString();
                txtTenMon.Text = row.Cells["Tên Món"].Value.ToString();
                txtDonGia.Text = row.Cells["Đơn Giá"].Value.ToString();
                txtMaLoai.Text = row.Cells["Mã Loại"].Value.ToString();

                // hiển thị ảnh 
                string tenFileAnh = row.Cells["Anh"].Value.ToString();
                if (!string.IsNullOrEmpty(tenFileAnh))
                {
                    string thuMucAnh = System.IO.Path.Combine(Application.StartupPath, "HinhAnhMonAn");
                    string duongDanAnhDayDu = System.IO.Path.Combine(thuMucAnh, tenFileAnh);

                    if (System.IO.File.Exists(duongDanAnhDayDu))
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(duongDanAnhDayDu, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            picAnhMonAn.Image = Image.FromStream(fs);
                        }
                    }
                    else
                    {
                        picAnhMonAn.Image = null;
                    }
                }
                else
                {
                    picAnhMonAn.Image = null;
                } 
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
            {
                cboLocLoai.SelectedValue = "ALL";
            }
            TaiDanhSachMenu();
        }

        private void cboLocLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocLoai.SelectedValue != null && cboLocLoai.SelectedValue.ToString() != "ALL")
            {
                txtTimKiem.TextChanged -= txtTimKiem_TextChanged;

                txtTimKiem.Clear();

                txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            }
            TaiDanhSachMenu();
        }
    }
}
