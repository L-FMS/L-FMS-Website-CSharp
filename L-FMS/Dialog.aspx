<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="Dialog.aspx.cs" Inherits="L_FMS.Dialog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form  method="POST" runat="server">
    <asp:GridView   ID="dialog" CssClass="table table-hover"  runat="server" AutoGenerateColumns="false" BorderWidth="0px" GridLines="None"  AllowPaging="true" PageSize="10 " PagerSettings-Visible="false">
          <columns>
            <asp:BoundField DataField="id" HeaderText="信息ID" />
            <asp:BoundField DataField="date" HeaderText="发表时间" />
            <asp:BoundField DataField="sender" HeaderText="发信人" />
             <asp:BoundField DataField="content" HeaderText="内容" />
          </columns>
    </asp:GridView>
  
    <div class="item-comment-box">
          <div class="form-group">
            <label for="comment-content" class="sr-only">Email address</label>
            <textarea name="comment" class="form-control" id="comment-content" placeholder="发新信息..." maxlength="140" onkeypress="if(event.keyCode==13) return false;"></textarea>
          </div>
          <div class="comment-btn">
            <asp:Button CssClass="btn btn-inverse" runat="server" OnClick="Comment_Submit" Text="发送"/>
            <button class="btn btn-link" id="comment-cancel">取消</button>
          </div>
        
      </div><!-- /.item-comment-box -->
        
    <div class="clearfix">
        <ul class="pager" style="float: right;">
          <li class="previous"><a href="#"><asp:Button runat="server" OnClick="found_pre_click"  Text="&larr; 上一页" BackColor="transparent" BorderWidth="0px"/></a></li>
          <li class="next"  ><a href="#" ><asp:Button runat="server" OnClick="found_next_click"  Text="下一页 &rarr;" BackColor="transparent" BorderWidth="0px"/></a></li>
        </ul>
          
        <em class="text-muted" style="float: left;">Page <%=this.dialog.PageIndex+1 %> of <%=dialog_amount %></em>
      </div>
        </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
</asp:Content>
