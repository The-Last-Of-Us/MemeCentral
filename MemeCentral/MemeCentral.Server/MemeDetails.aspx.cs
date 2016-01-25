namespace MemeCentral.Server
{
    using System;

    public partial class MemeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var memeId = Request.Params["id"];
        }

        public string A
        {
            get { return "Some author comment"; }
        }
    }
}