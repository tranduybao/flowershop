<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasster.Master" AutoEventWireup="true" CodeBehind="UserChonSanPham.aspx.cs" Inherits="DoAn.User.UserChonSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="CTSP" style="width: 1247px">
        <asp:Image ID="AnhSP" runat="server" />
        <br />
        <b>Tên sản phẩm:</b>
        <asp:Label ID="lblTenSP" runat="server"></asp:Label>
        <br />
        <b>Đơn giá:</b>
        <asp:Label ID="lblSL" runat="server"></asp:Label>
        <br />
        <b>Số lượng:</b>
        <asp:TextBox ID="txtSL" runat="server" Text="1" CssClass="CTSP" Width="126px" OnTextChanged="txtSL_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="lblThanhCong" runat="server"></asp:Label><br />
        <asp:Button ID="btnDatHang" runat="server" Text="Thêm vào giỏ hàng" CssClass="button" OnClick="btnDatHang_Click" /><asp:Button ID="btnGioHang" runat="server" Text="Giỏ hàng" CssClass="button" PostBackUrl="~/User/GioHang.aspx" />
    </div>
</asp:Content>
