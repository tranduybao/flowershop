<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="DoAn.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div style="width: 1247px">
        <br />
        <asp:Label ID="lblDangKy" runat="server" Text="Đăng ký" CssClass="login-title"></asp:Label>
        <br />
        <br />
        <table class="textbox">
            <tr>
                <td><b>Tên đăng nhập:</b></td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Tên đăng nhập" CssClass="textboxDK" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtUsername" CssClass="error">Tên đăng nhập không được để trống!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><b>Mật khẩu:</b></td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Mật khẩu" CssClass="textboxDK" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="RequiredFieldValidator" CssClass="error" ControlToValidate="txtPassword">Mật khẩu không được để trống!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><b>Nhập lại mật khẩu:</b></td>
                <td>
                    <asp:TextBox ID="txtNhapLaiMK" runat="server" TextMode="Password" placeholder="Nhập lại mật khẩu" CssClass="textboxDK" />
                </td>

            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:CompareValidator ID="cvNhapLaiMK" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtNhapLaiMK" CssClass="error">Mật khẩu nhập lại phải trùng với mật khẩu!</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td><b>Họ tên:</b></td>
                <td>
                    <asp:TextBox ID="txtFullName" runat="server" placeholder="Họ tên" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><b>Email:</b></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" />
                </td>

            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail" CssClass="error">Email không được để trống!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><b>Số điện thoại:</b></td>
                <td>
                    <asp:TextBox ID="txtPhonenumber" runat="server" placeholder="Số điện thoại" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><b>Địa chỉ:</b></td>
                <td>
                    <asp:TextBox ID="txtDiaChi" runat="server" placeholder="Địa chỉ" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblRegisterError" runat="server" CssClass="error"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" OnClick="btnRegister_Click" CssClass="button" />
    </div>
</asp:Content>
