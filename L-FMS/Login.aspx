﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="L_FMS.Login" %>
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
      <form class="login-form" name="loginForm" action="" method="POST">
        <div class="form-group">
          <input type="text" class="form-control login-field" placeholder="Enter your username" id="login-username" required autofocus>
          <label for="login-username" class="login-field-icon fui-user"></label>
        </div>
        <div class="form-group">
          <input type="password" class="form-control login-field" placeholder="Password" id="login-pass" required>
          <label for="login-pass" class="login-field-icon fui-lock"></label>
        </div>
        <button type="submit" class="btn btn-primary btn-lg btn-block">Log in</button>
        <a href="#" class="login-link">Lost your password?</a>
      </form>
    </main>
</asp:Content>
