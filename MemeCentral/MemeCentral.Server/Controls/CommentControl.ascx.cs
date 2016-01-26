namespace MemeCentral.Server.Controls
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Events;

    public partial class CommentControl : UserControl
    {
        public string Comments { get; set; }

        public int ItemId { get; set; }

        public delegate void CommentEventHandler(object sender, CommentEventArgs e);

        public event CommentEventHandler Comment;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    this.ButtonLike.Visible = false;
            //    this.ButtonDislike.Visible = false;
            //}
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //TODO Pass comments to some repeater thing

        }

        protected void ButtonComment_Command(object sender, CommandEventArgs e)
        {
            this.Comment(this, new CommentEventArgs(Convert.ToInt32(e.CommandArgument), this.UserContent.Text));
        }

    }
}