using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Auction_Prop_Sellers.Startup))]
namespace Auction_Prop_Sellers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
