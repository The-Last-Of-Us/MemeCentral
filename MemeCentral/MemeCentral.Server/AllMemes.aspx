<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllMemes.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MemeCentral.Server.AllMemes" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server" ID="ControlWrapper">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <div>Search</div>
                </div>
                <div class="col-md-12 searchQueryGroup">
                    <asp:TextBox runat="server" ID="SearchByUserName" placeholder="Search by UserName" />
                    <asp:Button runat="server" CssClass="btn btn-primary" ID="SearchButton" OnClick="SearchButton_Click" Text="Search" />
                </div>
                <div class="col-md-12 searchQueyGroup">
                    <asp:Button runat="server" ID="OrderByDateAcs" Text="ByDateAsc" CssClass="btn btn-primary" CommandName="Asc" CommandArgument="Eat" OnCommand="OrderByDate_Click" />
                    <asp:Button runat="server" ID="OrderByDateDesc" Text="ByDateDesc" CssClass="btn btn-primary" CommandName="Desc" CommandArgument="d" OnCommand="OrderByDate_Click" />
                    <asp:Button runat="server" ID="OrderByLikes" Text="ByLikes" CssClass="btn btn-primary" CommandName="Likes" CommandArgument="i" OnCommand="OrderByLikes_Click" />
                    <asp:Button runat="server" ID="OrderByDislikes" Text="ByDislikes" CssClass="btn btn-primary" CommandName="Dislikes" CommandArgument="c" OnCommand="OrderByDisikes_Click" />
                    <asp:Button ID="ShowOnlyMine"
                        GroupName="GroupName"
                        Text="ShowOnlyYours"
                        TextAlign="Left"
                        AutoEventWireup="True"
                        CssClass="btn btn-warning"
                        OnClick="ShowOnlyMine_CheckedChanged"
                        runat="server" />

                </div>
            </div>
            <div class="row">
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
            <div class="row showMoreBtn">
                <asp:Button runat="server" ID="ShowMore" OnClick="ButtonShowMore_Click"
                     CssClas="btn btn-default text-center showMoreBtn" Text="Show More" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
