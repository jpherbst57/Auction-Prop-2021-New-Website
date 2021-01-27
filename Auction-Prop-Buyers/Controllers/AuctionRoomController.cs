using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APILibrary;
using Auction_Prop_Buyers.Models;
using Auction_Prop_Buyers.Models.DisplayMadels;
using Microsoft.AspNet.Identity;

namespace Auction_Prop_Buyers.Controllers
{
    public class AuctionRoomController : Controller
    {
        // GET: AuctionRoom
        public ActionResult Index(int id)
        {
            if(User.Identity.IsAuthenticated)
            {


                try
                {
                    List<AuctionRegistration> reglys = APIMethods.APIGetALL<List<AuctionRegistration>>( "AuctionRegistrations");
                   
                    Property model = APIMethods.APIGet<Property>(id.ToString(), "Properties");


                    foreach(AuctionRegistration reg in reglys)
                    {
                        if (model.PropertyID == reg.PropertyID && reg.BuyerId == User.Identity.GetUserId())
                        {

                            return View(model);
                        }
                    }
                    return RedirectToAction("RegisterForAuction","Buyers", new { id =  model.PropertyID});
                  
                }
                catch (Exception E)
                {
                        return RedirectToAction("Create", "Buyers", new { id = 0 });

                }
            }
            else
            {
                return RedirectToAction("login", "account");
            }





        }
        public ActionResult Auction()
        {
            return View();

        }
        public ActionResult ErrorView(ErrorViewModel error)
        {
            return View();
         
        }
    }
}