using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SolarMag.com.Startup))]
namespace SolarMag.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
