using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Goody.Web.Startup))]
namespace Goody.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
