<%@ Page Title="信息 | 失物招领管理系统" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="GetDialogue.aspx.cs" Inherits="L_FMS.Dialogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    <form class="col-sm-offset-1 col-sm-6" role="form" id="question_form" method="POST" runat="server">
     
    <!-- 选择已有对话 -->
    <div class="form-group">
        
        <select name="dialog" id="dialog_id class="select-block mbl" required>
            <option value ="-1">选择已有的对话</option>
          <% foreach (var dialog in dialogs) { %> 
            <option value="<%:dialog.DIALOG_ID %>">
                <%: dialog.CONTACT_NAME %>
            </option>
            <% } %>
        </select>
    </div>
        
    <div class="form-group">
        <label for="address" class="control-label">创建新的对话</label>
        <div class="col-sm-6">
            <input type="text" class="form-control" id="address" name="newdialog" placeholder="输入对方email" >
        </div>
    </div>

    <asp:Button runat="server" OnClick="SelectDialog" Text="确定" CssClass="btn btn-primary" />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
</asp:Content>
