<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasster.Master" AutoEventWireup="true" CodeBehind="CTDH.aspx.cs" Inherits="DoAn.User.CTDH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div style="width: 1247px">
        <div class="login-title">Lịch sử mua hàng:</div>
        <br />
        <asp:GridView ID="grdCTDH" runat="server"
            CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Double"
            BorderWidth="3px" GridLines="Horizontal" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MaDH" HeaderText="Mã Đơn Hàng">
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
                <asp:BoundField DataField="NgayDatHang" HeaderText="Ngày đặt hàng"
                    DataFormatString="{0:dd/MM/yyyy}">
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
        </asp:GridView>
    </div>
</asp:Content>
