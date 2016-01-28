<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MemeCentral.Server._Default" %>
<%@ OutputCache Duration=600 VaryByParam="None" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center"><strong>Welcome to MemeCentral</strong></h1>
        <h2 class="text-center">All types of memes sharing website</h2>
    </div>

    <div class="row">
        <div class="col-md-4 text-center">
            <img src="images/cool_face.png" />
        </div>
        <div class="col-md-4 text-center">
            <img src="images/LOLGuy.png" />
        </div>
        <div class="col-md-4 text-center">
            <img src="images/Y_U_NO_(meme).png" />
        </div>
    </div>
    <hr />
    <div class="row">
        <h2 class="text-center text-danger"><strong>Top most liked memes</strong></h2>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <asp:Repeater runat="server" ID="AllMemesGrid" ItemType="MemeCentral.Data.Models.Meme">
                    <ItemTemplate>
                        <div class="col-md-4 image-grid-container">
                            <div class="col-md-12 text-center"><%#: Item.Title %></div>
                            <asp:ImageButton ImageUrl="<%#: Item.ImageUrl %>" CssClass="memeImgDetail img-rounded" CommandName="Id" CommandArgument="<%#: Item.Id %>" runat="server" OnClick="Unnamed_Click" />
                            <div class="col-md-1 likeButton text-center">
                                <asp:Label runat="server" ID="LikesValue" Text="<%# this.GetLikes(Item) %>" />
                            </div>
                            <div class="col-md-1 dislikeButton text-center">
                                <asp:Label runat="server" ID="DislikesValue" Text="<%# this.GetDislikes(Item) %>" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>
