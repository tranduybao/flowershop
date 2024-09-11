<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasster.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="DoAn.User.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div style="width: 1247px">
        <table border="0">
            <tr>
                <td colspan="2" class="login-title">Thông tin khách hàng
                </td>
            </tr>
            <tr>
                <td>
                    <b>Họ tên:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtHoTen" runat="server" CssClass="CTSP"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Email:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="CTSP" OnTextChanged="txtEmail_TextChanged" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Số điện thoại:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtSDT" runat="server" CssClass="CTSP" OnTextChanged="txtSDT_TextChanged" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <b>Địa chỉ:</b>
                </td>
                <td>
                    <asp:TextBox ID="txtDiaChi" runat="server" CssClass="CTSP" OnTextChanged="txtDiaChi_TextChanged" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="hplLichSuDH" runat="server" NavigateUrl="~/User/CTDH.aspx">Xem lịch sử mua hàng</asp:HyperLink><br />
                    <asp:HyperLink ID="hplDoiMK" runat="server" NavigateUrl="~/User/ChangePassword.aspx">Đổi mật khẩu</asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lblThongBao" runat="server" CssClass="error" ></asp:Label><br />
                    <asp:Button ID="btnLuu" runat="server" Text="Lưu thay đổi" CssClass="button" OnClick="btnLuu_Click" /><asp:Button ID="btnBack" runat="server" Text="Trở về" CssClass="button" PostBackUrl="~/User/UserTrangChu.aspx?value=TrangChu" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
