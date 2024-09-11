using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;


namespace DoAn
{
    public partial class register : System.Web.UI.Page
    {
        Function func = new Function();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int ID = func.autoID("TaiKhoan", "UserID");
            string TK = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string phone = txtPhonenumber.Text;
            string fullName = txtFullName.Text;
            string DiaChi = txtDiaChi.Text;
            if (func.isValueExist("TK", TK))
            {
                lblRegisterError.Text = "Tài khoàn đã tồn tại";
            }
            else if (func.isValueExist("email", email))
            {
                lblRegisterError.Text = "Email đã tồn tại";
            }
            else
            {
                AddAccountInfoToDatabase(ID, TK, password, email);
                AddUserInfoToDatabase(ID, fullName, email, phone, DiaChi);
                sendingMail(email, TK, lblRegisterError);
            }
        }
        private void sendingMail(string email, string TK, Label lblRegisterError)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("2121010318@sv.ufm.edu.vn");
                mail.Subject = "Đăng ký thành công";
                mail.Body = "Bạn đã đăng ký thành công tài khoản "+ TK + ". Chúc bạn mua sắm vui vẻ. Xin cảm ơn!";
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("2121010318@sv.ufm.edu.vn", "Rgf65672");
                client.Send(mail);
            }
            catch (SmtpFailedRecipientException ex)
            {
                lblRegisterError.Text = "Mail gửi không thành công! " + ex.FailedRecipient;
            }
        }



        private void AddAccountInfoToDatabase(int UserID, string username, string password, string email)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True"; // Thay thế YourConnectionString b
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [TaiKhoan] (UserID, TK, MK, email) VALUES (@UserID, @Username, @password, @email)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        lblRegisterError.Text = "Tạo tài khoản thành công, vui lòng vào trang đăng nhập để đăng nhập";
                    }
                    else
                    {
                        lblRegisterError.Text = "Tạo tài khoản thất bại";
                    }
                }
            }
        }
        private void AddUserInfoToDatabase(int MaKH, string HoTenKH, string Email, string SDT, string DiaChi)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO KhachHang (MaKH, HoTenKH, Email, SDT, DiaChi, UserID) VALUES (@MaKH, @HoTenKH, @Email, @SDT, @DiaChi, @UserID);";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@MaKH", MaKH);
                    command.Parameters.AddWithValue("@HoTenKH", HoTenKH);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@SDT", SDT);
                    command.Parameters.AddWithValue("DiaChi", DiaChi);
                    command.Parameters.AddWithValue("UserID", MaKH);
                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        lblRegisterError.Text = "Tạo tài khoản thất bại";
                    }
                }
            }
        }
    }
}