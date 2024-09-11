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

namespace DoAn.User
{
    public partial class ThanhToan : System.Web.UI.Page
    {
        KetNoi ketnoi = new KetNoi();
        Function func = new Function();
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        protected void LoadData()
        {
            dt = (DataTable)Session["GioHang"];

            grdGioHang.DataSource = dt;
            grdGioHang.DataBind();
            grdGioHang.Columns[0].ControlStyle.Width = 80;
            grdGioHang.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdGioHang.Columns[1].ControlStyle.Width = 200;
            grdGioHang.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdGioHang.Columns[2].ControlStyle.Width = 130;
            grdGioHang.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            grdGioHang.Columns[3].ControlStyle.Width = 150;
            grdGioHang.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdGioHang.Columns[4].ControlStyle.Width = 100;
            grdGioHang.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            if (dt != null)
            {
                double tong = (double)Session["tong"];
                lblTongTien.Text = "Tổng giá trị đơn hàng: " + String.Format("{0:0,000} VNĐ", tong);
            }
        }

        protected void btnThanhToan_Click(object sender, EventArgs e)
        {
            dt = (DataTable)Session["GioHang"];
            bool value = true;
            int ID = func.autoID("DonHang", "MaDH");
            int MaKH = (int)Session["MaKH"];
            int temp = Convert.ToInt32(Session["tong"]);
            decimal tong = (decimal)temp;
            string PTTT = drpPTTT.SelectedValue.ToString();
            TaoDonHang(ID, MaKH, tong, PTTT);
            foreach (DataRow row in dt.Rows)
            {
                TaoCTDH(ID, Convert.ToInt32(row["MaSP"]), MaKH, Convert.ToInt32(row["SoLuong"]), Convert.ToDecimal(row["TongTien"]));
                if (((func.getValue("MaSP", Convert.ToInt32(row["MaSP"])) - Convert.ToInt32(row["SoLuong"]))) < 0)
                {
                    ketnoi.InsertUpdateDelete("Delete from CTDH where MaDH=" + ID);
                    ketnoi.InsertUpdateDelete("Delete from DonHang where MaDH=" + ID);
                    lblError.Text = "Sản phẩm tồn kho không đủ";
                    value = false;
                    break;
                }
                else
                    ketnoi.InsertUpdateDelete("update SanPham set TonKho=TonKho-" + Convert.ToInt32(row["SoLuong"]) + " where MaSP=" + Convert.ToInt32(row["MaSP"]));
            }
            pnlThanhToanThanhCong.Visible = value;
            Session.Remove("GioHang");
        }
        private void TaoDonHang(int MaDH, int MaKH, decimal TongGiaTri, string PTTT)
        {
            DateTime currentDate = DateTime.Now;
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [DonHang] (MaDH, MaKH, NgayDatHang, TongGiaTri, PTTT) VALUES (@MaDH, @MaKH, @NgayDatHang, @TongGiaTri, @PTTT)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", MaDH);
                    cmd.Parameters.AddWithValue("@MaKH", MaKH);
                    cmd.Parameters.AddWithValue("@NgayDatHang", currentDate);
                    cmd.Parameters.AddWithValue("@TongGiaTri", TongGiaTri);
                    cmd.Parameters.AddWithValue("@PTTT", PTTT);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            sendingMail(MaKH, MaDH);
        }
        private void TaoCTDH(int MaDH, int MaSP, int MaKH, int SoLuong, decimal Gia)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [CTDH] (MaDH, MaSP, MaKH, SoLuong, Gia) VALUES (@MaDH, @MaSP,@MaKH, @SoLuong, @Gia)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", MaDH);
                    cmd.Parameters.AddWithValue("@MaSP", MaSP);
                    cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                    cmd.Parameters.AddWithValue("@Gia", (Gia / SoLuong));
                    cmd.Parameters.AddWithValue("@MaKH", MaKH);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        private void sendingMail(int MaKH, int MaDH)
        {
            string email;
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Email FROM KhachHang WHERE MaKH=@MaKH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", MaKH);
                    conn.Open();
                    email = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
            }
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("2121010318@sv.ufm.edu.vn");
                mail.Subject = "Đặt hàng thành công";
                mail.Body = "Đơn hàng có mã " + MaDH + " sẽ được giao đến bạn. Chúc bạn mua sắm vui vẻ. Xin cảm ơn!";
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
    }
}