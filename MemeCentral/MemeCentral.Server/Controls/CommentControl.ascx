<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentControl.ascx.cs" Inherits="MemeCentral.Server.Controls.CommentControl" %>

<asp:UpdatePanel runat="server" ID="ControlWrapper">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-12">
                <div>Comment</div>
                <div>
                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="UserContent" CssClass="commentInput" TextMode="MultiLine" />
                        <asp:Label runat="server"
                           CssClass="text-danger"
                           Text="Please say a word"
                           Visible="false"
                           ID="ErrMsg" />
                    </div>
                    <div class="col-md-10"></div>
                    <div class="col-md-2">
                         <asp:LinkButton runat="server" Text="Comment" ID="ButtonLike" CssClass="btn btn-success commentButton" CommandArgument="<%# this.ItemId %>" CommandName="Comment" OnCommand="ButtonComment_Command" />
                    </div>                   
                </div>
            </div>
        </div>
        <div class="row">
            <asp:Repeater runat="server" ID="AllComments" ItemType="MemeCentral.Data.Models.Comment">
                <ItemTemplate>
                    <div class="col-md-12 commentMessage">
                        <div class="col-md-12">
                            <strong>
                                <%#:Item.Content %>
                            </strong>
                        </div>
                        <div class="col-md-12 userTag">
                            <a href="/">by: <%#: GetUserName(Item) %></a>
                        </div>
                    </div>
                    <hr />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
