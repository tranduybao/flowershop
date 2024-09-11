<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasster.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="DoAn.User.GioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div style="width: 1247px">
        <asp:GridView ID="grdGioHang" runat="server"
            OnRowDeleting="grdGioHang_RowDeleting" OnRowEditing="grdGioHang_RowEditing"
            OnRowUpdating="grdGioHang_RowUpdating"
            OnRowCancelingEdit="grdGioHang_RowCancelingEdit" AutoGenerateColumns="False"
            CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Double"
            BorderWidth="3px" GridLines="Horizontal">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" CancelText="Hủy Bỏ" DeleteText="Xóa" EditText="Sửa" UpdateText="Cập nhật">
                    <HeaderStyle Width="90px" />
                </asp:CommandField>
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
        </asp:GridView>
        <asp:Label ID="lblTongTien" runat="server"></asp:Label><br />
        <asp:Button ID="btnTiepTuc" runat="server" Text="Tiếp tục mua sắm" PostBackUrl="~/User/UserTrangChu.aspx?value=TrangChu" CssClass="button" Width="200px" /><asp:Button ID="btnThanhToan" runat="server" Text="Đặt hàng" PostBackUrl="~/User/ThanhToan.aspx" CssClass="button" />
    </div>
</asp:Content>
