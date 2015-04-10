using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagazineProject.Web.Startup))]
namespace MagazineProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
