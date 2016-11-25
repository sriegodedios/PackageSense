using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(packageWebApplication.Startup))]
namespace packageWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
         //turn off database
        }
    }
}
