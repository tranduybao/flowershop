using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace DoAn
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName;
            string password = Login1.Password;
            if (ValidateUser(username, password))
            {
                e.Authenticated = true;
                Session["UserID"] = getUserID(username);
            }
            else
            {
                e.Authenticated = false;
            }
        }
        private bool ValidateUser(string username, string password)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT count(*) FROM TaiKhoan WHERE TK = @Username AND MK = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    connection.Close();

                    return count > 0;
                }
            }

        }
        private int getUserID(string username)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT userID FROM TaiKhoan WHERE TK = @Username";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    int userID = (int)command.ExecuteScalar();
                    conn.Close();

                    return userID;
                }
            }
        }
    }
}