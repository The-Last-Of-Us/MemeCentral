namespace MemeCentral.Server.Controls
{
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using MemeCentral.Server.Events;

    public partial class LikeControl : UserControl
    {
        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public int ItemId { get; set; }

        public int CurrentUserVote { get; set; }

        public delegate void LikeEventHandler(object sender, LikeEventArgs e);

        public event LikeEventHandler Like;

        public delegate void DislikeEventHandler(object sender, DislikeEventArgs e);

        public event DislikeEventHandler Dislike;

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
            this.LikesValue.Text = this.Likes.ToString();
            this.DislikesValue.Text = this.Dislikes.ToString();

            //if (this.CurrentUserVote > 0)
            //{
            //    this.ButtonLike.Visible = false;
            //    this.ButtonDislike.Visible = true;
            //}
            //else if (this.CurrentUserVote < 0)
            //{
            //    this.ButtonLike.Visible = true;
            //    this.ButtonDislike.Visible = false;
            //}
        }

        protected void ButtonLike_Command(object sender, CommandEventArgs e)
        {
            this.Like(this, new LikeEventArgs(Convert.ToInt32(e.CommandArgument), 1));
        }

        protected void ButtonDislike_Command(object sender, CommandEventArgs e)
        {
            this.Dislike(this, new DislikeEventArgs(Convert.ToInt32(e.CommandArgument), 1));
        }
    }
}