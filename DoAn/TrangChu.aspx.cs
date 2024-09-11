using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.RemoveAll();
            if (Request.QueryString["value"] == null)
            {
                sqlDSSP.SelectCommand = "Select * from SanPham";
            }
            else if (Request.QueryString["value"] == "TrangChu")
            {
                sqlDSSP.SelectCommand = "Select * from SanPham";
            }
            else
            {
                string tenSP = Request.QueryString["value"].ToString();
                sqlDSSP.SelectCommand = "Select * from SanPham where TenSP like N\'%" + tenSP + "%\'";
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = e.Item.DataItem as DataRowView;
                int SoLuong = Convert.ToInt32(drv["TonKho"]);
                if (SoLuong <= 0)
                {
                    e.Item.Enabled = false;
                }
            }
        }
    }
}