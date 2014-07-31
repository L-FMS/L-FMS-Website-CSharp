<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="SettingQuestions.aspx.cs" Inherits="L_FMS.SettingQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
  <!-- Custom Stylesheets -->
  <webopt:bundlereference runat="server" path="~/stylesheets/Settings" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <!-- Nav tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li><a runat="server" href="~/SettingInfo.aspx">个人信息</a></li>
    <li><a runat="server" href="~/SettingPwd.aspx">更改密码</a></li>
    <li class="active"><a runat="server" href="~/SettingQuestions.aspx">密保问题</a></li>
  </ul>
    <%if (alreadyset == true) { %>
        <h3> 你已经设置了密保问题</h3>
    
    <%} else { %>
  <!-- Tab panes -->
  <div class="tab-content">
    <!-- 密保问题 -->
    <div class="tab-pane active fade in" id="question">
      <form class="col-sm-offset-1 col-sm-6" role="form" id="question_form" method="POST" runat="server">
        <!--- 密保问题1 -->
            <div class="form-group">
                <label for="question1" class="control-label">验证问题1</label>
                <select name="question1" id="question1" class="select-block mbl" required>
                    <option value="0"><%: questions[0].CONTENT %></option>    
                </select>
            </div>
            <div class="form-group">
                <input type="text" class="form-control" name="answer1" id="answer1" placeholder="<%:questions[0].FORMAT_TIP %>" pattern="<%:questions[0].QUESTION_FORMAT %>">
            </div>


          <!--- 密保问题2 -->
            <div class="form-group">
                <label for="question2" class="control-label">验证问题2</label>
                <select name="question2" id="question2" class="select-block mbl" required>
                    <option value="0"><%: questions[1].CONTENT %></option>             
                </select>
            </div>
            <div class="form-group">
                <input type="text" class="form-control" name="answer2" id="answer2" placeholder="<%:questions[1].FORMAT_TIP %>" pattern="<%:questions[1].QUESTION_FORMAT %>">
            </div>
          <!--- 密保问题3 -->
          <div class="form-group">
              <label for="question3" class="control-label">验证问题3</label>
              <select name="question3" id="question3" class="select-block mbl" required>
                <option value="0"><%: questions[2].CONTENT %></option>   
              </select>
        </div>
        <div class="form-group">
            <input type="text" class="form-control" name="answer3" id="answer3" placeholder="<%:questions[2].FORMAT_TIP %>" pattern="<%:questions[2].QUESTION_FORMAT %>">
        </div>
        
          <!--- 提交 -->
         <asp:Button runat="server" OnClick="Create_Question" Text="确认提交" CssClass="btn btn-primary" />
      </form>
    </div><!-- /#question -->
  </div>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
  <%: Scripts.Render("~/scripts/BootstrapSelect") %>
  <script type="text/javascript">
    $("select").selectpicker({style: 'btn btn-primary', menuStyle: 'dropdown-inverse'});
  </script>
</asp:Content>
