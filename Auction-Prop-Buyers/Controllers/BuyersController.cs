using APILibrary;
using Auction_Prop_Buyers.Models;
using Auction_Prop_Buyers.Models.DisplayMadels;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Auction_Prop_Buyers.Controllers
{
    public class BuyersController : Controller
    {
        // GET: Buyers
        public ActionResult Index(RegisteredBuyer model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                
                try
                {
                    RegisteredBuyer buyer = APIMethods.APIGet<RegisteredBuyer>(User.Identity.GetUserId(), "RegisteredBuyers");

                    return View(buyer);
                }
                catch (Exception E)
                {
                    if(User.Identity.IsAuthenticated)
                    {
                    
                        return RedirectToAction("Create", "Buyers", new { id = 0});

                    }
                    else
                    {

                        return RedirectToAction("Login", "Account" );
                    }
                }

            }

        }
        // GET: Buyers
        public ActionResult _Index()
        {
       
                return PartialView();
            
        }

        // GET: Buyers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Buyers/Create

        public ActionResult Create(int? id, BuyerViewModel model)
        {
            model.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    RegisteredBuyer newData = new RegisteredBuyer
                    {
                        UserId = User.Identity.GetUserId(),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        IDNumber = model.IDNumber,
                        DateOfBirth = model.DateOfBirth,
                        Signiture = model.Signiture,
                        RegistrationDate = DateTime.Now,
                        
                    };

                    newData.ProfilePhotoPath = FileController.PostFile(model.ProfilePhotoPath, "ProfilePhotos", "ProfilePhotos");
                    newData.ProofOfResidencePath = FileController.PostFile(model.ProofOfResidencePath, "ProofOfResedence", "ProofOfResedence");
                    newData.CopyOfIDPath = FileController.PostFile(model.CopyOfIDPath, "CopyOfIDPath", "CopyOfIDPath");
                    newData.IDBuyerVerifyPhoto = FileController.PostFile(model.IDBuyerVerifyPhoto, "IdBuyerVerifyPhoto", "IdBuyerVerifyPhoto");
                    newData.ProofOfBankAccount = FileController.PostFile(model.ProofOfBankAccount, "ProofOfBankAccount", "ProofOfBankAccount");



                    //Call Post Method
                    RegisteredBuyer ob = APIMethods.APIPost<RegisteredBuyer>(newData, "RegisteredBuyers");
                    return RedirectToAction("CreateAddress","Buyers", new { id = id });
                }
                catch (Exception E)
                {
                    throw new Exception("Something went wrong. Please try again"+E.ToString());
                }

            }
            else
            {
                return View();
            }
        }

        // GET: Buyers/Create

        public ActionResult CreateAddress(int? id ,Address model)
        {
            if (ModelState.IsValid)
            {

                try
                {  //Call Post Method
                    Address objec = APIMethods.APIPost<Address>(model, "Addresses");

                    BuyerAddress bAdd = new BuyerAddress();
                    bAdd.AddressID = objec.AddressID;
                    bAdd.UserID = User.Identity.GetUserId();
                    APIMethods.APIPost<BuyerAddress>(bAdd, "BuyerAddresses");

                    if(id !=0)
                    {
                        return RedirectToAction("Detailss", "home", new { id = id });
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    throw new Exception("Something went wrong. Please try again");
                }

            }
            else
            {
                return View();
            }

        }
        // GET: Buyers/Create

        public ActionResult RegisterForAuction(int id, AuctionRegistration model)
        {
            if(!User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Login", "Account");
            }
         
            if (model.Signiture)
            {

             
                try
                {  //Call Post Method
                    model.PropertyID = id;
                    model.BuyerId = User.Identity.GetUserId();
                    model.RegesterDate = DateTime.Now;
                    

                    AuctionRegistration objec = APIMethods.APIPost<AuctionRegistration>(model, "AuctionRegistrations");

                    if(model.Bonded)
                    {

                        return RedirectToAction("AdPreApproval","Buyers",new { id = objec.id });
                    }
                    else
                    {

                        return RedirectToAction("AddBankGuarintee", "Buyers", new { id = objec.id });
                    }

                }
                catch (Exception e)
                {
                    throw new Exception("Registreation faled."+ e.ToString());
                }

            }
            else
            {
                return View();
            }

        }

        public ActionResult AddBankGuarintee(int id, GuarinteeViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                

                try
                {
                     Guarintee newModel = new Guarintee
                     {
                        AuctionRegistrationID = id,
                        DateOfSubmition = DateTime.Now
                        

                      };
                     newModel.GuarinteePath = FileController.PostFile(model.GuarinteePath, "Guarintees", "guarintees");

                     //Call Post Method
                      APIMethods.APIPost<Guarintee>(newModel, "Guarintees");

                    int propID =  APIMethods.APIGet<AuctionRegistration>(id.ToString(), "AuctionRegistrations").PropertyID;

                    return RedirectToAction("Detailss", "home", new {id= propID });
                }
                catch (Exception E)
                {
                    throw new Exception("Something went wrong. Please try again"+E.Message);
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult AdPreApproval(int id, BankApprovalView model)
        {
            
            if (ModelState.IsValid)
            {
                
                try
                {
                     BankApproval newModel = new BankApproval
                     {
                        AuctionRegistrationID = id,
                        DateOfSubmision = DateTime.Now
                      };
                     newModel.ApprovalPath = FileController.PostFile(model.ApprovalPath, "bankapprovals", "bankapprovals");

                     //Call Post Method
                      APIMethods.APIPost<BankApproval>(newModel, "BankApprovals");

                    int propID = APIMethods.APIGet<AuctionRegistration>(id.ToString(), "AuctionRegistrations").PropertyID;


                    return RedirectToAction("Detailss", "home", new {  id = propID });


             
                }
                catch (Exception E)
                {
                    throw new Exception("Something went wrong. Please try again"+E.Message);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult ErrorView(ErrorViewModel error)
        {
            return View();
        }
       
      

    }
}
