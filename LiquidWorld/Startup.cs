using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiquidWorld.Startup))]
namespace LiquidWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
