using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContractUs.Web.Startup))]
namespace ContractUs.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
