using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkShopTraining.Startup))]
namespace WorkShopTraining
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
