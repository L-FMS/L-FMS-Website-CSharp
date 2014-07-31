<%@ Page Title="首页 | 失物招领管理系统"  Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="L_FMS.WebForm1"   %>


<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="jumbotron">
    <h2>Lost & Found Management System</h2>
    <p>If you lost anything, you can come here and publish your information.</p>
    <p>If you picked up somthing, you can also come here to find its owner.</p>
  </div>

  <div class="row">
     <form runat="server">
    <div class="col-sm-6">
      <h3>Lost things <button class="btn btn-danger">I've lost something!</button></h3>
      <div class="table-responsive">
        <table class="table table-hover">
          <thead>
            <tr>
              <th>Name</th>
              <th>Date</th>
              <th>Place</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
          </tbody>
        </table>


            <asp:GridView   ID="lost" CssClass="table table-hover"  runat="server" AutoGenerateColumns="false"   BorderWidth="0px" GridLines="None" OnRowDataBound="lost_RowDataBound"  AllowPaging="true" PageSize="10 " PagerSettings-Visible="false">
                <columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="date" HeaderText="Date" />
                    <asp:BoundField DataField="place" HeaderText="Place" />
                </columns>
            </asp:GridView>

      </div>
      <div class="clearfix">
        <ul class="pager" style="float: right;">      
          <li class="previous"  ><a href="#"><asp:Button runat="server" OnClick="lost_pre_click"  Text="&larr; Older" BackColor="#34495e" BorderWidth="0px"/></a></li>
           <li class="next"  ><a href="#" ><asp:Button runat="server" OnClick="lost_next_click"  Text="Newer &rarr;" BackColor="#34495e" BorderWidth="0px"/></a></li>
        </ul>
        <em class="text-muted" style="float: left;">Page <%=this.lost.PageIndex+1 %> of <%=lost_amount %></em>
      </div>
    </div>
    <div class="col-sm-6">
        <h3>Found things <button class="btn btn-primary">I've found something!</button></h3>
        <div class="table-responsive">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Date</th>
                    <th>Place</th>
                 </tr>
           </thead>
           <tbody>
                <tr>
                  <td>Glasses</td>
                  <td>2014/4/20</td>
                 <td>Public Baths</td>
                 </tr>
          </tbody>
        </table>
            <asp:GridView   ID="found" CssClass="table table-hover"  runat="server" AutoGenerateColumns="false"   BorderWidth="0px" GridLines="None"  OnRowDataBound="found_RowDataBound" AllowPaging="true" PageSize="10 " PagerSettings-Visible="false">
                <columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="date" HeaderText="Date" />
                    <asp:BoundField DataField="place" HeaderText="Place" />
                </columns>
            </asp:GridView>
      </div>
      <div class="clearfix">
        <ul class="pager" style="float: right;">
                     
          <li class="previous"  ><a href="#"><asp:Button runat="server" OnClick="found_pre_click"  Text="&larr; Older" BackColor="#34495e" BorderWidth="0px"/></a></li>
           <li class="next"  ><a href="#" ><asp:Button runat="server" OnClick="found_next_click"  Text="Newer &rarr;" BackColor="#34495e" BorderWidth="0px"/></a></li>
      <!--    <li class="next"><a href="#">Newer &rarr;</a></li> -->
        </ul>
          
        <em class="text-muted" style="float: left;">Page <%=this.found.PageIndex+1 %> of <%=found_amount %></em>
      </div>
    </div>
    </form>
  </div>
</asp:Content>
