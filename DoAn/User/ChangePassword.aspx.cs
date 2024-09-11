using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.User
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ChangePassword1_ChangingPassword(object sender, LoginCancelEventArgs e)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE TaiKhoan SET MK = @MK WHERE TK = @TK", conn);
                cmd.Parameters.AddWithValue("@MK", ChangePassword1.NewPassword);
                cmd.Parameters.AddWithValue("@TK", ChangePassword1.UserName);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                if (rowsAffected > 0)
                {

                    ChangePassword1.ChangePasswordFailureText = "Đổi mật khẩu thành công";
                }
                else
                {
                    ChangePassword1.ChangePasswordFailureText = "Đổi mật khẩu không thành công";
                }
            }
        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
            int MaKH = (int)Session["MaKH"];
            sendingMail(MaKH);
        }
        private void sendingMail(int MaKH)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(getMail(MaKH));
                mail.From = new MailAddress("2121010318@sv.ufm.edu.vn");
                mail.Subject = "Xác nhận thay đổi mật khẩu";
                mail.Body = "Mật khẩu của bạn đã được thay đổi thành công.";
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("2121010318@sv.ufm.edu.vn", "Rgf65672");
                client.Send(mail);
            }
            catch (SmtpFailedRecipientException ex)
            {

            }
        }
        private string getMail(int MaKH)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select email from khachhang where makh=" + MaKH, conn);
                conn.Open();
                string email = cmd.ExecuteScalar().ToString();
                conn.Close();
                return email;
            }
        }
    }
}