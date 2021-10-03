using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSGImpressionConn.Web.Startup))]
namespace SSGImpressionConn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
