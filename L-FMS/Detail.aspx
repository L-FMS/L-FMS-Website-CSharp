<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="L_FMS.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <webopt:bundlereference runat="server" path="~/stylesheets/Detail" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-sm-3">
      <div class="tile person-tile">
        <img src="images/icons/svg/compas.svg" alt="Avatar" class="tile-image big-illustration">
        <h3 class="tile-title"><%=person_message.USER_NAME %></h3>
        <p>Phone: <%=person_message.phone %></p>
        <p>Stu. ID: 1252960</p>
        <a href="#" class="btn btn-primary btn-large btn-block">Contact with me</a>
      </div><!-- /.person-tile -->
    </div>

    <div class="col-sm-offset-1 col-sm-8">
      <div class="tile item-detail-tile">
        <img src="images/icons/svg/compas.svg" alt="Avatar" class="tile-image big-illustration">
        <h3 class="tile-title">[<%=item_message.ITEM_NAME %>]</h3><!-- /.tile-title -->
        <ul>
          <li>
            <span class="fui-time"></span> <%=publishment_message.PUBLISH_DATE.ToString() %>
          </li>
          <li>
            <span class="fui-location"></span> <%=publishment_message.PLACE %>
          </li>
          <li class="item-description">
            <span class="fui-list"></span> Description:
            <p><%=item_message.ITEM_DESCRIPTION %></p>
            
          </li>
        </ul>
      </div><!-- /.item-detail-tile -->
    </div>
  </div>
  <hr>
  <div class="row">
    <div class="col-sm-8">
      <div class="item-comment-box">
        <form action="" method="POST" runat="server">
          <div class="form-group">
            <label for="comment-content" class="sr-only">Email address</label>
            <textarea name="comment" class="form-control" id="comment-content" placeholder="评论..." maxlength="140" onkeypress="if(event.keyCode==13) return false;"></textarea>
          </div>
          <div class="comment-btn">
            <asp:Button CssClass="btn btn-inverse" runat="server" OnClick="Comment_Submit" Text="评论"/>
            <button class="btn btn-link" id="comment-cancel">取消</button>
          </div>
        </form>
      </div><!-- /.item-comment-box -->
      <div class="item-comment-list">


          <!-- 嵌入语句foreach 用以显示comment -->
          <% foreach (var i in UserComment)
             { %>

        <div class="item-comment clearfix">
          <a target="_balank" href="#" class="avatar">
            <img src="images/zr.jpg" width="50">
          </a><!-- /.avatar -->
          <div class="item-comment-content">

            <p class="content-text">

              <a href="#" target="_blank" class="name"><%= i.user_name %></a>: <%= i.content %>
            </p><!-- /.content-text -->

            <span class="comment-time text-muted"><%= i.time.ToString() %></span><!-- /.comment-time -->
          </div><!-- /.item-comment-content -->
        </div><!-- /.item-comment -->
        <%} %>
        
      </div><!-- /.item-comment-list -->
    </div>
  </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
  <%: Scripts.Render("~/scripts/Detail") %>
</asp:Content>
