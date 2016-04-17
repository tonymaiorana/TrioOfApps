using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleDealership.UI.Startup))]
namespace SampleDealership.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
