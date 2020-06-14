using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Healt_Care_System.Startup))]
namespace Healt_Care_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
