<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasster.Master" AutoEventWireup="true" CodeBehind="UserTrangChu.aspx.cs" Inherits="DoAn.User.TrangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content" style="width: 1247px">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="sqlDSSP" Width="1246px" BorderColor="White" CellSpacing="-1" RepeatColumns="5" BackColor="White" OnItemDataBound="DataList1_ItemDataBound">
        <ItemTemplate>
            <td runat="server" class="list-item">
                <asp:Image ID="AnhSP" runat="server" ImageUrl='<%# Eval("Anh") %>' class="custom-image" />
                <br />
                <asp:HyperLink ID="linkSP" runat="server"
                    NavigateUrl='<%# "~/User/UserChonSanPham.aspx?MaSP=" + Eval("MaSP") %>' Text='<%# Eval("TenSP") %>' />
                <br />
                Giá:
                <asp:Label ID="GiaLabel" runat="server" CssClass="gia" Text='<%# Eval("Gia","{0:0,000 vnđ}") %>' />
                <br />
                Còn lại:
                <asp:Label ID="TonkhoLabel" runat="server" Text='<%# Eval("Tonkho") %>' />
                <br />
                <asp:Button ID="btnMuaHang" runat="server" PostBackUrl='<%# "UserChonSanPham.aspx?MaSP=" + Eval("MaSP") %>' CssClass="button" Text="Mua hàng" />
            </td>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="sqlDSSP" runat="server" ConnectionString="<%$ ConnectionStrings:ShopHoaConnectionString %>" SelectCommand="SELECT * FROM [SanPham]"></asp:SqlDataSource>
</div>
</asp:Content>
