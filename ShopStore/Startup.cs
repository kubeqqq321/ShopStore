using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopStore.Startup))]
namespace ShopStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
