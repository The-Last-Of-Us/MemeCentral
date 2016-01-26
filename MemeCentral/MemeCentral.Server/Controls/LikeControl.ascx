<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeControl.ascx.cs" Inherits="MemeCentral.Server.Controls.LikeControl" %>

<asp:UpdatePanel runat="server" ID="ControlWrapper">
    <ContentTemplate>
        <div class="col-md-12">
            <div>Rating</div>
            <div>
                <asp:LinkButton runat="server" ID="ButtonLike" CssClass="btn btn-default glyphicon glyphicon-chevron-up" CommandArgument="<%# this.ItemId %>" CommandName="Like" OnCommand="ButtonLike_Command" />
                <asp:LinkButton runat="server" ID="ButtonDislike" CssClass="btn btn-default glyphicon glyphicon-chevron-down" CommandArgument="<%# this.ItemId %>" CommandName="Dislike" OnCommand="ButtonDislike_Command" />
                <asp:Label runat="server" ID="LikesValue" />
                <asp:Label runat="server" ID="DislikesValue" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>