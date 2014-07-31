<%@ Page Title="首页 | 失物招领管理系统"  Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="L_FMS.WebForm1"   %>

<asp:Content ContentPlaceHolderID="NavbarContent" runat="server">
  <ul class="nav navbar-nav">
    <li class="active"><a runat="server" href="~/">主页</a></li>
    <li class=""><a runat="server" href="~/GetDialogue.aspx">站内信</a></li>
    <li class=""><a runat="server" href="~/List.aspx">排行榜</a></li>
    <li class=""><a runat="server" href="~/About.aspx">关于我们</a></li>
  </ul>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="jumbotron">
    <h2>失物招领管理系统</h2>
    <p>如果你丢了任何物品，你都可以将信息发布在我们的网站上</p>
    <p>如果你捡到了任何物品，你也可以将信息发布在网站上，以更快寻找到失主</p>
  </div>

  <div class="row">
     <form runat="server">
    <div class="col-sm-6">
      <h3>丢失物品 <a runat="server" href="~/PostLostInfo.aspx" class="btn btn-danger">我丢东西了！</a></h3>
      <div class="table-responsive">
        <asp:GridView   ID="lost" CssClass="table table-hover"  runat="server" AutoGenerateColumns="false"   BorderWidth="0px" GridLines="None" OnRowDataBound="lost_RowDataBound"  AllowPaging="true" PageSize="10 " PagerSettings-Visible="false">
          <columns>
            <asp:BoundField DataField="name" HeaderText="物品名" />
            <asp:BoundField DataField="date" HeaderText="发布时间" />
            <asp:BoundField DataField="place" HeaderText="地点" />
          </columns>
        </asp:GridView>
      </div>
      <div class="clearfix">
        <ul class="pager" style="float: right;">      
          <li class="previous"  ><a href="#"><asp:Button runat="server" OnClick="lost_pre_click"  Text="&larr; 上一页" BackColor="transparent" BorderWidth="0px"/></a></li>
           <li class="next"  ><a href="#" ><asp:Button runat="server" OnClick="lost_next_click"  Text="下一页 &rarr;" BackColor="transparent" BorderWidth="0px"/></a></li>
        </ul>
        <em class="text-muted" style="float: left;">Page <%=this.lost.PageIndex+1 %> of <%=lost_amount %></em>
      </div>
    </div>
    <div class="col-sm-6">
      <h3>拾取物品 <a runat="server" href="~/PostFoundInfo.aspx" class="btn btn-primary">我捡到东西了！</a></h3>
      <div class="table-responsive">
        <asp:GridView   ID="found" CssClass="table table-hover"  runat="server" AutoGenerateColumns="false" BorderWidth="0px" GridLines="None"  OnRowDataBound="found_RowDataBound" AllowPaging="true" PageSize="10 " PagerSettings-Visible="false">
          <columns>
            <asp:BoundField DataField="name" HeaderText="物品名" />
            <asp:BoundField DataField="date" HeaderText="发布时间" />
            <asp:BoundField DataField="place" HeaderText="地点" />
          </columns>
        </asp:GridView>
      </div>
      <div class="clearfix">
        <ul class="pager" style="float: right;">
          <li class="previous"><a href="#"><asp:Button runat="server" OnClick="found_pre_click"  Text="&larr; 上一页" BackColor="transparent" BorderWidth="0px"/></a></li>
          <li class="next"  ><a href="#" ><asp:Button runat="server" OnClick="found_next_click"  Text="下一页 &rarr;" BackColor="transparent" BorderWidth="0px"/></a></li>
        </ul>
          
        <em class="text-muted" style="float: left;">Page <%=this.found.PageIndex+1 %> of <%=found_amount %></em>
      </div>
    </div>
    </form>
  </div>
</asp:Content>
