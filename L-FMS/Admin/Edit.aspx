<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="L_FMS.Admin.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CustomStylesheetContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div id ="content">
    <div class='panel panel-default'>
          <div class='panel-heading'>
            <i class='icon-edit icon-large'></i>
            User Table
          </div>
          <div class='panel-body'>
            <form class='form-horizontal' action="" method="POST" role="form">
              <fieldset>
                <legend>Edit User</legend>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>ID</label>
                  <div class='col-lg-10'>
                    <p class="form-control-static">12</p>
                    <input class='form-control' placeholder='ID' type='hidden' value="12" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Name</label>
                  <div class='col-lg-10'>
                    <p class="form-control-static">Tom</p>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Username</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Username' type='text' value="sdfdsa" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Password</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Password' type='text' value="asdfsad" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Email</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Email' type='email' value="adsf@adsf.com" required>
                  </div>
                </div>
                <div class='form-group'>
                  <label class='col-lg-2 control-label'>Phone</label>
                  <div class='col-lg-10'>
                    <input class='form-control' placeholder='Phone' type='tel' value="1231231" required>
                  </div>
                </div>
              </fieldset>
              <div class='form-actions'>
                <button class='btn btn-default' type='submit'>Update</button>
                <a class='btn' href='#'>Cancel</a>
              </div>
            </form>
          </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomScriptContent" runat="server">
</asp:Content>
