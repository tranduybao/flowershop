using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace DoAn.User
{
    public partial class UserProfile : System.Web.UI.Page
    {
        KetNoi ketnoi = new KetNoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MaKH"] != null)
                {
                    int MaKH = (int)Session["MaKH"];
                    string query = "select * from khachhang where makh=" + MaKH;
                    DataTable dt = ketnoi.Select(query);
                    foreach (DataRow row in dt.Rows)
                    {
                        MaKH = (int)row["MaKH"];
                        txtHoTen.Text = row["HoTenKH"].ToString();
                        txtEmail.Text = row["Email"].ToString();
                        txtSDT.Text = row["SDT"].ToString();
                        txtDiaChi.Text = row["DiaChi"].ToString();
                    }
                }
                else
                    Server.Transfer("~/Login.aspx");

            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            int MaKH = (int)Session["MaKH"];
            changeUserEmail(MaKH, txtEmail.Text, lblThongBao);
            changeKHEmail(MaKH, txtHoTen.Text, txtEmail.Text, txtSDT.Text, txtDiaChi.Text, lblThongBao);
            sendingMail(txtEmail.Text, lblThongBao);
        }
        private void sendingMail(string email, Label lblThongBao)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("2121010318@sv.ufm.edu.vn");
                mail.Subject = "Thông báo thay đổi thông tin";
                mail.Body = "Thay đổi thông tin thành công. Email hiện tại của bạn là " + email + ". Chúc bạn mua sắm vui vẻ. Xin cảm ơn!";
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("2121010318@sv.ufm.edu.vn", "Rgf65672");
                client.Send(mail);
            }
            catch (SmtpFailedRecipientException ex)
            {
                lblThongBao.Text = "Mail gửi không thành công! " + ex.FailedRecipient;
            }
        }
        private void changeUserEmail(int userID, string email, Label lblThongBao)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "update TaiKhoan set Email = @Email where UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAffected > 0)
                        lblThongBao.Text = "Lưu thành công";
                    else
                        lblThongBao.Text = "Lưu thất bại";
                }
            }
        }
        private void changeKHEmail(int MaKH, string HoTen, string email, string sdt, string diachi, Label lblThongBao)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "update KhachHang set HoTenKH=@HoTenKH, Email = @Email, SDT = @SDT, DiaChi = @DiaChi where MaKH = @MaKH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", MaKH);
                    cmd.Parameters.AddWithValue("@HoTenKH", HoTen);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("DiaChi", diachi);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAffected > 0)
                        lblThongBao.Text = "Lưu thành công";
                    else
                        lblThongBao.Text = "Lưu thất bại";
                }
            }
        }
    }
}