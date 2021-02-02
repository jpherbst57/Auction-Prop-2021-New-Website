using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Auction_Prop_API.Startup))]

namespace Auction_Prop_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
