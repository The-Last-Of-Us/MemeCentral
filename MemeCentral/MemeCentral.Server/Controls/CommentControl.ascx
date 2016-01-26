<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentControl.ascx.cs" Inherits="MemeCentral.Server.Controls.CommentControl" %>

<asp:UpdatePanel runat="server" ID="ControlWrapper">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-12">
                <div>Comment</div>
                <div>
                    <asp:TextBox runat="server" ID="UserContent" />
                    <asp:LinkButton runat="server" Text="Comment" ID="ButtonLike" CssClass="btn btn-success" CommandArgument="<%# this.ItemId %>" CommandName="Comment" OnCommand="ButtonComment_Command" />
                </div>
            </div>
        </div>
        <div class="row">
            <asp:Repeater runat="server" ID="AllComments" ItemType="MemeCentral.Data.Models.Comment">
                <ItemTemplate>
                    <div class="col-md-12 commentMessage">
                        <%#:Item.Content %>
                        
                        <hr />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
