﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemeDetails.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MemeCentral.Server.MemeDetails" %>

<%@ Register Src="~/Controls/LikeControl.ascx" TagPrefix="uc" TagName="LikeControl" %>
<%@ Register Src="~/Controls/CommentControl.ascx" TagPrefix="uc" TagName="CommentControl" %>

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
                <uc:LikeControl runat="server" ID="LikeControl"
                Likes="<%# GetLikes(Item) %>"
                Dislikes="<%# GetDislikes(Item) %>"
                ItemId="<%# Item.Id %>"
                OnLike="LikeControl_Like"
                OnDislike="LikeControl_Dislike" />
                </div>
            </div>
                <div class="row">
                <div class="col-md-12">
                <uc:CommentControl runat="server" ID="CommentControl"
                ItemId="<%# Item.Id %>"
                OnComment="CommentControl_Comment"/>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>
