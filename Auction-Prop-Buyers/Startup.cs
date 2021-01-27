using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Auction_Prop_Buyers.Startup))]
namespace Auction_Prop_Buyers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
