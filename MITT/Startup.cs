using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MITT.Startup))]
namespace MITT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
