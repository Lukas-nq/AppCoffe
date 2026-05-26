using System;
using System.Data;
using System.Data.SqlClient;

namespace CoffeePOSLite.Classes
{

    public static class LuuThongTin
    {
        public static string TaiKhoan; 
        public static string Quyen;
        public static string MaHDVuaThanhToan;
    }

    public static class DbContext
    {

        private static readonly string connectionStringGroup = @"Data Source=.\SQLEXPRESS;Initial Catalog=CoffeePOSLite;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        private static readonly string connectionStringLocal = @"Data Source=.\SQLEXPRESS01;Initial Catalog=CoffeePOSLite;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            string currentMachineName = Environment.MachineName.ToUpper();

            if (currentMachineName == "ADMIN-PC")
            {
                return new SqlConnection(connectionStringLocal);
            }

            return new SqlConnection(connectionStringGroup);
        }


        
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
