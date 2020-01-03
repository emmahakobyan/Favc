using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Favc.Startup))]
namespace Favc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
