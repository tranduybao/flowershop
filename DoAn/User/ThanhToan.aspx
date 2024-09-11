<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasster.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="DoAn.User.ThanhToan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div style="width: 1247px">
        <asp:GridView ID="grdGioHang" runat="server"
            CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Double"
            BorderWidth="3px" GridLines="Horizontal" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MaSP" HeaderText="Mã Hàng">
                    <HeaderStyle Width="80px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TenSP" HeaderText="Tên Hàng">
                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Gia" HeaderText="Đơn Giá">
                    <HeaderStyle Width="130px" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng">
                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TongTien" HeaderText="Thành Tiền"
                    DataFormatString="{0:0,000}">
                    <HeaderStyle Width="100px" HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#3381f1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView><br />
        Chọn phương thức thanh toán:
        <asp:DropDownList ID="drpPTTT" runat="server">
            <asp:ListItem>Tiền mặt</asp:ListItem>
            <asp:ListItem>Chuyển khoản</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="lblTongTien" runat="server"></asp:Label><br />
        <asp:Button ID="btnThanhToan" runat="server" Text="Đặt hàng" OnClick="btnThanhToan_Click" CssClass="button" /><asp:Button ID="btnHuy" runat="server" Text="Huỷ" CssClass="button" PostBackUrl="~/User/GioHang.aspx" /><br />
        <asp:Panel ID="pnlThanhToanThanhCong" runat="server" Visible="False"> Đặt hàng thành công, nhấn vào <asp:HyperLink ID="hplCTDH" runat="server" NavigateUrl="~/User/CTDH.aspx">đây</asp:HyperLink> để xem lịch sử đơn hàng.</asp:Panel>
        <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
        </div>
</asp:Content>
