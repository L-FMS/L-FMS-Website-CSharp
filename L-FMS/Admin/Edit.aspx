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
                  <label class='col-lg-2 control-label'>用户ID</label>
                  <div class='col-lg-10'>
                    <p class="form-control-static"><%=editAccount.USER_ID %></p>
                    <input class='form-control' placeholder='ID'name="user_id" type='hidden' value="<%=editAccount.USER_ID %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>名字</label>
                  <div class='col-lg-10'>
                    <p class="form-control-static"><%=editUserInfo.USER_NAME %></p>
                  </div>
                </div>
                
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>密码</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='密码' type='text' name="acc_password" value="<%=editAccount.PASSWORD %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>邮箱</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='邮箱' type='email' name="acc_email" value="<%=editAccount.EMAIL %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>手机</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='手机' type='tel' name="user_phone" value="<%=editUserInfo.PHONE %>" required>
                  </div>
                </div>
              </fieldset>
              <div class='form-actions'>
                <asp:Button CssClass='btn btn-default' Text="更新" OnClick="update_user" runat="server"></asp:Button>
                <a class='btn' href="Usertable.aspx">取消</a>
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
                  <label class='col-lg-2 control-label'>物品ID</label>
                  <div class='col-lg-10'>
                    <p class="form-control-static"><%=editItem.ITEM_ID %></p>
                    <input class='form-control' placeholder='ID' name="item_id" type='hidden' value="<%=editItem.ITEM_ID %>" required>
                  </div>
                </div>
                
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>物品名</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='物品名' name="item_name" type='text' value="<%=editItem.ITEM_NAME %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>地点</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='地点' name="item_place" type='text' value="<%=editPublishment.PLACE %>" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>物品描述</label>
                  <div class='col-lg-10'>
                    <textarea placeholder='物品描述' cols="30" name="item_des" rows="3" class='form-control' required><%=editItem.ITEM_DESCRIPTION %></textarea>
                  </div>
                </div>
              </fieldset>
              <div class='form-actions'>
                <asp:Button CssClass='btn btn-default' Text="更新" OnClick="update_item" runat="server"></asp:Button>
                <a class='btn' href="Itemtable.aspx">取消</a>
              </div>
            </form>
          </div>
        </div>
        <%} %>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
</asp:Content>
