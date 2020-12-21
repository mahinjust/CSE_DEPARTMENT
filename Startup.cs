using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSE_DEPARTMENT.Startup))]
namespace CSE_DEPARTMENT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
