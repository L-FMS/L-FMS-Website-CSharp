<%@ Page Title="设置" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="L_FMS.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Settings" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <!-- Nav tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li class="active"><a href="#info" role="tab" data-toggle="tab">个人信息</a></li>
    <li><a href="#changePassword" role="tab" data-toggle="tab">更改密码</a></li>
    <li><a href="#question" role="tab" data-toggle="tab">密保问题</a></li>
  </ul>

  <!-- Tab panes -->
  <div class="tab-content">
    <!-- 个人信息 -->
    <div class="tab-pane active fade in" id="info">
      <form class="form-horizontal" role="form" id="info-form" method="POST" action="">
        <div class="form-group">
          <label for="name" class="col-sm-1 control-label">姓名</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="name" placeholder="姓名">
          </div>
        </div>
        <div class="form-group">
          <label for="sex" class="col-sm-1 control-label">性别</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="sex" placeholder="性别">
          </div>
        </div>
        <div class="form-group">
          <label for="birth" class="col-sm-1 control-label">生日</label>
          <div class="col-sm-6">
            <input type="date" class="form-control" id="birth" placeholder="生日">
          </div>
        </div>
        <div class="form-group">
          <label for="phone" class="col-sm-1 control-label">手机</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="phone" placeholder="手机">
          </div>
        </div>
        <div class="form-group">
          <label for="major" class="col-sm-1 control-label">专业</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="major" placeholder="专业">
          </div>
        </div>
        <div class="form-group">
          <label for="address" class="col-sm-1 control-label">地址</label>
          <div class="col-sm-6">
            <input type="text" class="form-control" id="address" placeholder="地址">
          </div>
        </div>
        <div class="form-group">
          <div class="col-sm-offset-1 col-sm-10">
            <button type="submit" class="btn btn-primary">确认更改</button>
          </div>
        </div>
      </form>
    </div><!-- /#info -->

    <!-- 更改密码 -->
    <div class="tab-pane fade" id="changePassword">
      <form class="form-horizontal" role="form" id="pwd-form" method="POST" action="">
        <div class="form-group">
          <label for="old-pwd" class="col-sm-1 control-label">旧密码</label>
          <div class="col-sm-6">
            <input type="password" class="form-control" id="old-pwd" placeholder="旧密码">
          </div>
        </div>
        <div class="form-group">
          <label for="new-pwd" class="col-sm-1 control-label">新密码</label>
          <div class="col-sm-6">
            <input type="password" class="form-control" id="new-pwd" placeholder="新密码">
          </div>
        </div>
        <div class="form-group">
          <label for="confirm-pwd" class="col-sm-1 control-label">确认密码</label>
          <div class="col-sm-6">
            <input type="password" class="form-control" id="confirm-pwd" placeholder="确认密码">
          </div>
        </div>
        <div class="form-group">
          <div class="col-sm-offset-1 col-sm-10">
            <button type="submit" class="btn btn-primary">确认更改</button>
          </div>
        </div>
      </form>
    </div><!-- /#changePassword -->

    <!-- 密保问题 -->
    <div class="tab-pane fade" id="question">
      <form class="col-sm-offset-1 col-sm-6" role="form" id="question-form" method="POST" action="">
        <div class="form-group">
          <label for="question1" class="control-label">验证问题1</label>
          <select name="question1" id="question1" class="select-block mbl" required>
            <option value="0">asdfsd</option>
                
          </select>
        </div>
        <div class="form-group">
          <input type="text" class="form-control" name="answer1" id="answer1" placeholder="回答">
        </div>

        <div class="form-group">
          <label for="question2" class="control-label">验证问题2</label>
          <select name="question2" id="question2" class="select-block mbl" required>
            <option value="0">asdfsd</option>
                
          </select>
        </div>
        <div class="form-group">
          <input type="text" class="form-control" name="answer2" id="answer2" placeholder="回答">
        </div>

        <div class="form-group">
          <label for="question3" class="control-label">验证问题3</label>
          <select name="question3" id="question3" class="select-block mbl" required>
            <option value="0">asdfsd</option>
                
          </select>
        </div>
        <div class="form-group">
          <input type="text" class="form-control" name="answer2" id="answer2" placeholder="回答">
        </div>

        <div class="form-group">
          <button type="submit" class="btn btn-primary">确认提交</button>
        </div>
      </form>
    </div><!-- /#question -->
  </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
  <%: Scripts.Render("~/scripts/BootstrapSelect") %>
  <script type="text/javascript">
    $("select").selectpicker({style: 'btn btn-primary', menuStyle: 'dropdown-inverse'});
  </script>
</asp:Content>
