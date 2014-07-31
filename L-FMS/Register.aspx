<%@ Page Title="注册 | 失物招领管理系统" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="L_FMS.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Register" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
  <main class="login-screen">
    <div class="login-icon">
      <img src="images/login/icon.png" alt="Welcome th L&FMS">
      <h4>Please finish your personal infomation</h4>
    </div>

    <form class="login-form" name="signupForm" action="Register.aspx" method="POST" runat="server">
      <%-- 账号信息 --%>
      <fieldset>
        <legend>账号信息</legend>

        <%-- 邮箱 --%>
        <div class="form-group">
          <label for="register-email" style="color: #bfc9ca;">邮箱</label>
          <input type="email" class="form-control login-field" placeholder="输入您的邮箱" id="register-email" name="email" required autofocus>
          <label for="register-email" class="login-field-icon fui-user"></label>
        </div>

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
      
      <%-- 个人信息 --%>
      <fieldset>
        <legend>个人信息</legend>

        <%-- 姓名 --%>
        <div class="form-group">
          <label for="register-name" style="color: #bfc9ca;">姓名</label>
          <input type="text" class="form-control login-field" placeholder="请输入您的真实姓名" id="register-name" name="user-name" required>
          <label for="register-name" class="login-field-icon fui-lock"></label>
        </div>

        <%-- 性别 --%>
        <div class="form-group">
          <label for="register-sex" style="color: #bfc9ca;">性别</label>
          <select name="sex" id="register-sex" class="select-block mbl" required>
            <option>请选择您的性别</option>
            <option value="0">男</option>
            <option value="1">女</option>
          </select>
        </div>

        <%-- 出生年月 --%>
        <div class="form-group">
          <label for="register-birth" style="color: #bfc9ca;">生日</label>
          <input type="date" class="form-control login-field" placeholder="请输入您的生日" id="register-birth" name="birth" required>
        </div>

        <%-- 手机号码 --%>
        <div class="form-group">
          <label for="register-phone" style="color: #bfc9ca;">手机号码</label>
          <input type="tel" class="form-control login-field" placeholder="请输入您的手机号码" id="register-phone" name="phone" required>
          <label for="register-phone" class="login-field-icon fui-lock"></label>
        </div>

        <%-- 专业 --%>
        <div class="form-group">
          <label for="register-major" style="color: #bfc9ca;">专业</label>
          <input type="text" class="form-control login-field" placeholder="请输入您的专业" id="register-major" name="major" required>
          <label for="register-major" class="login-field-icon fui-lock"></label>
        </div>

        <%-- 地址 --%>
        <div class="form-group">
          <label for="register-addr" style="color: #bfc9ca;">住址</label>
          <input type="text" class="form-control login-field" placeholder="请输入您的住址" id="register-addr" name="address" required>
          <label for="register-addr" class="login-field-icon fui-lock"></label>
        </div>
      </fieldset>

      <asp:Button runat="server" OnClick="Create_User" Text="注册" CssClass="btn btn-primary btn-lg btn-block" />
    </form>
  </main>
</asp:Content>

<asp:Content ContentPlaceHolderID="CustomScriptContent" runat="server">
  <%: Scripts.Render("~/scripts/BootstrapSelect") %>
  <script type="text/javascript">
    $("select").selectpicker({ style: 'btn-hg btn-primary', menuStyle: 'dropdown-inverse' });
  </script>
</asp:Content>
