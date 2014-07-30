<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="PostFoundInfo.aspx.cs" Inherits="L_FMS.PostFoundInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
    <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Post" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
  <main class="login-screen">
    <div class="login-icon">
      <img src="images/icons/svg/paper-bag.svg" alt="Welcome th L&FMS">
      <h4>Complete the <small>information</small></h4>
    </div>
    <form class="login-form" name="loginForm" action="" method="POST" runat="server" enctype="multipart/form-data">
      <div class="form-group">
        <label for="post-name" style="color: #bfc9ca;">Name</label>
        <input type="text" class="form-control login-field" placeholder="Name" id="post-name" name="item-name" required autofocus>
        <label for="post-name" class="login-field-icon fui-search"></label>
      </div>
        <div class="form-group">
            <label for="post-place" style="color: #bfc9ca;">Place</label>
            <input type="text" class="form-control login-field" placeholder="Place" name="item-place" id="post-place" required>
            <label for="post-place" class="login-field-icon fui-location"></label>
        </div>
      <div class="form-group">
        <label for="post-image" style="color: #bfc9ca;">Image</label>
        <input type="file" class="form-control login-field filestyle" id="post-image" name="item-image" accept="image/*" required>
      </div>
      <div class="form-group">
        <label for="post-tags" style="color: #bfc9ca;">Tag</label>
        <input class="form-control login-field tagsinput" placeholder="Tag" name="item-tags" id="post-tags" required>
      </div>
      <div class="form-group">
        <label for="post-description" style="color: #bfc9ca;">Description</label>
        <textarea class="form-control login-field" name="item-description" id="post-description" cols="30" rows="5" placeholder="Description"></textarea>
      </div>
      <asp:Button  CssClass="btn btn-primary btn-lg btn-block" runat="server" OnClick="postButton" Text="提交"/>
    </form>
  </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
  <%: Scripts.Render("~/scripts/Post") %>
  <script type="text/javascript">
    $("select").selectpicker({ style: 'btn-hg btn-primary', menuStyle: 'dropdown-inverse' });
    $(".tagsinput").tagsInput();
  </script>
</asp:Content>
