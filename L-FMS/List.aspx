<%@ Page Title="排行榜 | 失物招领管理系统" Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="L_FMS.List" MasterPageFile="~/MainPage.master" %>

<asp:Content ContentPlaceHolderID="NavbarContent" runat="server">
  <ul class="nav navbar-nav">
    <li class=""><a runat="server" href="~/">主页</a></li>
    <li class=""><a runat="server" href="~/GetDialogue.aspx">站内信</a></li>
    <li class="active"><a runat="server" href="~/List.aspx">排行榜</a></li>
    <li class=""><a runat="server" href="~/About.aspx">关于我们</a></li>
  </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-sm-12">
      <h3>拾金不昧排行榜</h3>
      <div class="table-responsive">

        <form runat="server">
            <asp:GridView   ID="tableList" CssClass="table table-hover"  runat="server" AutoGenerateColumns="false"   BorderWidth="0px" GridLines="None"   OnRowDataBound="tableList_RowDataBound">
                <columns>
                    <asp:BoundField DataField="rank" HeaderText="Rank" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="number" HeaderText="Number" />
                </columns>
            </asp:GridView>
          </form>
      </div>
      <div class="pagination col-sm-12 text-center">

      </div>
    </div>
  </div>
</asp:Content>
