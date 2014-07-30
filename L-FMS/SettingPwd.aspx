<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="SettingPwd.aspx.cs" Inherits="L_FMS.SettingPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Settings" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <!-- Nav tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li><a runat="server" href="~/SettingInfo.aspx">个人信息</a></li>
    <li class="active"><a runat="server" href="~/SettingPwd.aspx">更改密码</a></li>
    <li><a runat="server" href="~/SettingQuestions.aspx">密保问题</a></li>
  </ul>

  <!-- Tab panes -->
  <div class="tab-content">
    <!-- 更改密码 -->
    <div class="tab-pane active fade in" id="changePassword">
      <form class="form-horizontal" role="form" id="pwd-form" method="POST" action="">
        <div class="form-group">
          <label for="old-pwd" class="col-sm-1 control-label">旧密码</label>
          <div class="col-sm-6">
            <input type="password" class="form-control" id="old-pwd" placeholder="旧密码">
          </div>
        </div>
        <div class="form-group">
          <label for="new-pwd" class="col-sm-1 control-label">新密码</label>
          <div class="col-sm-6">
            <input type="password" class="form-control" id="new-pwd" placeholder="新密码">
          </div>
        </div>
        <div class="form-group">
          <label for="confirm-pwd" class="col-sm-1 control-label">确认密码</label>
          <div class="col-sm-6">
            <input type="password" class="form-control" id="confirm-pwd" placeholder="确认密码">
          </div>
        </div>
        <div class="form-group">
          <div class="col-sm-offset-1 col-sm-10">
            <button type="submit" class="btn btn-primary">确认更改</button>
          </div>
        </div>
      </form>
    </div><!-- /#changePassword -->
  </div>
</asp:Content>
