using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Youffer.Web.Startup))]
namespace Youffer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
