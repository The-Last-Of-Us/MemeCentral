using MemeCentral.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemeCentral.Server
{
    public partial class _Default : BasePage
    {
        public List<Meme> Memes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Memes = this.dbContext.Memes.ToList();
                //this.AllMemesGrid.DataSource = this.Memes;
                this.AllMemesGrid.DataSource = this.dbContext.Memes.OrderByDescending(x => x.Likes.Count).ToList();
                this.AllMemesGrid.DataBind();
            }
        }

        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            var meme = sender as ImageButton;
            var memeId = meme.CommandArgument;
            this.Response.Redirect("/MemeDetails?id=" + memeId);
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
    }
}