<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="L_FMS.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <webopt:bundlereference runat="server" path="~/stylesheets/Detail" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-sm-3">
      <div class="tile person-tile">
        <img src="images/icons/svg/compas.svg" alt="Avatar" class="tile-image big-illustration">
        <h3 class="tile-title">逗比</h3>
        <p>Phone: 18817876224</p>
        <p>Stu. ID: 1252960</p>
        <a href="#" class="btn btn-primary btn-large btn-block">Contact with me</a>
      </div><!-- /.person-tile -->
    </div>

    <div class="col-sm-offset-1 col-sm-8">
      <div class="tile item-detail-tile">
        <img src="images/icons/svg/compas.svg" alt="Avatar" class="tile-image big-illustration">
        <h3 class="tile-title">[Item Name]</h3><!-- /.tile-title -->
        <ul>
          <li>
            <span class="fui-time"></span> 2014.05.04
          </li>
          <li>
            <span class="fui-location"></span> 篮球场
          </li>
          <li class="item-description">
            <span class="fui-list"></span> Description:
            <p>我撒的发生都发生大风</p>
            <p>三大范围服务器</p>
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
            <button class="btn btn-inverse disabled" type="submit">评论</button>
            <button class="btn btn-link" id="comment-cancel">取消</button>
          </div>
        </form>
      </div><!-- /.item-comment-box -->
      <div class="item-comment-list">
        <div class="item-comment clearfix">
          <a target="_balank" href="#" class="avatar">
            <img src="images/zr.jpg" width="50">
          </a><!-- /.avatar -->
          <div class="item-comment-content">
            <p class="content-text">
              <a href="#" target="_blank" class="name">张睿</a>: 哈哈哈哈哈哈我是测试的平铺你还要再阿哥让各位哥啊五个哇嘎额外的法尔废弃物额头切尔偶按而且非常
            </p><!-- /.content-text -->
            <span class="comment-time text-muted">2014-07-26 15:31</span><!-- /.comment-time -->
          </div><!-- /.item-comment-content -->
        </div><!-- /.item-comment -->
        <div class="item-comment clearfix">
          <a target="_balank" href="#" class="avatar">
            <img src="images/zr.jpg" width="50">
          </a><!-- /.avatar -->
          <div class="item-comment-content">
            <p class="content-text">
              <a href="#" target="_blank" class="name">张睿</a>: 哈哈哈哈哈哈我是测试的平铺你还要再阿哥让各位哥啊五个哇嘎额外的法尔废弃物额头切尔偶按而且非常
            </p><!-- /.content-text -->
            <span class="comment-time text-muted">2014-07-26 15:31</span><!-- /.comment-time -->
          </div><!-- /.item-comment-content -->
        </div><!-- /.item-comment -->
        <div class="item-comment clearfix">
          <a target="_balank" href="#" class="avatar">
            <img src="images/zr.jpg" width="50">
          </a><!-- /.avatar -->
          <div class="item-comment-content">
            <p class="content-text">
              <a href="#" target="_blank" class="name">张睿</a>: 哈哈哈哈哈哈我是测试的平铺你还要再阿哥让各位哥啊五个哇嘎额外的法尔废弃物额头切尔偶按而且非常
            </p><!-- /.content-text -->
            <span class="comment-time text-muted">2014-07-26 15:31</span><!-- /.comment-time -->
          </div><!-- /.item-comment-content -->
        </div><!-- /.item-comment -->
      </div><!-- /.item-comment-list -->
    </div>
  </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
  <%: Scripts.Render("~/scripts/Detail") %>
</asp:Content>
