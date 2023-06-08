using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pañol.Startup))]
namespace Pañol
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
