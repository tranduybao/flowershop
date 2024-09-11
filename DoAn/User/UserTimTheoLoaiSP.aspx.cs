using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.User
{
    public partial class UserTimTheoLoaiSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MaLoaiSP"] != null)
            {
                string selectedValue = Request.QueryString["MaLoaiSP"];
                SqlDataSource1.SelectCommand = "select * from sanpham where maloaisp=\'" + selectedValue + "\'";
            }
        }
    }
}