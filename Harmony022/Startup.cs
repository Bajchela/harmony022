using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Harmony022.Startup))]
namespace Harmony022
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
