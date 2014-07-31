<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="L_FMS.Admin.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div id ="content">

        <% if(editType=="User") {%>
    <div class='panel panel-default'>
          <div class='panel-heading'>


            <i class='icon-edit icon-large'></i>

              
            User Table
          </div>
          <div class='panel-body'>
            <form class='form-horizontal' action="" method="POST" role="form" runat="server">
              <fieldset>
                <legend>Edit User</legend>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>ID</label>
                  <div class='col-lg-10'>
                    <p class="form-control-static"><%=editAccount.USER_ID %></p>
                    <input class='form-control' placeholder='ID'name="user_id" type='hidden' value="<%=editAccount.USER_ID %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Name</label>
                  <div class='col-lg-10'>
                    <p class="form-control-static"><%=editUserInfo.USER_NAME %></p>
                  </div>
                </div>
                
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Password</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Password' type='text' name="acc_password" value="<%=editAccount.PASSWORD %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Email</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Email' type='email' name="acc_email" value="<%=editAccount.EMAIL %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Phone</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Phone' type='tel' name="user_phone" value="<%=editUserInfo.PHONE %>" required>
                  </div>
                </div>
              </fieldset>
              <div class='form-actions'>
                <asp:Button CssClass='btn btn-default' Text="update" OnClick="update_user" runat="server"></asp:Button>
                <a class='btn' href="Usertable.aspx">Cancel</a>
              </div>
            </form>
          </div>
        </div>
        <% }else{ %>
          <!-- item Table -->
        <div class='panel panel-default'>
          <div class='panel-heading'>
            <i class='icon-edit icon-large'></i>
            Item Table
          </div>
          <div class='panel-body'>
            <form class='form-horizontal' action="" method="POST" role="form" runat="server">
              <fieldset>
                <legend>Edit Lost Item</legend>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>ID</label>
                  <div class='col-lg-10'>
                    <p class="form-control-static"><%=editItem.ITEM_ID %></p>
                    <input class='form-control' placeholder='ID' name="item_id" type='hidden' value="<%=editItem.ITEM_ID %>" required>
                  </div>
                </div>
                
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Lost item name</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Lost item name' name="item_name" type='text' value="<%=editItem.ITEM_NAME %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Lost place</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Lost place' name="item_place" type='text' value="<%=editPublishment.PLACE %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Description</label>
                  <div class='col-lg-10'>
                    <textarea placeholder='Description' cols="30" name="item_des" rows="3" class='form-control' required><%=editItem.ITEM_DESCRIPTION %></textarea>
                  </div>
                </div>
              </fieldset>
              <div class='form-actions'>
                <asp:Button CssClass='btn btn-default' Text="update" OnClick="update_item" runat="server"></asp:Button>
                <a class='btn' href="Itemtable.aspx">Cancel</a>
              </div>
            </form>
          </div>
        </div>
        <%} %>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
</asp:Content>
