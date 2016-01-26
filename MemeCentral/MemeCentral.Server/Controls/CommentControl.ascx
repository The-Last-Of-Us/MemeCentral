<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentControl.ascx.cs" Inherits="MemeCentral.Server.Controls.CommentControl" %>

<asp:UpdatePanel runat="server" ID="ControlWrapper">
    <ContentTemplate>
        <div class="col-md-1">
            <div>Rating</div>
            <div>
                <asp:TextBox runat="server" ID="UserContent" />
                <asp:LinkButton runat="server" ID="ButtonLike" CssClass="btn btn-success" CommandArgument="<%# this.ItemId %>" CommandName="Comment" OnCommand="ButtonComment_Command" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>