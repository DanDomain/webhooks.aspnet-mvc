using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Webhooks.Startup))]
namespace Webhooks
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
