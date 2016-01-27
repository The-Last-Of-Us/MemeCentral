<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMeme.aspx.cs" Inherits="MemeCentral.Server.AddMeme" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<div class="row">
    <div class="col-md-8 col-md-offset-2 jumbotron form-horizontal">
        <legend>New Meme</legend>
        <div class="row">
            <div class="col-md-7">
                 <asp:Panel runat="server" ID="TitleFormGroup" CssClass="row form-group">
                    <div class="col-md-5">
                        <asp:Label runat="server" AssociatedControlID="Title" CssClass="control-label">Title: </asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="Title" TextMode="SingleLine" CssClass="form-control" placeholder="Title"></asp:TextBox>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="MemeUrlFormGroup" CssClass="row form-group">
                    <div class="col-md-5">
                        <asp:Label runat="server" AssociatedControlID="MemeUrl"  CssClass="control-label">Meme Url :</asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox runat="server" ID="MemeUrl" TextMode="SingleLine" AutoPostBack="true" OnTextChanged="UpdateMemeImg" CssClass="form-control" placeholder="Meme Url"></asp:TextBox>
                    </div>
                </asp:Panel>
                <asp:Button runat="server" ID="CreateButton" OnClick="CreateMeme" Text="Create" CssClass="btn btn-primary" />
            </div>
            <div class="col-md-5 text-right">
                <asp:Image runat="server" ID="MemeImg" Width="150" Height="150" />
            </div>
        </div>

    </div>
</div> 
</asp:Content>