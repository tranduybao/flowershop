<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Manager.Master" AutoEventWireup="true" CodeBehind="SuaXoa.aspx.cs" Inherits="DoAn.admin.Them" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div style="width: 1247px">
        <div class="login-title">
            Sửa, xoá sản phẩm<br />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MaSP" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField CancelText="Trở về" DeleteText="Xoá" EditText="Sửa" SelectText="Chọn" ShowEditButton="True" UpdateText="Cập nhật" />
                <asp:CommandField CancelText="Trờ lại" DeleteText="Xoá" EditText="Sửa" ShowDeleteButton="True" UpdateText="Cập nhật" />
                <asp:BoundField DataField="MaSP" HeaderText="Mã sản phẩm" ReadOnly="True" SortExpression="MaSP" InsertVisible="False" />
                <asp:BoundField DataField="TenSP" HeaderText="Tên sản phẩm" SortExpression="TenSP" />
                <asp:BoundField DataField="Gia" HeaderText="Đơn giá" SortExpression="Gia" />
                <asp:BoundField DataField="Tonkho" HeaderText="Số lượng" SortExpression="Tonkho" />
                <asp:BoundField DataField="MaLoaiSP" HeaderText="Mã loại" SortExpression="MaLoaiSP" />
                <asp:BoundField DataField="MaDVT" HeaderText="Mã đơn vị tính" SortExpression="MaDVT" />
                <asp:BoundField DataField="Anh" HeaderText="Ảnh" SortExpression="Anh" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShopHoaConnectionString %>" SelectCommand="SELECT * FROM [SanPham]" DeleteCommand="DELETE FROM [SanPham] WHERE [MaSP] = @MaSP" InsertCommand="INSERT INTO [SanPham] ([TenSP], [Gia], [Tonkho], [MaLoaiSP], [MaDVT], [Anh]) VALUES (@TenSP, @Gia, @Tonkho, @MaLoaiSP, @MaDVT, @Anh)" UpdateCommand="UPDATE [SanPham] SET [TenSP] = @TenSP, [Gia] = @Gia, [Tonkho] = @Tonkho, [MaLoaiSP] = @MaLoaiSP, [MaDVT] = @MaDVT, [Anh] = @Anh WHERE [MaSP] = @MaSP">
            <DeleteParameters>
                <asp:Parameter Name="MaSP" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="TenSP" Type="String" />
                <asp:Parameter Name="Gia" Type="Decimal" />
                <asp:Parameter Name="Tonkho" Type="Int32" />
                <asp:Parameter Name="MaLoaiSP" Type="String" />
                <asp:Parameter Name="MaDVT" Type="String" />
                <asp:Parameter Name="Anh" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="TenSP" Type="String" />
                <asp:Parameter Name="Gia" Type="Decimal" />
                <asp:Parameter Name="Tonkho" Type="Int32" />
                <asp:Parameter Name="MaLoaiSP" Type="String" />
                <asp:Parameter Name="MaDVT" Type="String" />
                <asp:Parameter Name="Anh" Type="String" />
                <asp:Parameter Name="MaSP" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
