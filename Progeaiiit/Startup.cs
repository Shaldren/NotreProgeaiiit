using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Progeaiiit.Startup))]
namespace Progeaiiit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
