namespace MemeCentral.Server
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;

    using Data.Models;

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
    }
}