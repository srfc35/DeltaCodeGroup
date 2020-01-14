using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeltaCode.Startup))]
namespace DeltaCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
