<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Index" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="jumbotron">
    <h2>Lost & Found Management System</h2>
    <p>If you lost anything, you can come here and publish your information.</p>
    <p>If you picked up somthing, you can also come here to find its owner.</p>
  </div>

  <div class="row">
    <div class="col-sm-6">
      <h3>Lost things <button class="btn btn-danger">I've lost something!</button></h3>
      <div class="table-responsive">
        <table class="table table-hover">
          <thead>
            <tr>
              <th>Type</th>
              <th>Name</th>
              <th>Date</th>
              <th>Place</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Card</td>
              <td>ID Card</td>
              <td>2014/5/1</td>
              <td>Playground</td>
            </tr>
            <tr>
              <td>Phone</td>
              <td>iPhone 5</td>
              <td>2014/3/29</td>
              <td>Classroom</td>
            </tr>
            <tr>
              <td>Personal</td>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
            <tr>
              <td>Personal</td>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
            <tr>
              <td>Personal</td>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
            <tr>
              <td>Personal</td>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
            <tr>
              <td>Personal</td>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
            <tr>
              <td>Personal</td>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
            <tr>
              <td>Personal</td>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
          </tbody>
        </table>
      </div>
      <ul class="pager">
        <li class="previous"><a href="#">&larr; Older</a></li>
        <li class="next"><a href="#">Newer &rarr;</a></li>
      </ul>
      <em style="float:right;">Page 1 of 32</em>
    </div>
    <div class="col-sm-6">
      <h3>Found things <button class="btn btn-primary">I've found something!</button></h3>
      <div class="table-responsive">
        <table class="table table-hover">
          <thead>
            <tr>
              <th>Type</th>
              <th>Name</th>
              <th>Date</th>
              <th>Place</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Card</td>
              <td>ID Card</td>
              <td>2014/5/1</td>
              <td>Playground</td>
            </tr>
            <tr>
              <td>Card</td>
              <td>ID Card</td>
              <td>2014/5/1</td>
              <td>Playground</td>
            </tr>
            <tr>
              <td>Card</td>
              <td>ID Card</td>
              <td>2014/5/1</td>
              <td>Playground</td>
            </tr>
            <tr>
              <td>Card</td>
              <td>ID Card</td>
              <td>2014/5/1</td>
              <td>Playground</td>
            </tr>
            <tr>
              <td>Card</td>
              <td>ID Card</td>
              <td>2014/5/1</td>
              <td>Playground</td>
            </tr>
            <tr>
              <td>Phone</td>
              <td>iPhone 5</td>
              <td>2014/4/29</td>
              <td>Classroom</td>
            </tr>
            <tr>
              <td>Personal</td>
              <td>Glasses</td>
              <td>2014/4/20</td>
              <td>Public Baths</td>
            </tr>
          </tbody>
        </table>
      </div>
      <ul class="pager">
        <li class="previous"><a href="#">&larr; Older</a></li>
        <li class="next"><a href="#">Newer &rarr;</a></li>
      </ul>
      <em style="float:right;">Page 1 of 32</em>
    </div>
  </div>
</asp:Content>
