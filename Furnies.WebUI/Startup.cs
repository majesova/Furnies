using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Furnies.WebUI.Startup))]
namespace Furnies.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
