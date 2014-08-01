<%@ Page Title="首页 | 失物招领管理系统"  Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true"   %>

<asp:Content ContentPlaceHolderID="NavbarContent" runat="server">
  <ul class="nav navbar-nav">
    <li class=""><a runat="server" href="~/">主页</a></li>
    <li class=""><a runat="server" href="~/GetDialogue.aspx">站内信</a></li>
    <li class=""><a runat="server" href="~/List.aspx">排行榜</a></li>
    <li class="active"><a runat="server" href="~/About.aspx">关于我们</a></li>
  </ul>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="jumbotron">
    <h3>组员合照</h3>
    <div class="row">
      <div class="col-sm-4">
        <div class="row">
          <div class="col-sm-6">陈璐</div>
          <div class="col-sm-6">高屹</div>
          <div class="col-sm-6">陈玉婷</div>
          <div class="col-sm-6">李伟</div>
          <div class="col-sm-6">杨宇歆</div>
          <div class="col-sm-6">张睿</div>
          <div class="col-sm-6">胡永豪</div>
          <div class="col-sm-6">丁宇笙</div>
          <div class="col-sm-6">郭静阳</div>
          <div class="col-sm-6">胡圣托</div>
        </div>
      </div>
    </div>
    <img src="images/group.jpg" style="width: 100%;"><!-- 组员合照 -->
    
  </div>
</asp:Content>
