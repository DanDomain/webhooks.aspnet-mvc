using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Webhooks.Startup))]
namespace Webhooks
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
