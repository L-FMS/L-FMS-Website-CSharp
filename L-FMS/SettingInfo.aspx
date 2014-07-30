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
      <form class="form-horizontal" role="form" id="info-form" method="POST" action="">
        <div class="form-group">
          <label for="name" class="col-sm-1 control-label">姓名</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="name" placeholder="姓名">
          </div>
        </div>
        <div class="form-group">
          <label for="sex" class="col-sm-1 control-label">性别</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="sex" placeholder="性别">
          </div>
        </div>
        <div class="form-group">
          <label for="birth" class="col-sm-1 control-label">生日</label>
          <div class="col-sm-6">
            <input type="date" class="form-control" id="birth" placeholder="生日">
          </div>
        </div>
        <div class="form-group">
          <label for="phone" class="col-sm-1 control-label">手机</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="phone" placeholder="手机">
          </div>
        </div>
        <div class="form-group">
          <label for="major" class="col-sm-1 control-label">专业</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="major" placeholder="专业">
          </div>
        </div>
        <div class="form-group">
          <label for="address" class="col-sm-1 control-label">地址</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="address" placeholder="地址">
          </div>
        </div>
        <div class="form-group">
          <div class="col-sm-offset-1 col-sm-10">
            <button type="submit" class="btn btn-primary">确认更改</button>
          </div>
        </div>
      </form>
    </div><!-- /#info -->
  </div>
</asp:Content>
