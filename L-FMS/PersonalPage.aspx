<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeBehind="PersonalPage.aspx.cs" Inherits="L_FMS.PersonalPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-sm-12">
      <div class="panel panel-default" id="profile-panel">
        <div class="panel-heading" id="profile-panel-heading">
          <div class="media">
            <div class="pull-left">
              <img class="media-object img-thumbnail" src="images/zr.jpg" alt="Zhangrui" style="width: 200px;">
            </div>
            <div class="media-body">
              <h3 class="media-heading"><%=message.USER_NAME %></h3>
              <p><%=message.EMAIL %></p>
              <p><%=message.BIRTH.ToString("yyyy年MM月dd日") %></p>
              <p><%=message.SEX %></p>
            </div>
          </div>
        </div>

        <div class="panel-body" id="profile-panel-body">
          <ul class="nav nav-tabs nav-justified" role="tablist">
            <li class="active">
              <a href="#found" role="tab" data-toggle="tab">
                <span class="badge pull-right"><%: found.Length != 0 ? found.Length.ToString() : "" %></span> 我找到的物品
              </a>
            </li>
            <li>
              <a href="#lost" role="tab" data-toggle="tab">
                <span class="badge pull-right"><%: lost.Length != 0 ? lost.Length.ToString() : "" %></span> 我丢失的物品
              </a>
            </li>
          </ul><!-- /.nav-tabs -->

          <div class="tab-content" style="min-height: 250px;">
            <div class="tab-pane active" id="found">
              <div class="table-responsive">
                <table class="table table-hover">
                  <thead>
                    <tr>
                      <th>物品名</th>
                      <th>发布时间</th>
                      <th>地点</th>
                    </tr>
                  </thead>
                  <tbody>
                    <% foreach (var i in found) {%>
                    <tr>
                      <td><%: i.ITEM_NAME %></td>
                      <td><%: i.PUBLISH_DATE.ToString() %></td>
                      <td><%: i.PLACE %></td>
                    </tr>
                    <% } %>
                  </tbody>
                </table>
              </div>
            </div><!-- /.tab-pane#found -->

            <div class="tab-pane" id="lost">
              <div class="table-responsive">
                <table class="table table-hover">
                  <thead>
                    <tr>
                      <th>物品名</th>
                      <th>发布时间</th>
                      <th>地点</th>
                    </tr>
                  </thead>
                  <tbody>
                    <% foreach (var i in lost) {%>
                    <tr>
                      <td><%: i.ITEM_NAME %></td>
                      <td><%: i.PUBLISH_DATE.ToString() %></td>
                      <td><%: i.PLACE %></td>
                    </tr>
                    <% } %>
                  </tbody>
                </table>
              </div>
            </div><!-- /.tab-pane#lost -->
          </div><!-- /.tab-content -->
        </div>
      </div>
    </div>
  </div><!-- /.row -->
</asp:Content>
