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
                this.Memes = this.dbContext.Memes.ToList();
                this.AllMemesGrid.DataSource = this.Memes;
                this.AllMemesGrid.DataBind();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //PagedDataSource pagingObject = new PagedDataSource();
            //pagingObject.AllowPaging = true;
            //pagingObject.PageSize = 10;
            //if (this.Memes != null)
            //{
            //    pagingObject.DataSource = this.Memes;
            //    pagingObject.CurrentPageIndex = this.PageNumber;

            //    this.AllMemesGrid.DataSource = pagingObject;
            //    this.AllMemesGrid.DataBind();
            //}
            //else
            //{
            //    this.Memes = this.dbContext.Memes.ToList();
            //    pagingObject.DataSource = this.Memes;
            //    pagingObject.CurrentPageIndex = 0;
            //this.Memes = this.dbContext.Memes.ToList();
            //this.AllMemesGrid.DataSource = this.Memes;
            //this.AllMemesGrid.DataBind();
            // }

        }

        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            var meme = sender as ImageButton;
            var memeId = meme.CommandArgument;
            this.Response.Redirect("/MemeDetails?id=" + memeId);
        }

        protected void ButtonPrevious_Click(object sender, EventArgs e)
        {


        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {


        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(10));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }

            }

            this.Pager.DataSource = pages;
            this.Pager.DataBind();
        }


        private int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber"] = value; }
        }

        protected void ShowOnlyMine_CheckedChanged(object sender, EventArgs e)
        {
            var userID = this.User.Identity.GetUserId();
            var obj = sender as RadioButton;
            if (obj.Checked)
            {
                var result = this.dbContext.Memes.Where(x => x.UserId == userID);
                if (result != null)
                {
                    this.AllMemesGrid.DataSource = result;
                    this.DataBind();
                }
                //No results found message maybe
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var titleToSearch = this.SearchByUserName.Text;
            var result = this.dbContext.Memes.Where(x => x.Title.IndexOf(titleToSearch) > -1);
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
                this.AllMemesGrid.DataSource = this.dbContext.Memes.OrderBy(x => x.CreationDate);
            }
            else
            {
                this.AllMemesGrid.DataSource = this.dbContext.Memes.OrderByDescending(x => x.CreationDate);
            }

            this.AllMemesGrid.DataBind();
        }

        protected void OrderByLikes_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var cmdName = button.CommandName;
            var isLikes = cmdName == "Likes" ? true : false;

            if (isLikes)
            {
                this.AllMemesGrid.DataSource = this.dbContext.Memes.OrderBy(x => x.Likes);
            }
            else
            {
                this.AllMemesGrid.DataSource = this.dbContext.Memes.OrderByDescending(x => x.Likes);
            }

            this.AllMemesGrid.DataBind();
        }
    }
}