using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACETreasureHunt.Startup))]
namespace ACETreasureHunt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
