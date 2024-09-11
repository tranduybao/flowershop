<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMasster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="DoAn.User.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" OnChangingPassword="ChangePassword1_ChangingPassword" CancelButtonText="Trờ về" CancelDestinationPageUrl="~/User/UserTrangChu.aspx" ChangePasswordButtonText="Đổi mật khẩu" ChangePasswordTitleText="Đổi mật khẩu" ConfirmNewPasswordLabelText="Xác nhận mật khẩu mới" ConfirmPasswordCompareErrorMessage="Xác nhận mật khẩu phải trùng với mật khẩu mới!" NewPasswordLabelText="Mật khẩu mới:" NewPasswordRegularExpressionErrorMessage="Vui lòng nhập mật khẩu khác mật khẩu cũ" OnChangedPassword="ChangePassword1_ChangedPassword" PasswordLabelText="Mật khẩu hiện tại:"  >
        <CancelButtonStyle CssClass="button" />
        <ChangePasswordButtonStyle CssClass="button" />
        <FailureTextStyle CssClass="error" />
        <TitleTextStyle CssClass="login-title" />
</asp:ChangePassword>
</asp:Content>
