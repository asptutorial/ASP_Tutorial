using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentWebApplication.Startup))]
namespace StudentWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
