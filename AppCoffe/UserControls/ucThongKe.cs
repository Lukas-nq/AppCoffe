using CoffeePOSLite.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace AppCoffe.UserControls
{
    public partial class ucThongKe : UserControl
    {
        private bool daTaiForm;

        public ucThongKe()
        {
            InitializeComponent();
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            cboSapXep.SelectedIndex = 0;
            daTaiForm = true;
            TaiBaoCao(true);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (!KiemTraKhoangThoiGian(true))
            {
                return;
            }

            TaiBaoCao(true);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!daTaiForm || !KiemTraKhoangThoiGian(false))
            {
                return;
            }

            TaiBaoCao(false);
        }

        private void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!daTaiForm || !KiemTraKhoangThoiGian(false))
            {
                return;
            }

            TaiBaoCao(false);
        }

        private void dgvThongKe_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DinhDangBang();
            TinhTongDoanhThu();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form formHienTai = FindForm();
            if (formHienTai != null)
            {
                formHienTai.Close();
            }
        }

        private bool KiemTraKhoangThoiGian(bool hienCanhBao)
        {
            if (dtpTuNgay.Value.Date <= dtpDenNgay.Value.Date)
            {
                return true;
            }

            if (hienCanhBao)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        private void TaiBaoCao(bool hienThongBaoLoi)
        {
            if (!KiemTraKhoangThoiGian(hienThongBaoLoi))
            {
                return;
            }

            try
            {
                using (SqlConnection conn = DbContext.GetConnection())
                {
                    conn.Open();
                    BaoCaoSchema schema = TaoSchemaBaoCao(conn);
                    string sql = TaoCauLenhThongKe(schema);

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = dtpTuNgay.Value.Date;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = dtpDenNgay.Value.Date.AddDays(1);
                        cmd.Parameters.Add("@TuKhoa", SqlDbType.NVarChar, 200).Value = txtTimKiem.Text.Trim();

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        dgvThongKe.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                dgvThongKe.DataSource = null;
                lblTongDoanhThu.Text = "TỔNG DOANH THU: 0 VNĐ";

                if (hienThongBaoLoi)
                {
                    MessageBox.Show("Lỗi tải báo cáo thống kê: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private BaoCaoSchema TaoSchemaBaoCao(SqlConnection conn)
        {
            TableInfo bangHoaDon = TimBang(conn, "HoaDon", "HoaDonBanHang", "Bill", "Bills");
            TableInfo bangChiTiet = TimBang(conn, "ChiTietHD", "ChiTietHoaDon", "CTHoaDon", "CTHD", "HoaDonChiTiet", "BillDetails");
            TableInfo bangMonAn = TimBang(conn, "MonAn", "Mon", "ThucDon", "Menu");

            if (bangHoaDon == null || bangChiTiet == null || bangMonAn == null)
            {
                throw new InvalidOperationException("Không tìm thấy đủ bảng HoaDon, ChiTietHD và MonAn trong database.");
            }

            BaoCaoSchema schema = new BaoCaoSchema();
            schema.BangHoaDon = bangHoaDon;
            schema.BangChiTiet = bangChiTiet;
            schema.BangMonAn = bangMonAn;
            schema.CotMaHoaDon = TimCot(conn, bangHoaDon, "MaHD", "MaHoaDon", "ID", "Id");
            schema.CotMaHoaDonChiTiet = TimCot(conn, bangChiTiet, "MaHD", "MaHoaDon", "IDHoaDon", "HoaDonID");
            schema.CotMaMonChiTiet = TimCot(conn, bangChiTiet, "MaMon", "MaMonAn", "MonAnID", "IDMon");
            schema.CotMaMon = TimCot(conn, bangMonAn, "MaMon", "MaMonAn", "ID", "Id");
            schema.CotTenMon = TimCot(conn, bangMonAn, "TenMon", "TenMonAn", "Ten", "TenSanPham");
            schema.CotGiaMon = TimCot(conn, bangMonAn, "Gia", "DonGia", "GiaBan");
            schema.CotNgayHoaDon = TimCot(conn, bangHoaDon, "NgayLap", "NgayTao", "NgayThanhToan", "NgayHD", "Ngay");
            schema.CotSoLuong = TimCot(conn, bangChiTiet, "SoLuong", "SL", "Quantity");
            schema.CotDonGiaChiTiet = TimCot(conn, bangChiTiet, "DonGia", "Gia", "GiaBan");
            schema.CotThanhTienChiTiet = TimCot(conn, bangChiTiet, "ThanhTien", "ThanhTienMon", "TongTien");
            schema.CotTrangThaiHoaDon = TimCot(conn, bangHoaDon, "TrangThai", "TinhTrang", "TrangThaiThanhToan", "Status", "DaThanhToan", "IsPaid");
            schema.KieuDuLieuTrangThaiHoaDon = schema.CotTrangThaiHoaDon == null ? null : TimKieuDuLieuCot(conn, bangHoaDon, schema.CotTrangThaiHoaDon);

            if (schema.CotMaHoaDon == null || schema.CotMaHoaDonChiTiet == null ||
                schema.CotMaMonChiTiet == null || schema.CotMaMon == null ||
                schema.CotTenMon == null || schema.CotGiaMon == null ||
                schema.CotNgayHoaDon == null || schema.CotSoLuong == null)
            {
                throw new InvalidOperationException("Thiếu cột cần thiết để thống kê doanh thu.");
            }

            return schema;
        }
        private string TaoCauLenhThongKe(BaoCaoSchema schema)
        {
            string soLuongExpr = "ct." + QuoteName(schema.CotSoLuong);
            string giaExpr = schema.CotDonGiaChiTiet != null
                ? "ISNULL(ct." + QuoteName(schema.CotDonGiaChiTiet) + ", m." + QuoteName(schema.CotGiaMon) + ")"
                : "m." + QuoteName(schema.CotGiaMon);
            string thanhTienExpr = schema.CotThanhTienChiTiet != null
                ? "ct." + QuoteName(schema.CotThanhTienChiTiet)
                : "(" + soLuongExpr + " * " + giaExpr + ")";

            string sapXepExpr = LayCotSapXep(soLuongExpr, thanhTienExpr);
            string chieuSapXep = LayChieuSapXep();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    ROW_NUMBER() OVER (ORDER BY " + sapXepExpr + " " + chieuSapXep + ", m." + QuoteName(schema.CotTenMon) + " ASC) AS [STT],");
            sql.AppendLine("    m." + QuoteName(schema.CotTenMon) + " AS [Tên món],");
            sql.AppendLine("    m." + QuoteName(schema.CotGiaMon) + " AS [Đơn giá],");
            sql.AppendLine("    SUM(" + soLuongExpr + ") AS [Số lượng bán],");
            sql.AppendLine("    SUM(" + thanhTienExpr + ") AS [Thành tiền]");
            sql.AppendLine("FROM " + schema.BangHoaDon.FullName + " hd");
            sql.AppendLine("INNER JOIN " + schema.BangChiTiet.FullName + " ct ON hd." + QuoteName(schema.CotMaHoaDon) + " = ct." + QuoteName(schema.CotMaHoaDonChiTiet));
            sql.AppendLine("INNER JOIN " + schema.BangMonAn.FullName + " m ON ct." + QuoteName(schema.CotMaMonChiTiet) + " = m." + QuoteName(schema.CotMaMon));
            sql.AppendLine("WHERE hd." + QuoteName(schema.CotNgayHoaDon) + " >= @TuNgay");
            sql.AppendLine("  AND hd." + QuoteName(schema.CotNgayHoaDon) + " < @DenNgay");
            sql.AppendLine("  AND (@TuKhoa = N'' OR m." + QuoteName(schema.CotTenMon) + " LIKE N'%' + @TuKhoa + N'%')");

            if (schema.CotTrangThaiHoaDon != null && LaKieuDuLieuChuoi(schema.KieuDuLieuTrangThaiHoaDon))
            {
                sql.AppendLine("  AND (hd." + QuoteName(schema.CotTrangThaiHoaDon) + " IS NULL OR hd." + QuoteName(schema.CotTrangThaiHoaDon) + " NOT IN (N'Hủy', N'Huỷ', N'Đã hủy', N'Đã huỷ', N'Chưa thanh toán'))");
            }
            else if (schema.CotTrangThaiHoaDon != null && string.Equals(schema.KieuDuLieuTrangThaiHoaDon, "bit", StringComparison.OrdinalIgnoreCase))
            {
                sql.AppendLine("  AND hd." + QuoteName(schema.CotTrangThaiHoaDon) + " = 1");
            }

            sql.AppendLine("GROUP BY m." + QuoteName(schema.CotMaMon) + ", m." + QuoteName(schema.CotTenMon) + ", m." + QuoteName(schema.CotGiaMon));
            sql.AppendLine("ORDER BY " + sapXepExpr + " " + chieuSapXep + ", m." + QuoteName(schema.CotTenMon) + " ASC");

            return sql.ToString();
        }

        private string LayCotSapXep(string soLuongExpr, string thanhTienExpr)
        {
            string luaChon = cboSapXep.SelectedItem == null ? "" : cboSapXep.SelectedItem.ToString();
            if (luaChon.StartsWith("Số lượng bán"))
            {
                return "SUM(" + soLuongExpr + ")";
            }

            return "SUM(" + thanhTienExpr + ")";
        }

        private string LayChieuSapXep()
        {
            string luaChon = cboSapXep.SelectedItem == null ? "" : cboSapXep.SelectedItem.ToString();
            return luaChon.EndsWith("tăng dần") ? "ASC" : "DESC";
        }

        private TableInfo TimBang(SqlConnection conn, params string[] tenBang)
        {
            foreach (string ten in tenBang)
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 1 TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME = @TenBang ORDER BY CASE WHEN TABLE_SCHEMA = 'dbo' THEN 0 ELSE 1 END", conn))
                {
                    cmd.Parameters.Add("@TenBang", SqlDbType.NVarChar, 128).Value = ten;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TableInfo(reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }

            return null;
        }

        private string TimCot(SqlConnection conn, TableInfo table, params string[] tenCot)
        {
            foreach (string ten in tenCot)
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @Table AND COLUMN_NAME = @Column", conn))
                {
                    cmd.Parameters.Add("@Schema", SqlDbType.NVarChar, 128).Value = table.Schema;
                    cmd.Parameters.Add("@Table", SqlDbType.NVarChar, 128).Value = table.Name;
                    cmd.Parameters.Add("@Column", SqlDbType.NVarChar, 128).Value = ten;
                    object value = cmd.ExecuteScalar();
                    if (value != null)
                    {
                        return value.ToString();
                    }
                }
            }

            return null;
        }

        private string TimKieuDuLieuCot(SqlConnection conn, TableInfo table, string tenCot)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @Table AND COLUMN_NAME = @Column", conn))
            {
                cmd.Parameters.Add("@Schema", SqlDbType.NVarChar, 128).Value = table.Schema;
                cmd.Parameters.Add("@Table", SqlDbType.NVarChar, 128).Value = table.Name;
                cmd.Parameters.Add("@Column", SqlDbType.NVarChar, 128).Value = tenCot;
                object value = cmd.ExecuteScalar();
                return value == null ? null : value.ToString();
            }
        }

        private bool LaKieuDuLieuChuoi(string kieuDuLieu)
        {
            return string.Equals(kieuDuLieu, "nvarchar", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(kieuDuLieu, "varchar", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(kieuDuLieu, "nchar", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(kieuDuLieu, "char", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(kieuDuLieu, "text", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(kieuDuLieu, "ntext", StringComparison.OrdinalIgnoreCase);
        }

        private string QuoteName(string name)
        {
            return "[" + name.Replace("]", "]]") + "]";
        }

        private void DinhDangBang()
        {
            if (dgvThongKe.Columns["STT"] != null)
            {
                dgvThongKe.Columns["STT"].Width = 70;
                dgvThongKe.Columns["STT"].FillWeight = 45;
                dgvThongKe.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvThongKe.Columns["Tên món"] != null)
            {
                dgvThongKe.Columns["Tên món"].FillWeight = 160;
            }

            DinhDangCotSo("Đơn giá");
            DinhDangCotSo("Số lượng bán");
            DinhDangCotSo("Thành tiền");
        }

        private void DinhDangCotSo(string tenCot)
        {
            if (dgvThongKe.Columns[tenCot] == null)
            {
                return;
            }

            dgvThongKe.Columns[tenCot].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns[tenCot].DefaultCellStyle.Format = "N0";
        }

        private void TinhTongDoanhThu()
        {
            decimal tongDoanhThu = 0;

            foreach (DataGridViewRow row in dgvThongKe.Rows)
            {
                if (row.IsNewRow || row.Cells["Thành tiền"].Value == null || row.Cells["Thành tiền"].Value == DBNull.Value)
                {
                    continue;
                }

                decimal thanhTien;
                if (decimal.TryParse(row.Cells["Thành tiền"].Value.ToString(), out thanhTien))
                {
                    tongDoanhThu += thanhTien;
                }
            }

            lblTongDoanhThu.Text = "TỔNG DOANH THU: " + tongDoanhThu.ToString("#,##0") + " VNĐ";
        }

        private class TableInfo
        {
            public TableInfo(string schema, string name)
            {
                Schema = schema;
                Name = name;
            }

            public string Schema { get; private set; }
            public string Name { get; private set; }

            public string FullName
            {
                get { return "[" + Schema.Replace("]", "]]") + "].[" + Name.Replace("]", "]]") + "]"; }
            }
        }

        private class BaoCaoSchema
        {
            public TableInfo BangHoaDon { get; set; }
            public TableInfo BangChiTiet { get; set; }
            public TableInfo BangMonAn { get; set; }
            public string CotMaHoaDon { get; set; }
            public string CotMaHoaDonChiTiet { get; set; }
            public string CotMaMonChiTiet { get; set; }
            public string CotMaMon { get; set; }
            public string CotTenMon { get; set; }
            public string CotGiaMon { get; set; }
            public string CotNgayHoaDon { get; set; }
            public string CotSoLuong { get; set; }
            public string CotDonGiaChiTiet { get; set; }
            public string CotThanhTienChiTiet { get; set; }
            public string CotTrangThaiHoaDon { get; set; }
            public string KieuDuLieuTrangThaiHoaDon { get; set; }
        }

        private void dgvThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
