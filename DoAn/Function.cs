using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAn
{
    public class Function
    {

        public int autoID(string table, string col)
        {
            KetNoi ketnoi = new KetNoi();
            int lastID = 0;
            DataTable dt = ketnoi.Select("SELECT top(1) " + col + " FROM " + table + " ORDER BY " + col + " desc");
            foreach (DataRow row in dt.Rows)
            {
                lastID = (int)row[col];
            }
            return lastID + 1;
        }
        public bool isValueExist(string col, string value)
        {
            string valueCheck = value;
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE " + col + " = @value";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@value", value);
                    int count = (int)command.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }

        }
        public int getValue(string col, int id) 
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TonKho FROM SanPham WHERE " + col + " = @value";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@value", id);
                    int value = (int)command.ExecuteScalar();
                    conn.Close();
                    return value;
                }
            }
        }
    }
}