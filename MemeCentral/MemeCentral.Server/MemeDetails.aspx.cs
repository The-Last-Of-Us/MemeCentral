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
            return item.Likes.Where(x => x.Value == true)
                .ToList()
                .Count();
        }

        protected int GetDislikes(Meme item)
        {
            return item.Likes.Where(x => x.Value == false)
                .ToList()
                .Count();
        }

        protected int HasUserVoted(Meme Item)
        {
            var userID = this.User.Identity.GetUserId();
            var hasUserVoted = Item.Likes
                .Where(x => x.UserId == userID)
                .FirstOrDefault();

            if(hasUserVoted == null)
            {
                return -1;
            }

            return 1;
        }

        protected void LikeControl_Like(object sender, LikeEventArgs e)
        {
            var userID = this.User.Identity.GetUserId();
            var meme = this.dbContext.Memes.Find(e.DataID);
            var rating = new Like();
            rating.MemeId = e.DataID;
            rating.UserId = userID;
            if (e.LikeValue == 1)
            {
                rating.Value = true;
            }
            else
            {
                rating.Value = false;
            }

            meme.Likes.Add(rating);
            this.dbContext.SaveChanges();

            var control = sender as LikeControl;
            control.Likes = this.GetLikes(meme);
            control.Dislikes = this.GetDislikes(meme);
            control.UserHasVoted = 1;
        }

    }
}