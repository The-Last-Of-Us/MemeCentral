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
                <asp:Button runat="server" ID="OrderByDateAcs" Text="ByDateAsc" CssClass="btn btn-primary" />
                <asp:Button runat="server" ID="OrderByDateDesc" Text="ByDateDesc" CssClass="btn btn-primary" />
                <asp:Button runat="server" ID="OrderByLikes" Text="ByLikes" CssClass="btn btn-primary"/>
                <asp:Button runat="server" ID="OrderByDislikes" Text="ByDislikes" CssClass="btn btn-primary"/>
                <asp:RadioButton id="ShowOnlyMine" 
                 Checked="False"
                 GroupName="GroupName"
                 Text="ShowOnlyYours"
                 TextAlign="Left"
                 OnCheckedChanged="ShowOnlyMine_CheckedChanged"
                 runat="server"/>

                </div>
            </div>
            <div class="row">
                <asp:Repeater runat="server" ID="AllMemesGrid" ItemType="MemeCentral.Data.Models.Meme">
                    <ItemTemplate>
                        <div class="col-md-4 image-grid-container">
                            <asp:ImageButton ImageUrl="<%#: Item.ImageUrl %>" CssClass="memeImgDetail img-rounded" CommandName="Id" CommandArgument="<%#: Item.Id %>" runat="server" OnClick="Unnamed_Click" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row">
                <asp:Repeater ID="Pager" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
                            OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
