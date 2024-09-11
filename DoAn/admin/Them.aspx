<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Manager.Master" AutoEventWireup="true" CodeBehind="Them.aspx.cs" Inherits="DoAn.admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div>
        <div class="login-title">Thêm sản phẩm<br />
        </div>
        <div>
            <table style="width: 100%; font-size: 14px; color: #0033CC;">

                <tr>
                    <td style="width: 20%">Tên sản phẩm</td>
                    <td>
                        <asp:TextBox ID="txtTenSP" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td>Đơn vị tính:</td>
                    <td>
                        <asp:DropDownList ID="drpDVT" runat="server"
                            DataSourceID="srcDVT" DataTextField="TenDVT" DataValueField="MaDVT">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="srcDVT" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ShopHoaConnectionString %>"
                            SelectCommand="SELECT * FROM [DVT]"></asp:SqlDataSource>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Đơn giá:</td>
                    <td>
                        <asp:TextBox ID="txtDonGia" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td>Loại sản phẩm:</td>
                    <td>
                        <asp:DropDownList ID="drpLoai" runat="server"
                            DataSourceID="srcLoaiHang"
                            DataTextField="TenLoaiSP"
                            DataValueField="MaLoaiSP">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="srcLoaiHang" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ShopHoaConnectionString %>"
                            SelectCommand="SELECT * FROM [LoaiSP]"></asp:SqlDataSource>
                    </td>
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td>Hình sản phẩm</td>
                    <td>
                        <asp:FileUpload ID="upHinh" runat="server" ForeColor="#000099" />
                    </td>
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td>Số lượng:</td>
                    <td>
                        <asp:TextBox ID="txtTonKho" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td>&nbsp; </td>
                    <td>
                        <asp:Button ID="butAdd" runat="server" Text="Thêm" OnClick="butAdd_Click" ForeColor="#000099" />
                        <asp:Button ID="butCancel" runat="server" Text="Hủy Bỏ" ForeColor="#000099" PostBackUrl="~/admin/Manager.aspx" />
                    </td>
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td>&nbsp; </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Style="font-size: 14px; color: #0033CC"></asp:Label>
                    </td>
                    <td>&nbsp; </td>
                </tr>
                <tr>
                    <td>&nbsp; </td>
                    <td>&nbsp; </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
