namespace MemeCentral.Server
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;
    using Microsoft.AspNet.Identity;

    using Data.Models;
    using Events;
    using Controls;
    using System.Collections.Generic;

    public partial class MemeDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Meme MemeViewArticle_GetItem([QueryString("id")]int? id)
        {
            var meme = this.dbContext.Memes.Where(x => x.Id == id).FirstOrDefault();

            if (id == null | meme == null)
            {
                this.Response.Redirect("/NotFound");
            }

            return meme;
        }

        protected void CommentControl_Comment(object sender, CommentEventArgs e)
        {
            var userID = this.User.Identity.GetUserId();
            var meme = this.dbContext.Memes.Find(e.DataID);
            var comment = new Comment() { MemeId = meme.Id, UserId = userID, Content = e.Content, CreationDate = DateTime.Now };
            meme.Comments.Add(comment);
            this.dbContext.SaveChanges();

            // Visualise all the comments TODO
            var control = sender as CommentControl;
            control.Comments = meme.Comments.OrderByDescending(x => x.CreationDate).ToList();
        }

        protected List<Comment> GetComments(Meme item)
        {
            return item.Comments.OrderByDescending(x => x.CreationDate).ToList();
        }

        protected int GetLikes(Meme item)
        {
            //return item.Likes;
            return 5;
        }

        protected int GetDislikes(Meme item)
        {
            //return item.Dislikes;
			return 2;
        }

        protected void LikeControl_Like(object sender, LikeEventArgs e)
        {
            var userID = this.User.Identity.GetUserId();
            var meme = this.dbContext.Memes.Find(e.DataID);

            //meme.Likes++;
            this.dbContext.SaveChanges();

            var control = sender as LikeControl;
            //control.Likes = meme.Likes;
            //control.Dislikes = meme.Dislikes;
        }

        protected void LikeControl_Dislike(object sender, DislikeEventArgs e)
        {
            var userID = this.User.Identity.GetUserId();
            var meme = this.dbContext.Memes.Find(e.DataID);

            //meme.Dislikes++;
            this.dbContext.SaveChanges();

            var control = sender as LikeControl;
            //control.Likes = meme.Likes;
            //control.Dislikes = meme.Dislikes;
        }
    }
}