using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.User
{
    public partial class UserTimTheoDVT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["value"] != null)
            {
                string selectedValue = Request.QueryString["value"];
                SqlDataSource1.SelectCommand = "select * from sanpham where madvt=\'" + selectedValue + "\'";
            }
        }
    }
}