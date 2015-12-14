using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SubtitleProject.Startup))]
namespace SubtitleProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
