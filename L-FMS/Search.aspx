<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="L_FMS.Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-sm-12">
      <h3>Search Results <small> for "<%: Request.Params["q"] %>"</small> </h3>
      <div class="table-responsive">

        <form runat="server">
          <asp:GridView   ID="searchItem" CssClass="table table-hover"  runat="server" AutoGenerateColumns="false"   BorderWidth="0px" GridLines="None"  OnRowDataBound="searchItem_RowDataBound">
              <columns>
                  <asp:BoundField DataField="name" HeaderText="Name" />
                  <asp:BoundField DataField="date" HeaderText="Date" />
                  <asp:BoundField DataField="place" HeaderText="Place" />
              </columns>
          </asp:GridView>
        </form>
      </div>
    </div>
  </div>
</asp:Content>


