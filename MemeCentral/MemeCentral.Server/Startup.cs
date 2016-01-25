using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemeCentral.Server.Startup))]
namespace MemeCentral.Server
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
