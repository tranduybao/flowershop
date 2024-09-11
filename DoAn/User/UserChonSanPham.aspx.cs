using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace DoAn.User
{
    public partial class UserChonSanPham : System.Web.UI.Page
    {
        KetNoi ketnoi = new KetNoi();
        DataTable cart = new DataTable();
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
                Session["MaSP"] = int.Parse(row["MaSP"].ToString());
                AnhSP.ImageUrl = row["Anh"].ToString();
                lblTenSP.Text = row["TenSP"].ToString();
                lblSL.Text = row["Gia"].ToString();
                ViewState["SanPham"] = dt;
            }

        }

        protected void btnDatHang_Click(object sender, EventArgs e)
        {
            DataTable dtSP = (DataTable)ViewState["SanPham"];
            DataTable dtGH;     // Gio hang
            int Soluong = 0;
            if (Session["GioHang"] == null)    // tao gio hang
            {
                dtGH = new DataTable();
                dtGH.Columns.Add("MaSP");
                dtGH.Columns.Add("TenSP");
                dtGH.Columns.Add("Gia");
                dtGH.Columns.Add("SoLuong");
                dtGH.Columns.Add("TongTien");
            }
            else // lay gio hang tu Session
                dtGH = (DataTable)Session["GioHang"];
            int masp = (int)Session["MaSP"];
            int pos = TimSP(masp, dtGH);        // tim vi tri san pham trong gio hang
            if (pos != -1)  // neu tim thay tai vi tri pos
            {
                //cap nhat lai cot so luong, tong tien
                Soluong = Convert.ToInt32(dtGH.Rows[pos]["SoLuong"]) + int.Parse(txtSL.Text);
                dtGH.Rows[pos]["SoLuong"] = Soluong;
                dtGH.Rows[pos]["TongTien"] = Convert.ToDouble(dtSP.Rows[0]["Gia"]) * Soluong;
            }
            else    //san pham chua co trong gio hang: Them vao gio hang
            {
                Soluong = int.Parse(txtSL.Text);
                DataRow dr = dtGH.NewRow();//tạo một dòng mới
                                           // gán dữ liệu cho từng cột trong dòng mới
                dr["MaSP"] = dtSP.Rows[0]["MaSP"];
                dr["TenSP"] = dtSP.Rows[0]["TenSP"];
                dr["Gia"] = dtSP.Rows[0]["Gia"];
                dr["SoLuong"] = int.Parse(txtSL.Text);
                dr["TongTien"] = Convert.ToDouble(dtSP.Rows[0]["Gia"]) * Soluong;
                //thêm dòng mới vào giỏ hàng
                dtGH.Rows.Add(dr);
            }
            //lưu gio hang vao session
            Session["GioHang"] = dtGH;
            lblThanhCong.Text = "Thêm thành công!";
        }
        public static int TimSP(int masp, DataTable dt)
        {
            int pos = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["MaSP"].ToString()) == masp)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
        protected void txtSL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}