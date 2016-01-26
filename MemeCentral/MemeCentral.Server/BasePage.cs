namespace MemeCentral.Server
{
    using Data;
    using System.Web.UI;

    public class BasePage : Page
    {
        public MemeDbContext dbContext;

        public BasePage()
        {
            this.dbContext = new MemeDbContext();
        }
    }
}