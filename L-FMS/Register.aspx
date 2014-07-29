<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="L_FMS.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
     <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Login" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
  <main class="login-screen">
    <div class="login-icon">
      <img src="images/login/icon.png" alt="Welcome th L&FMS">
      <h4>Please finish your personal infomation</h4>
    </div>
    <form class="login-form" name="signupForm" action="" method="POST">
      <div class="form-group">
        <input type="text" class="form-control login-field" placeholder="Enter your Name" id="login-name" name="name" required autofocus>
        <label for="login-name" class="login-field-icon fui-user"></label>
      </div>

      <div class="form-group">
        <input type="tel" class="form-control login-field" placeholder="Enter your phone" id="login-phone" name="phone">
        <label for="login-phone" class="login-field-icon fui-user"></label>
      </div>

      <div class="form-group">
        <input type="number" class="form-control login-field" placeholder="Enter your student ID" id="login-stuID" required>
        <label for="login-stuID" class="login-field-icon fui-user"></label>
      </div>

      <div class="form-group">
        <input type="text" class="form-control login-field" placeholder="Enter your username" id="login-username" required>
        <label for="login-username" class="login-field-icon fui-user"></label>
      </div>

      <div class="form-group">
        <input type="password" class="form-control login-field" placeholder="Password" id="login-pass" required>
        <label for="login-pass" class="login-field-icon fui-lock"></label>
      </div>

      <button type="submit" class="btn btn-primary btn-lg btn-block">Sign up</button>
        
    </form>
  </main>
</asp:Content>

