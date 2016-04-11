using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PigeonsWebSite.Startup))]
namespace PigeonsWebSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
