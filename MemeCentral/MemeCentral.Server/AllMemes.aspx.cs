namespace MemeCentral.Server
{
    using MemeCentral.Data.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class AllMemes : BasePage
    {
        public List<Meme> Memes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Skip = 0;
                this.Take = 10;
                this.Memes = this.dbContext.Memes
                    .OrderByDescending(x => x.CreationDate)
                    .Skip(this.Skip)
                    .Take(this.Take)
                    .ToList();
                this.AllMemesGrid.DataSource = this.Memes;
                this.AllMemesGrid.DataBind();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {


        }

        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            var meme = sender as ImageButton;
            var memeId = meme.CommandArgument;
            this.Response.Redirect("/MemeDetails?id=" + memeId);
        }

        protected void ButtonShowMore_Click(object sender, EventArgs e)
        {
            //this.Skip += 10;
            this.Take += 10;
            this.Memes = this.dbContext.Memes
                .OrderByDescending(x => x.CreationDate)
                .Skip(this.Skip)
                .Take(this.Take)
                .ToList();
            this.AllMemesGrid.DataSource = this.Memes;
            this.AllMemesGrid.DataBind();
        }

        private int Skip
        {
            get
            {
                if (ViewState["Skip"] != null)
                {
                    return Convert.ToInt32(ViewState["Skip"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["Skip"] = value; }
        }

        private int Take
        {
            get
            {
                if (ViewState["Take"] != null)
                {
                    return Convert.ToInt32(ViewState["Take"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["Take"] = value; }
        }

        protected void ShowOnlyMine_CheckedChanged(object sender, EventArgs e)
        {
            var userID = this.User.Identity.GetUserId();

            var result = this.dbContext.Memes
                .Where(x => x.UserId == userID)
                .ToList();
            if (result != null)
            {
                this.AllMemesGrid.DataSource = result;
                this.DataBind();
            }

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var titleToSearch = this.SearchByUserName.Text;
            var result = this.dbContext.Memes
                .Where(x => x.Title.IndexOf(titleToSearch) > -1)
                .OrderByDescending(x => x.CreationDate)
                .Skip(this.Skip)
                .Take(this.Take)
                .ToList();
            if (result != null)
            {
                this.AllMemesGrid.DataSource = result;
                this.DataBind();
            }
            //No results found message maybe

        }

        protected void OrderByDate_Click(object sender, CommandEventArgs e)
        {
            var button = sender as Button;
            var cmdName = button.CommandName;
            var isAsc = cmdName == "Asc" ? true : false;
            if (isAsc)
            {
                this.AllMemesGrid.DataSource = this.dbContext.Memes
                    .OrderBy(x => x.CreationDate)
                    .Skip(this.Skip)
                    .Take(this.Take)
                    .ToList();
            }
            else
            {
                this.AllMemesGrid.DataSource = this.dbContext.Memes
                    .OrderByDescending(x => x.CreationDate)
                    .Skip(this.Skip)
                    .Take(this.Take)
                    .ToList();
            }

            this.AllMemesGrid.DataBind();
        }

        protected void OrderByLikes_Click(object sender, EventArgs e)
        {
            this.AllMemesGrid.DataSource = this.dbContext.Memes.OrderByDescending(x => x.Likes.Count(like => like.Value))
                .Skip(this.Skip)
                .Take(this.Take)
                .ToList();

            this.AllMemesGrid.DataBind();
        }

		protected void OrderByDisikes_Click(object sender, EventArgs e)
		{
			this.AllMemesGrid.DataSource = this.dbContext.Memes.OrderByDescending(x => x.Likes.Count(like => !like.Value))
				.Skip(this.Skip)
				.Take(this.Take)
				.ToList();

			this.AllMemesGrid.DataBind();
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