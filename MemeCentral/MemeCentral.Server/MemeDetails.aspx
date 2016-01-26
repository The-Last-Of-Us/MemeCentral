<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemeDetails.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MemeCentral.Server.MemeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="MemeViewArticle" ItemType="MemeCentral.Data.Models.Meme" SelectMethod="MemeViewArticle_GetItem">
        <ItemTemplate>
            <div class="row container">
                <div class="col-md-12 text-center"><%#: Item.Title %></div>
                <div class="col-md-4">
                    <img src="<%#:Item.ImageUrl %>" class="image-container img-rounded" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <p id="P2" runat="server"><%#: Item.Likes %></p>
                    <p id="P3" runat="server"><%#: Item.Dislikes %></p>
                </div>
                <div class="col-md-12">Add Comment</div>
                <div class="col-md-12">All comments</div>
            </div>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
