using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenGoat.Startup))]
namespace GreenGoat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
