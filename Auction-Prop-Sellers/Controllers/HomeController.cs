using APILibrary;
using Auction_Prop_Sellers.Models.DataViewModels;
using Auction_Prop_Sellers.Models.ErrorModels;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Seller model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            try
            {
                string userId = User.Identity.GetUserId();
                Seller seller = APIMethods.APIGet<Seller>(userId, "Seller");

                return View(seller);


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View();
            }



        }

        public ActionResult ErrorView(ErrorView error)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}