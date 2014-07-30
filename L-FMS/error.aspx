<%@ Page Title="错误" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="L_FMS.error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <webopt:bundlereference runat="server" path="~/stylesheets/Error" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
  <main class="post-screen">
    <div class="login-icon">
      <img src="images/icons/svg/paper-bag.svg" alt="Welcome th L&FMS">
      <h4 class="text-center">错误</h4>
    </div>
    <div class="login-form">
      <p class="text-center">错误错误</p>
    </div>
  </main>
</asp:Content>
