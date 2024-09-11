using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        KetNoi ketnoi = new KetNoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["MaSP"] != null)
                {
                    string selectedMaSP = Request.QueryString["MaSP"];
                    Session["MaSP"] = selectedMaSP;
                    load(selectedMaSP);
                }
            }
        }
        protected void load(string MaSP)
        {
            DataTable dt = ketnoi.Select("Select * from sanpham where masp=\'" + MaSP + "\'");
            foreach (DataRow row in dt.Rows)
            {
                AnhSP.ImageUrl = row["Anh"].ToString();
                lblTenSP.Text = row["TenSP"].ToString();
                lblSL.Text = row["Gia"].ToString();
                ViewState["SanPham"] = dt;
            }
        }
        protected void btnDatHang_Click(object sender, EventArgs e)
        {

        }
    }
}

