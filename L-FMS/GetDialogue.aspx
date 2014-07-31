<%@ Page Title="信息 | 失物招领管理系统" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="GetDialogue.aspx.cs" Inherits="L_FMS.Dialogue" %>

<asp:Content ContentPlaceHolderID="NavbarContent" runat="server">
  <ul class="nav navbar-nav">
    <li class=""><a runat="server" href="~/">主页</a></li>
    <li class="active"><a runat="server" href="~/GetDialogue.aspx">站内信</a></li>
    <li class=""><a runat="server" href="~/List.aspx">排行榜</a></li>
    <li class=""><a runat="server" href="~/About.aspx">关于我们</a></li>
  </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
    <form class="form-horizontal" role="form" id="question_form" method="POST" runat="server">
     
    <!-- 选择已有对话 -->
    <div class="form-group">
        <label for="dialog_id" class="col-sm-2 control-label">选择对话</label>
        <div class="col-sm-6">
            <select name="dialog" id="dialog_id" class="select-block mbl" required>
                <option>选择已有的对话</option>
              <% foreach (var dialog in dialogs) { %> 
                <option value="<%:dialog.DIALOG_ID %>">
                    <%: dialog.CONTACT_NAME %>
                </option>
                <% } %>
            </select>
        </div>
    </div>
        
    <div class="form-group">
        <label for="address" class="col-sm-2 control-label">创建新的对话</label>
        <div class="col-sm-6">
            <input type="text" class="form-control" id="address" name="newdialog" placeholder="输入对方email" >
        </div>
    </div>

      <div class="form-group">
        <div class="col-sm-offset-2 col-sm-6">
          <asp:Button runat="server" OnClick="SelectDialog" Text="确定" CssClass="btn btn-primary" />
        </div>
      </div>

    
    </form>
</asp:Content>

<asp:Content ContentPlaceHolderID="CustomScriptContent" runat="server">
  <%: Scripts.Render("~/scripts/BootstrapSelect") %>
  <script type="text/javascript">
    $("select").selectpicker({ style: 'btn-hg btn-primary', menuStyle: 'dropdown-inverse' });
  </script>
</asp:Content>
