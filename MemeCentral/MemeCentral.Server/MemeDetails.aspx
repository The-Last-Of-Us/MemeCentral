<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemeDetails.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MemeCentral.Server.MemeDetails" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="row container">
        <div class="col-md-12 text-center">Title</div>
        <div class="col-md-4"><img src="http://impreza.us-themes.com/wp-content/uploads/img-6.jpg" class="image-container img-rounded" /></div>
        <div class="col-md-6"><p id="authorComment" runat="server"><%#: this.A %></p></div>
    </div>
    <br />
    <div class="row">
         <div class="col-md-12">Like/Dislike</div>
        <div class="col-md-12">Add Comment</div>
        <div class="col-md-12">All comments</div>
    </div>
    
</asp:Content>
