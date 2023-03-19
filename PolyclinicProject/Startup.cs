using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolyclinicProject.Startup))]
namespace PolyclinicProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
