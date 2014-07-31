<%@ Page Title="找回密码 | 失物招领管理系统" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="FindPasswordNewPassword.aspx.cs" Inherits="L_FMS.FindPasswordNewPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
    <webopt:bundlereference runat="server" path="~/stylesheets/FindPassword" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    
    <main class="login-screen" "padding-top: 200px; padding-bottom: 200px"  >
    <div class="login-icon">
      <img src="images/login/icon.png" alt="Welcome th L&FMS">
      <h4>Welcome to <small>L&FMS</small></h4>
    </div>

    <form class="login-form" name="signupForm"  method="POST" runat="server">
      <%-- 账号信息 --%>
      <fieldset>
        <legend>更改新密码</legend>

        <%-- 密码 --%>
        <div class="form-group">
          <label for="register-pass" style="color: #bfc9ca;">密码</label>
          <input type="password" class="form-control login-field" placeholder="请输入您的密码" id="register-pass1" name="pwd" required>
          <label for="register-pass" class="login-field-icon fui-lock"></label>
        </div>

        <%-- 重复输入密码 --%>
        <div class="form-group">
          <label for="register-pass2" style="color: #bfc9ca;">重复输入密码</label>
          <input type="password" class="form-control login-field" placeholder="请再次输入您的密码" id="register-pass2" name="pwd-validate" required>
          <label for="register-pass2" class="login-field-icon fui-lock"></label>
        </div>
      </fieldset>
      
      <asp:Button runat="server" OnClick="Change_Password" Text="确认更改" CssClass="btn btn-primary btn-lg btn-block" />
    </form>
        </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
      <%: Scripts.Render("~/scripts/BootstrapSelect") %>
  <script type="text/javascript">
    $("select").selectpicker({ style: 'btn-hg btn-primary', menuStyle: 'dropdown-inverse' });
  </script>
</asp:Content>
