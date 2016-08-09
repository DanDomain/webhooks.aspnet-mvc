using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webhooks.Startup))]
namespace Webhooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
