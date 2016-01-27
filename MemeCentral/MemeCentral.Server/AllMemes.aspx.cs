﻿namespace MemeCentral.Server
{
    using MemeCentral.Data.Models;
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

        }

        protected void ButtonLike_Click(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            PagedDataSource pagingObject = new PagedDataSource();
            pagingObject.AllowPaging = true;
            pagingObject.PageSize = 10;
            if (this.Memes != null)
            {
                pagingObject.DataSource = this.Memes;
                pagingObject.CurrentPageIndex = this.PageNumber;

                this.AllMemesGrid.DataSource = pagingObject;
                this.AllMemesGrid.DataBind();
            }
            else
            {
                this.Memes = this.dbContext.Memes.ToList();
                pagingObject.DataSource = this.Memes;
                pagingObject.CurrentPageIndex = 0;
                this.AllMemesGrid.DataSource = pagingObject;
                this.AllMemesGrid.DataBind();
            }

        }

        protected void CommentControl_Comment(object sender, EventArgs e)
        {
            //var userID = this.User.Identity.GetUserId();
            //var meme = sender as ImageButton;

            //var meme = this.dbContext.Memes.Find(e.DataID);
            //var comment = new Comment() { MemeId = meme.Id, UserId = userID, Content = e.Content, CreationDate = DateTime.Now };
            //meme.Comments.Add(comment);
            //this.dbContext.SaveChanges();

            //// Visualise all the comments TODO
            //var control = sender as CommentControl;
            //control.Comments = meme.Comments.OrderByDescending(x => x.CreationDate).ToList();
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
    }
}