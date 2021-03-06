﻿namespace MemeCentral.Server.Controls
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;

    using Events;
    using Data.Models;
    using Data;
    using Common;

    public partial class CommentControl : UserControl
    {
        public List<Comment> Comments { get; set; }

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
            if(this.Comments != null)
            {
                this.AllComments.DataSource = this.Comments;
                this.AllComments.DataBind();
            }

        }

        protected string GetUserName(Comment item)
        {
            var db = new MemeDbContext();
            var userName = db.Users.Find(item.UserId).UserName;
            return userName;
        }

        protected void ButtonComment_Command(object sender, CommandEventArgs e)
        {
            if(this.UserContent.Text.Length == 0 || this.UserContent.Text.Length > ValidationConstants.CommentMaxLength)
            {
                this.ErrMsg.Visible = true;
                return;
            }
            this.Comment(this, new CommentEventArgs(Convert.ToInt32(e.CommandArgument), this.UserContent.Text));
        }

    }
}