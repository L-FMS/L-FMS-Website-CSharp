<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="L_FMS.Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-sm-12">
      <h3>Search Results <small> for "<%: Request.Params["q"] %>"</small> </h3>
      <div class="table-responsive">

        <form runat="server">
          <asp:GridView   ID="searchItem" CssClass="table table-hover"  runat="server" AutoGenerateColumns="false"   BorderWidth="0px" GridLines="None" >
              <columns>
                  <asp:BoundField DataField="name" HeaderText="Name" />
                  <asp:BoundField DataField="date" HeaderText="Date" />
                  <asp:BoundField DataField="place" HeaderText="Place" />
              </columns>
          </asp:GridView>
        </form>
      </div>
      <div class="pagination col-sm-12 text-center">
        <ul>
          <li class="previous"><a href="#fakelink" class="fui-arrow-left"></a></li>
          <li class="active"><a href="#fakelink">1</a></li>
          <li><a href="#fakelink">2</a></li>
          <li><a href="#fakelink">3</a></li>
          <li><a href="#fakelink">4</a></li>
          <li><a href="#fakelink">5</a></li>
          <li><a href="#fakelink">6</a></li>
          <li><a href="#fakelink">7</a></li>
          <li><a href="#fakelink">8</a></li>
          <li class="next"><a href="#fakelink" class="fui-arrow-right"></a></li>
        </ul>
      </div>
    </div>
  </div>
</asp:Content>


