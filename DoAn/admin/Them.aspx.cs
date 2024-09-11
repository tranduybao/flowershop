using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Function func = new Function();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void butAdd_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=ShopHoa;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = new SqlCommand("SELECT * FROM SanPham", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            string strFileUpload = "";
            try
            {
                if (upHinh.HasFile)
                {
                    strFileUpload = "~/image/" + upHinh.FileName;
                    string path = MapPath("/Image/") + upHinh.FileName;
                    upHinh.PostedFile.SaveAs(path);
                }
                adapt.InsertCommand = new SqlCommand("INSERT INTO SanPham VALUES (@TenSP, @Gia, @TonKho, @MaLoaiSP, @MaDVT, @Anh)", con);
                adapt.InsertCommand.Parameters.AddWithValue("@TenSP", txtTenSP.Text);
                adapt.InsertCommand.Parameters.AddWithValue("@MaDVT", drpDVT.SelectedValue);
                adapt.InsertCommand.Parameters.AddWithValue("@Gia", Convert.ToDecimal(txtDonGia.Text));
                adapt.InsertCommand.Parameters.AddWithValue("@MaLoaiSP", drpLoai.SelectedValue);
                adapt.InsertCommand.Parameters.AddWithValue("@Anh", strFileUpload);
                adapt.InsertCommand.Parameters.AddWithValue("@TonKho", Convert.ToInt32(txtTonKho.Text));
                DataRow row = dt.NewRow();
                row["MaSP"] = func.autoID("SanPham", "MaSP");
                row["TenSP"] = "@TenSP";
                row["Gia"] = Convert.ToDecimal(txtDonGia.Text);
                row["TonKho"] = Convert.ToInt32(txtTonKho.Text);
                row["MaLoaiSP"] = "MaLoaiSP";
                row["MaDVT"] = "@MaDVT";
                row["Anh"] = "@Anh";
                dt.Rows.Add(row);
                adapt.Update(dt);
                lblStatus.Text = "Thêm thành công!";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }
}