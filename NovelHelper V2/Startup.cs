using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NovelHelper_V2.Startup))]
namespace NovelHelper_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
