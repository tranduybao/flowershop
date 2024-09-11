using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn
{
    public class KetNoi
    {
        //public SqlConnection Conn(string chuoi)
        //{
        //    SqlConnection conn = new SqlConnection(chuoi);
        //    return conn;
        //}
        string conn = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";
        public void InsertUpdateDelete(string query)
        {
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
        public DataTable Select(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter laydulieu = new SqlDataAdapter(cmd);
                laydulieu.Fill(data);
                sqlConn.Close();
            }
            return data;
        }
    }
}