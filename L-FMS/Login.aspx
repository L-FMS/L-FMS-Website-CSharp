﻿<%@ Page Title="登录 | 失物招领管理系统" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="L_FMS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
    <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Login" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <main class="login-screen">
        <div class="login-icon">
            <img src="images/icons/svg/mail.svg" alt="Welcome th L&FMS">
            <h4>Welcome to <small>L&FMS</small></h4>
        </div>
        <form class="login-form" name="loginForm" action="" method="POST" runat="server">
            <div class="form-group">
                <input type="email" class="form-control login-field" name="email" placeholder="登录邮箱" id="login-email" required autofocus>
                <label for="login-email" class="login-field-icon fui-user"></label>
            </div>
            <div class="form-group">
                <input type="password" class="form-control login-field" name="pwd" placeholder="密码" id="login-pass" required>
                <label for="login-pass" class="login-field-icon fui-lock"></label>
            </div>
            <asp:Button CssClass="btn btn-primary btn-lg btn-block" runat="server" OnClick="buttonSubmit"  Text="登录"  />
            <a runat="server" href="~/FindPasswordLogin.aspx" class="login-link">忘记密码?</a>
            <a runat="server" href="~/Register.aspx" class="login-link">没有账号？现在注册</a>
        </form>
    </main>
</asp:Content>

