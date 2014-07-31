<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.Master" AutoEventWireup="true" CodeBehind="Itemtable.aspx.cs" Inherits="L_FMS.Admin.Itemtable1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div id='content'>
    <!-- Lost Table -->
        <div class='panel panel-default grid'>
          <div class='panel-heading'>
            <i class='icon-table icon-large'></i>
            Lost Table
            <div class='panel-tools'>
              <div class='btn-group'>
                <a class='btn' data-toggle='toolbar-tooltip' href='#' title='Reload'>
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

                 <form method="post" runat="server" role="form">
                    <div class='input-group'>
                        <input name="itemkeyword" class='form-control' placeholder='Quick search...' type='text'>
                        <span class='input-group-btn'>
                            <asp:Button runat="server" CssClass="btn" Text="搜索" OnClick="Item_Search" />
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
                <th>Publisher</th>
                <th>Item</th>
                <th>Publishdate</th>
                <th>Place</th>
                <th>Is_End</th>
                <th>EndTime</th>
                <th class='actions'>
                  Actions
                </th>
              </tr>
            </thead>
            <tbody>
               <%foreach (var item in pubs)
                  { %>
                <tr <% if (item.IS_END == 1){%>class ='success'<%} else if (item.TYPE == "lost") {%> class="danger" <%} else if (item.TYPE == "find") {%> class="info" <%} %>>
                    <td><%: item.ID %></td>
                    <td><%: item.PUBLISHER_ID %></td>
                    <td><%: item.ITEM_ID %></td>
                    <td><%: item.PUBLISH_DATE %></td>
                    <td><%: item.PLACE %></td>
                    <td><%: item.IS_END %></td>
                    <td><%: item.END_TIME %></td>
                    <td class='action'>
                  <a class='btn btn-info' href=<% ="Edit.aspx?editItemID="+item.ITEM_ID%>>
                    <i class='icon-edit'></i>
                  </a>
                  <a class='btn btn-danger' href=<% ="Itemtable.aspx?"+ "delete="+item.ITEM_ID%>>
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
