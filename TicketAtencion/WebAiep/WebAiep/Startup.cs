using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAiep.Startup))]
namespace WebAiep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
