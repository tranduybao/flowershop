<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DoAn.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="login" style="width: 1247px">
        <div class="CTSP">
            <asp:Login ID="Login1" runat="server" FailureText="Tên tài khoản hoặc mật khẩu không chính xác!" LoginButtonText="Đăng nhập" PasswordLabelText="Mật khẩu:" PasswordRequiredErrorMessage="Mật khẩu sai" RememberMeSet="True" RememberMeText="Lưu mật khẩu" TitleText="Đăng nhập" UserNameLabelText="Tài khoản:" UserNameRequiredErrorMessage="Tài khoản không đúng" BorderStyle="Solid" CreateUserText="Đăng ký" CreateUserUrl="~/register.aspx" DestinationPageUrl="~/User/UserTrangChu.aspx" OnAuthenticate="Login1_Authenticate" Width="550px" OnKeyPress="return event.keyCode != 13;">
                <LoginButtonStyle CssClass="button" />
                <TitleTextStyle CssClass="login-title" />
            </asp:Login>
        </div>
    </div>
</asp:Content>
