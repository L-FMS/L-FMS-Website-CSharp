<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="L_FMS.Admin.Admin" %>

<!DOCTYPE html>
<html class='no-js' lang='en'>
  <head>
    <meta charset='utf-8'>
    <meta content='IE=edge,chrome=1' http-equiv='X-UA-Compatible'>
    <title>管理员登录 | 失物招领管理系统</title>

    <meta content='xxx' name='author'>
    <meta content='' name='description'>
    <meta content='' name='keywords'>

    <link href="assets/stylesheets/application-a07755f5.css" rel="stylesheet" type="text/css">
    <link href="assets/stylesheets/font-awesome.min.css" rel="stylesheet" type="text/css">
    
  </head>
  <body class='login'>
    <div class='wrapper'>
      <div class='row'>
        <div class='col-lg-12'>
          <div class='brand text-center'>
            <h1>
              <div class='logo-icon'>
                <i class='icon-home'></i>
              </div>
              后台管理
            </h1>
          </div>
        </div>
      </div>
      <div class='row'>
        <div class='col-lg-12'>
          <form runat="server" method="POST">
            <fieldset class='text-center'>
              <legend>管理员登录</legend>
              <div class='form-group'>
                <input class='form-control' placeholder='登录邮箱' name="email" type='email'>
              </div>
              <div class='form-group'>
                <input class='form-control' placeholder='密码' name="pwd" type='password'>
              </div>
              <div class='text-center'>
                <asp:Button CssClass="btn btn-default" runat="server" Text="登录" OnClick="Admin_Login" />
              </div>
            </fieldset>
          </form>
        </div>
      </div>
    </div>

    <!-- jQuery -->
    <script src="../js/jquery-2.0.3.min.js"></script>

    <script src="assets/javascripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src="assets/javascripts/modernizr.min.js" type="text/javascript"></script>
    <script src="assets/javascripts/application-985b892b.js" type="text/javascript"></script>

  </body>
</html>
