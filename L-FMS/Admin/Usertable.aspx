<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.Master" AutoEventWireup="true" CodeBehind="Usertable.aspx.cs" Inherits="L_FMS.Admin.forms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div id='content'>

        <!-- User Table -->
        <div class='panel panel-default grid'>
          <div class='panel-heading'>
            <i class='icon-table icon-large'></i>
            User Table
            <div class='panel-tools'>
              <div class='btn-group'>
                <a class='btn' data-toggle='toolbar-tooltip' title='Reload' runat="server" onserverclick="Page_Load" >
                  <i class='icon-refresh'></i>
                </a>
              </div>
            </div>
          </div>
          <div class='panel-body filters'>
            <div class='row'>
              <div class='col-md-9'>
                Add your custom filters here...
              </div>
              <div class='col-md-3'>
                  <form id="a" method="post" runat="server" role="form">
                    <div class='input-group'>
                        <input name="userkeyword" class='form-control' placeholder='Quick search...' type='text'>
                        <span class='input-group-btn'>
                            <asp:Button runat="server" CssClass="btn" Text="搜索" OnClick="User_Search" />
                        </span>
                    </div>
                  </form>                 
              </div>
            </div>
          </div>
          <table class='table table-hover'>
            <thead>
              <tr>
                <th>#</th>
                <th>Email</th>
                <th>Privilege</th>
                <th>Verified</th>
                <th class='actions'>
                  Actions
                </th>
              </tr>
            </thead>
            <tbody>

            <%foreach (var user in users)
                  { %>
                <tr <% if (user.VERIFIED == 0){%>class ='warning'<%} else if (user.PRIVILEGE == 0) {%> class="info" <%} %>>
                    <td><%: user.USER_ID %></td>
                    <td><%: user.EMAIL %></td>
                    <td><%: user.PRIVILEGE %></td>
                    <td><%: user.VERIFIED %></td>
                    <td class='action'>
                  <a class='btn btn-info'  href=<%= "Edit.aspx?editUserID="+user.USER_ID+" " %>>
                    <i class='icon-edit'></i>
                  </a>
                  <a class='btn btn-danger'  href=<%="Usertable.aspx?delete="+user.USER_ID+" " %>>
                    <i class='icon-trash'></i>
                  </a>
                </td>
                </tr>
            <% } %>

 
            </tbody>
          </table>
        </div>

       

      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
</asp:Content>
