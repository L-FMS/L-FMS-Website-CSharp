<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.Master" AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" Inherits="L_FMS.Admin.AddQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div id ="content">
    <div class='panel panel-default'>
          <div class='panel-heading'>
            <i class='icon-edit icon-large'></i>
            添加密保问题
          </div>
          <div class='panel-body'>
            <form class='form-horizontal' runat="server"  method="POST" role="form">
              <fieldset>
                <legend>Add Question</legend>
                
                
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>密保问题内容</label>
                  <div class='col-lg-10'>
                    <input name="content" class='form-control' placeholder='Content' type='text' required>
                  </div>
                </div>
                   <div class='form-group'>
                  <label class='col-lg-2 control-label'>问题答案正则限制</label>
                  <div class='col-lg-10'>
                    <input name="format" class='form-control' placeholder='Format' type='text' required>
                  </div>
                </div>
                   <div class='form-group'>
                  <label class='col-lg-2 control-label'>问题提示信息</label>
                  <div class='col-lg-10'>
                    <input name="tip" class='form-control' placeholder='Tips' type='text'  required>
                  </div>
                </div>


                
              </fieldset>
              
                 <!--- 提交 -->
                <asp:Button runat="server" OnClick="Create_Question" Text="确认提交" CssClass="btn  btn-default" />

            </form>
          </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
</asp:Content>
