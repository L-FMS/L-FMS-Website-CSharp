<%@ Page Title="找回密码 | 失物招领管理系统" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="FindPasswordVerified.aspx.cs" Inherits="L_FMS.FindPasssordVerified" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <main class="login-screen">
    <div class="login-icon">
      <img src="images/login/icon.png" alt="Welcome th L&FMS">
      <h4>Welcome to <small>L&FMS</small></h4>
    </div>

      <form class="login-form" name="securityForm" method="POST" runat="server">
    
           <%-- 填写密码保护问题 --%>
      <fieldset>
        <legend>请填写密码保护问题</legend>
        <%-- 输入问题答案 --%>
          
          <% for (int i = 0; i < questions.Length; ++i)
             {
                 var question = questions[i];
                  %>
            <div class="form-group">
                <label for="register-pass" style="color: #bfc9ca;"><%:question.CONTENT%></label>
                <input title="" pattern="<%:question.QUESTION_FORMAT%>" type="text" class="form-control login-field" placeholder="<%:question.FORMAT_TIP%>" id="ans" name="<%:"ans"+i %>"  required >
                <label for="register-pass" class="login-field-icon fui-lock"></label>
            </div>
          <% } %>
        <asp:Button CssClass="btn btn-primary btn-lg btn-block" runat="server" OnClick="Submit_Answer"  Text="提交"  />
       
      </fieldset>
        

     
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
</asp:Content>
