using System;
using System.Data;
using System.Data.SqlClient;

namespace CoffeePOSLite.Classes
{
    // 1. CLASS LƯU TRẠNG THÁI TOÀN CỤC (GLOBAL SESSION)
    public static class LuuThongTin
    {
        public static string TaiKhoan; // Lưu tên người vừa đăng nhập thành công
        public static string Quyen;    // Lưu "Admin" hoặc "Staff" để ẩn/hiện nút chức năng
        public static string MaHDVuaThanhToan; // Biến tạm truyền dữ liệu từ Gọi món sang Sơ đồ bàn để đặt vị trí
    }

    // 2. CLASS KẾT NỐI DỮ LIỆU CHUNG (DATABASE CONTEXT)
    public static class DbContext
    {
        // Chuỗi kết nối dùng chung cho database CoffeePOSLite.
        private static readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CoffeePOSLite;Integrated Security=True";

        // Hàm mở kết nối an toàn cho cả nhóm gọi ra dùng
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Hàm mẫu để chạy nhanh câu lệnh truy vấn lấy bảng dữ liệu (Dùng cho DataGridView)
        public static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
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
            return dt;
        }
    }
}
