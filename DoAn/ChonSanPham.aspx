<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChonSanPham.aspx.cs" Inherits="DoAn.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="CTSP" style="width: 1247px">
        <asp:Image ID="AnhSP" runat="server" />
        <br />
        <b>Tên sản phẩm:</b> <asp:Label ID="lblTenSP" runat="server" ></asp:Label>
        <br />
        <b>Đơn giá:</b> <asp:Label ID="lblSL" runat="server" ></asp:Label>
        <br />
        <b>Số lượng:</b> <asp:TextBox ID="txtSL" runat="server" Text="1" CssClass="CTSP" Width="126px"></asp:TextBox>
        <br />
        <asp:Button ID="btnDatHang" runat="server" Text="Thêm vào giỏ hàng" CssClass="button" OnClick="btnDatHang_Click" PostBackUrl="~/Login.aspx" /><asp:Button ID="btnHuy" runat="server" Text="Trở về" CssClass="button" PostBackUrl="~/TrangChu.aspx" />
    </div>
</asp:Content>
