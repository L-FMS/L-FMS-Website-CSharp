<%@ Page Title="后台管理 | 失物招领管理系统" Language="C#" MasterPageFile="~/Admin/AdminPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="L_FMS.Admin.Dashboard" %>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
  <div class='panel panel-default'>
    <div class='panel-heading'>
      <i class='icon-home icon-large'></i>
      Lost&Found 数据
    </div>
          
    <div class='panel-body'>
      <div class="row">
        <div class="col-sm-6">
          <div class='page-header'>
            <h4>表</h4>
          </div>
          <div class="row">
            <div class="col-sm-8">
              <div class="list-group">
                <a runat="server" href="~/Admin/Usertable.aspx" class="list-group-item">用户</a>
                <a runat="server" href="~/Admin/Itemtable.aspx" class="list-group-item">物品</a>
              </div>
            </div>
          </div>
        </div>
        <div class="col-sm-6">
          <div class='page-header'>
            <h4>编辑</h4>
          </div>
          <div class="row">
            <div class="col-sm-8">
              <div class="list-group">
                <a runat="server" href="~/Admin/AddQuestion.aspx" class="list-group-item">添加密保问题</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
