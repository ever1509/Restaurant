using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restaurant.SPA.Startup))]
namespace Restaurant.SPA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
