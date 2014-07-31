<%@ Page Title="设置 | 失物招领管理系统" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="SettingInfo.aspx.cs" Inherits="L_FMS.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Settings" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <!-- Nav tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li class="active"><a runat="server" href="~/SettingInfo.aspx">个人信息</a></li>
    <li><a runat="server" href="~/SettingPwd.aspx">更改密码</a></li>
    <li><a runat="server" href="~/SettingQuestions.aspx">密保问题</a></li>
  </ul>

  <!-- Tab panes -->
  <div class="tab-content">
    <!-- 个人信息 -->
    <div class="tab-pane active fade in" id="info">
      <form class="form-horizontal" role="form" name="infoForm" method="POST" runat="server" action="">
        <div class="form-group">
          <label for="name" class="col-sm-1 control-label">姓名</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="name" name="name" placeholder="姓名" runat="server">
          </div>
        </div>
        <div class="form-group">
          <label for="sex" class="col-sm-1 control-label">性别</label>
          <div class="col-sm-6">
            <select name="sex" id="sex" class="select-block" required runat="server">
              <option>请选择您的性别</option>
              <option value="0">男</option>
              <option value="1">女</option>
            </select>
          </div>
        </div>
        <div class="form-group">
          <label for="birth" class="col-sm-1 control-label">生日</label>
          <div class="col-sm-6">
            <input type="date" class="form-control" id="birth" name="birth" placeholder="生日" runat="server">
          </div>
        </div>
        <div class="form-group">
          <label for="phone" class="col-sm-1 control-label">手机</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="phone" name="phone" placeholder="手机" runat="server">
          </div>
        </div>
        <div class="form-group">
          <label for="major" class="col-sm-1 control-label">专业</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="major" name="major" placeholder="专业" runat="server">
          </div>
        </div>
        <div class="form-group">
          <label for="address" class="col-sm-1 control-label">地址</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="address" name="address" placeholder="地址" runat="server">
          </div>
        </div>
        <div class="form-group">
          <div class="col-sm-offset-1 col-sm-10">
            <asp:Button CssClass="btn btn-primary" OnClick="Update_Info" runat="server" Text="确认更改" />
          </div>
        </div>
      </form>
    </div><!-- /#info -->
  </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="CustomScriptContent" runat="server">
  <%: Scripts.Render("~/scripts/BootstrapSelect") %>
  <script type="text/javascript">
    $("select").selectpicker({ style: 'btn-hg btn-primary', menuStyle: 'dropdown-inverse' });
  </script>
</asp:Content>
