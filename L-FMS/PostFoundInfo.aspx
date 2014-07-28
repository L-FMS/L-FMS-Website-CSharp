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
      <form class="login-form" name="loginForm" action="" method="POST">
        <div class="form-group">
          <label for="post-name" style="color: #bfc9ca;">Name</label>
          <input type="text" class="form-control login-field" placeholder="Name" id="post-name" required autofocus>
          <label for="post-name" class="login-field-icon fui-search"></label>
        </div>
        <div class="form-group">
          <label for="post-type" style="color: #bfc9ca;">Type</label>
          <select name="categoryId" class="select-block mbl" id="post-type" required>
            <option>-----</option>
            <option value="0">My Profile</option>
            <option value="1">My Friends</option>
          </select>
          <input type="hidden" name="type" class="form-control" required>
        </div>
        <div class="form-group">
          <label for="post-time" style="color: #bfc9ca;">Time</label>
          <input type="date" class="form-control login-field" placeholder="Time" id="post-time" name="dateTimeString" required>
          <label for="post-time" class="login-field-icon fui-time"></label>
        </div>
        <div class="form-group">
          <label for="post-place" style="color: #bfc9ca;">Place</label>
          <input type="text" class="form-control login-field" placeholder="Place" id="post-place" required>
          <label for="post-place" class="login-field-icon fui-location"></label>
        </div>
        <div class="form-group">
          <label for="post-image" style="color: #bfc9ca;">Image</label>
          <input type="file" class="form-control login-field filestyle" placeholder="Image" id="post-image" accept="image/*" required>
        </div>
        <div class="form-group">
          <label for="post-tags" style="color: #bfc9ca;">Tag</label>
          <input class="form-control login-field tagsinput" placeholder="Tag" id="post-tags" required>
        </div>
        <div class="form-group">
          <label for="post-description" style="color: #bfc9ca;">Description</label>
          <textarea class="form-control login-field" name="description" id="post-description" cols="30" rows="5" placeholder="Description"></textarea>
        </div>
        <button type="submit" class="btn btn-primary btn-lg btn-block">Post</button>
      </form>
    </main>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
        <script type="text/javascript">
            $("select").selectpicker({ style: 'btn-hg btn-primary', menuStyle: 'dropdown-inverse' });
    </script>
        <script type="text/javascript">
            $(".tagsinput").tagsInput();
    </script>
</asp:Content>
