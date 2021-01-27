using System.Web;
using System.Web.Mvc;

namespace Auction_Prop_Sellers
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
