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
              <h3 class="media-heading">张睿</h3>
              <p>doubizhang@sse.net</p>
              <p>1994年2月30日</p>
              <p>男</p>
            </div>
          </div>
        </div>

        <div class="panel-body" id="profile-panel-body">
          <ul class="nav nav-tabs nav-justified" role="tablist">
            <li class="active"><a href="#found" role="tab" data-toggle="tab">Found</a></li>
            <li><a href="#lost" role="tab" data-toggle="tab">Lost</a></li>
          </ul><!-- /.nav-tabs -->

          <div class="tab-content">
            <div class="tab-pane active" id="found">
              ddd
            </div><!-- /.tab-pane#found -->

            <div class="tab-pane" id="lost">
              deee
            </div><!-- /.tab-pane#lost -->
          </div><!-- /.tab-content -->
        </div>
      </div>
    </div>
  </div><!-- /.row -->
</asp:Content>
