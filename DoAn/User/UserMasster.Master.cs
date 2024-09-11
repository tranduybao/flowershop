using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace DoAn.User
{
    public partial class UserMasster : System.Web.UI.MasterPage
    {
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                int userID = (int)Session["UserID"];
                hplUserInfor.Text = "Xin chào " + getUsername(userID) + "!";
                Session["MaKH"] = userID;
            }
            txtFind.Attributes["placeholder"] = "Tìm kiếm";
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            loadGiohang();
        }
        protected void menuDanhMucSP_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
        private string getUsername(int userID)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TK FROM TaiKhoan WHERE UserID=@UserID";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    conn.Open();
                    string username = (string)command.ExecuteScalar();
                    conn.Close();

                    return username;
                }
            }
        }
        private void loadGiohang()
        {
            if (Session["GioHang"] != null)
            {
                dt = (DataTable)Session["GioHang"];
                lbSoluong.Text = dt.Rows.Count.ToString();
            }
            else
                lbSoluong.Text = "0";
        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            string TenSP = txtFind.Text;
            Server.Transfer("UserTrangChu.aspx?value=" + TenSP);
        }

        protected void lbtDangXuat_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/TrangChu.aspx");
        }
    }
}