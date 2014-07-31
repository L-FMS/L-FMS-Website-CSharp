<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="L_FMS.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <webopt:bundlereference runat="server" path="~/stylesheets/Success" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
  <main class="login-screen" >
    <div class="login-icon">
      <img src="images/icons/svg/paper-bag.svg" alt="Welcome th L&FMS">
      <h4 class="text-center">成功</h4>
    </div>

    <form class="login-form" runat="server">
      <p class="text-center"><%= successMessage %></p>
      <asp:Button runat="server" CssClass="btn btn-primary btn-lg btn-block" Text="返回"  OnClick="goBack"/>
    </form>

  </main>
</asp:Content>
