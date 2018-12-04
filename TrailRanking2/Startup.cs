using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrailRanking2.Startup))]
namespace TrailRanking2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
