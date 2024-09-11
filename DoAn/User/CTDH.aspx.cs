using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.User
{
    public partial class CTDH : System.Web.UI.Page
    {
        KetNoi ketnoi = new KetNoi();
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int MaKH = (int)Session["MaKH"];
            if (!IsPostBack)
            {
                dt = ketnoi.Select("select DH.MaDH, TenSP, CTDH.Gia, SoLuong, NgayDatHang, (CTDH.Gia*SoLuong) as TongTien from CTDH join SanPham sp on CTDH.MaSP=sp.MaSP inner join DonHang DH on DH.MaDH=CTDH.MaDH where DH.MaKH=" + MaKH+" order by NgayDatHang");
                grdCTDH.DataSource = dt;
                grdCTDH.DataBind();
                grdCTDH.Columns[0].ControlStyle.Width = 80;
                grdCTDH.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                grdCTDH.Columns[1].ControlStyle.Width = 200;
                grdCTDH.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                grdCTDH.Columns[2].ControlStyle.Width = 130;
                grdCTDH.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                grdCTDH.Columns[3].ControlStyle.Width = 150;
                grdCTDH.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                grdCTDH.Columns[4].ControlStyle.Width = 150;
                grdCTDH.Columns[4].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                grdCTDH.Columns[5].ControlStyle.Width = 100;
                grdCTDH.Columns[5].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            }
        }
    }
}