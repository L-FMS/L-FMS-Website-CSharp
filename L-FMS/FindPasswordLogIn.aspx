<%@ Page Title="找回密码 | 失物招领管理系统" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="FindPasswordLogIn.aspx.cs" Inherits="L_FMS.FindPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
    <webopt:bundlereference runat="server" path="~/stylesheets/FindPassword" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <main class="login-screen">
    <div class="login-icon">
      <img src="images/login/icon.png" alt="Welcome th L&FMS">
      <h4>Welcome to <small>L&FMS</small></h4>
    </div>

      <form class="login-form" name="securityForm" method="POST" runat="server">
          
      <%-- 获得邮箱 --%>
      <fieldset>
        <legend>验证信息</legend>
        <%-- 邮箱输入 --%>
        <div class="form-group">
          <label for="register-email" style="color: #bfc9ca;">邮箱</label>
          <input type="email" class="form-control login-field" placeholder="输入您的邮箱" id="register-email" name="email" required autofocus>
          <label for="register-email" class="login-field-icon fui-user"></label>
        </div>
        <asp:Button CssClass="btn btn-primary btn-lg btn-block" runat="server" OnClick="Submit_Email"  Text="提交"  />
       <a runat="server" href="~/Login.aspx" class="login-link">记起密码？登录</a>
      </fieldset>
       
    </form>
        </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
     <%: Scripts.Render("~/scripts/BootstrapSelect") %>
  <script type="text/javascript">
    $("select").selectpicker({ style: 'btn-hg btn-primary', menuStyle: 'dropdown-inverse' });
  </script>
</asp:Content>
