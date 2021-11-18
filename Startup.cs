using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCD0806.Startup))]
namespace GCD0806
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
