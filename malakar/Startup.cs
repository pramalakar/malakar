using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(malakar.Startup))]
namespace malakar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
