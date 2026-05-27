using System;
using System.Data;
using System.Data.SqlClient;

namespace CoffeePOSLite.Classes
{
    // 1. CLASS LƯU TRẠNG THÁI TOÀN CỤC (GLOBAL SESSION)
    public static class LuuThongTin
    {
        public static string TaiKhoan; 
        public static string Quyen;    
        public static string MaHDVuaThanhToan; 
    }

    // 2. CLASS KẾT NỐI DỮ LIỆU CHUNG (DATABASE CONTEXT)
    public static class DbContext
    {
        // Chuỗi kết nối dùng chung cho database CoffeePOSLite.
        private static readonly string connectionStringGroup = @"Data Source=.\SQLEXPRESS;Initial Catalog=CoffeePOSLite;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
        // chuỗi kết nối dùng riêng cho SQLEXPRESS01 vì máy t là SQLEXPRESS01
        private static readonly string connectionStringLocal = @"Data Source=.\SQLEXPRESS01;Initial Catalog=CoffeePOSLite;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        // Hàm mở kết nối an toàn cho cả nhóm gọi ra dùng
        public static SqlConnection GetConnection()
        {
            string currentMachineName = Environment.MachineName.ToUpper();
            // // Kiểm tra nếu đúng là máy t, trả về chuỗi kết nối Local có số 01
            if (currentMachineName == "ADMIN-PC")
            {
                return new SqlConnection(connectionStringLocal);
            }

            // Nếu không phải máy ADMIN-PC, mặc định dùng SQLEXPRESS
            return new SqlConnection(connectionStringGroup);
        }


        // Hàm mẫu để chạy nhanh câu lệnh truy vấn lấy bảng dữ liệu (Dùng cho DataGridView)
        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi kết nối", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}
