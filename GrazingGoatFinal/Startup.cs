using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrazingGoatFinal.Startup))]
namespace GrazingGoatFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
