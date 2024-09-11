using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFind.Attributes["placeholder"] = "Tìm kiếm";
        }

        protected void menuDanhMucSP_MenuItemClick(object sender, MenuEventArgs e)
        {
            
        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            string TenSP = txtFind.Text;
            Server.Transfer("TrangChu.aspx?value=" + TenSP);
        }
    }
}