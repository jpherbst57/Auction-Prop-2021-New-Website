using APILibrary;
using Auction_Prop_Sellers.Models.DataViewModels;
using Auction_Prop_Sellers.Models.ErrorModels;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class SellerRegistrationController : Controller
    {
        // GET: SellersAccount/RegistrationWiz

        public ActionResult Index(Seller model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {


                try
                {
                    Seller sellerModel = APIMethods.APIGet<Seller>(User.Identity.GetUserId(), "sellers");

                    return View(sellerModel);
                }
                catch
                {
                    return View();
                }

            }

        }


        // POST: SellersAccount/Create     

        public ActionResult CreateSeller(SellersView model)
        {
            model.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    Seller newData = new Seller
                    {
                        UserID = model.UserID,
                        FirstName = model.FirstName,
                        Signature = model.Signature,
                        SellerNumber = model.SellerNumber,
                        SellerEmail = model.SellerEmail,
                        LastName = model.LastName,
                        SellerType = model.SellerType
                    };

                    newData.ProfilePhoto = FileController.PostFile(model.ProfilePhoto, "ProfilePhoto", "ProfilePhoto");



                    //Call Post Method
                    Seller ob = APIMethods.APIPost<Seller>(newData, "Sellers");


                    if (ob.SellerType == "Retailer")
                    {

                        return RedirectToAction("CreateRetialer");
                    }
                    else if (ob.SellerType == "Auctioneer")
                    {

                        return RedirectToAction("CreateAuctioneer");
                    }
                    else
                    {

                        return RedirectToAction("CreatePrivate");
                    }
                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }
            }
            else
            {
                return View();
            }
        }





        public ActionResult CreateRetialer(RetailerView model)
        {
            model.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    Retailer newData = new Retailer
                    {
                        UserID = model.UserID,
                        RetailerName = model.RetailerName,
                        Signature = model.Signature,
                        CompanyContactNumber = model.CompanyContactNumber,
                        CompanyEmail = model.CompanyEmail,
                        CompanyDescription = model.CompanyDescription,
                        Branch = model.Branch
                    };

                    newData.CompaynLogoPath = FileController.PostFile(model.CompaynLogoPath, "CompaynLogoPath", "CompaynLogoPath");



                    //Call Post Method
                    Retailer ob = APIMethods.APIPost<Retailer>(newData, "Retailers");
                    return RedirectToAction("AddAddress");
                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }
            }
            else
            {
                return View();
            }
        }


        public ActionResult CreatePrivate(PrivateSellerData model)
        {
            model.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {

                try
                {

                    PrivateSeller newData = new PrivateSeller
                    {
                        UserID = model.UserID,
                        IDNumber = model.IDNumber,
                        Signiture = model.Signiture,
                    };

                    newData.ProofOfResedence = FileController.PostFile(model.ProofOfResedence, "ProofOfResedence", "ProofOfResedence");

                    //Call Post Method
                    PrivateSeller ob = APIMethods.APIPost<PrivateSeller>(newData, "PrivateSellers");

                    return RedirectToAction("AddAddress");
                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult CreateAuctioneer(AuctioneerView model)
        {
            model.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    Auctioneer newData = new Auctioneer
                    {
                        UserID = model.UserID,
                        CompanyName = model.CompanyName,
                        Branch = model.Branch,
                        CompanyContactNumber = model.CompanyContactNumber,
                        CompanyEmail = model.CompanyEmail,
                        Signature = model.Signature,
                        CompanyDescriprion = model.CompanyDescriprion,


                    };

                    newData.CompanyLogo = FileController.PostFile(model.CompanyLogo, "CompanyLogo", "CompanyLogo");

                    //Call Post Method
                    Auctioneer ob = APIMethods.APIPost<Auctioneer>(newData, "Auctioneers");

                    return RedirectToAction("AddAddress");
                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }
            }
            else
            {
                return View();
            }
        }






        public ActionResult AddAddress(Address model)
        {
            if (ModelState.IsValid)
            {

                try
                {  //Call Post Method
                    Address objec = APIMethods.APIPost<Address>(model, "Addresses");

                    SellerAddress sAdd = new SellerAddress
                    {
                        AddressID = objec.AddressID,
                        UserID = User.Identity.GetUserId()
                    };
                    APIMethods.APIPost<SellerAddress>(sAdd, "SellerAddresses");
                    return RedirectToAction("Index");

                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }

            }
            else
            {
                return View();
            }



        }
        public ActionResult ErrorView(ErrorViewModel model)
        {
            return View(model);
        }
    }
}