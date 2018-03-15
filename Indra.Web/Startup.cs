using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Indra.Web.Startup))]
namespace Indra.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
