using APILibrary;
using Auction_Prop_Sellers.Models.DataViewModels;
using Auction_Prop_Sellers.Models.ErrorModels;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class SellerDashboardController : Controller
    {
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
                    Seller sellerModel = APIMethods.APIGet<Seller>(User.Identity.GetUserId(), "Sellers");

                    return View(sellerModel);


                }
                catch (Exception E)
                {
                    return View();
                }

            }



        }
        public ActionResult ErrorView(ErrorView error)
        {
            return View();
        }


        public async Task<ActionResult> CreateProperty(PropertyView model)
        {
            
            if (ModelState.IsValid && model.SellerSigniture)
            {
               
               
                try
                {
                    var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<PropertyView, Property>();
                     });

                    IMapper mapper = config.CreateMapper();
                    Property NewProp = mapper.Map<PropertyView, Property>(model);
                    NewProp.SellerID = User.Identity.GetUserId();
                    if(NewProp.TitleDeedPath == "")
                    {
                        NewProp.TitleDeedPath = "N/A";
                    }   
                    if(NewProp.BedRooms == null)
                    {
                        NewProp.BedRooms = 0;
                    }  
                    if(NewProp.FloorSize == null)
                    {
                        NewProp.FloorSize = 0;
                    }  
                    if(NewProp.YardSize == null)
                    {
                        NewProp.YardSize = 0;
                    }   
                    if(NewProp.Reserve == null)
                    {
                        NewProp.Reserve = 0;
                    }
                    if (NewProp.Garages == null)
                    {
                        NewProp.Garages = 0;
                    }  
                    if(NewProp.OpeningBid == null)
                    {
                        NewProp.OpeningBid = 0;
                    }   
                    if(NewProp.TaxesAndRate == null)
                    {
                        NewProp.TaxesAndRate = 0;
                    } 
                    if(NewProp.levies == null)
                    {
                        NewProp.levies = 0;
                    } 
              
                    NewProp.MandateSingedDate = DateTime.Now;
                    NewProp.MandateExpireDate = DateTime.Now.AddDays(90);
                    NewProp.TaxesAndRates = FileController.PostFile(model.TaxesAndRates, "TaxesAndRates", "TaxesAndRates");
                    NewProp.PlansPath = FileController.PostFile(model.PlansPath, "Plans", "Plans");
                  //  NewProp.TitleDeedPath = FileController.PostFile(model.TitleDeedPath, "Titledeeds", "Titledeeds");
                    NewProp.HOARules = FileController.PostFile(model.HOARules, "HOARules", "HOARules");

                    //Call Post Method
                    Property ob = APIMethods.APIPost<Property>(NewProp, "Properties");

                    SendGridService ser = new SendGridService();
                    /*EmailMessageInfo msg = new EmailMessageInfo() { 
                        FromEmailAddress = "cmmadeleyn@gmail.com",
                        ToEmailAddress = model.Seller.SellerEmail,
                        EmailSubject ="New Property listing.",
                        EmailBody = "Property: Title-"+model.Title+"/n Address- "+model.Address+"/n Youre listing will be reviewed and you will be notified Accordingly."
                    };
          //          await ser.Send(msg);

                    EmailMessageInfo msgAdmin = new EmailMessageInfo() { 
                        FromEmailAddress = "cmmadeleyn@gmail.com",
                        ToEmailAddress = model.Seller.SellerEmail,
                        EmailSubject ="New Property listing.",
                        EmailBody = "Property: Title-"+model.Title+"/n Address- "+model.Address+"./n Property listed by "+model.Seller.FirtstName+" "+model.Seller.LastName
                    };
                    await ser.Send(msgAdmin);*/

                    return RedirectToAction("AddPhoto",new { id = ob.PropertyID});
                }
                catch (Exception E)
                {
                    throw new Exception(E.Message);
                }
            }
            else
            {
                return View(model);
            }


        }

        public ActionResult AddPropertyStyled(Property model)
        {
            model.SellerID = User.Identity.GetUserId();

            bool m = ModelState.IsValid;
            string adddd = model.Address;
            if (ModelState.IsValid)
            {
                    Property ob = APIMethods.APIPost<Property>(model, "Properties");

                try
                {
                    //Call Post Method
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


        public ActionResult AddPhoto(int id, PropertyPhotoView file)
        {

          
            if (ModelState.IsValid)
            {
                try
                {
                    PropertyPhoto model = new PropertyPhoto();
                    if (file != null)
                    {
                        model.PropertyId = id;
                        model.Description = file.Description;
                        model.Title = file.Title;
                        model.PropertyPhotoPath = FileController.PostFile(file.PropertyPhotoPath, "propertyphotos", "propertyphotos");
                       
                        //Call Post Method
                       APIMethods.APIPost<PropertyPhoto>(model, "PropertyPhotoes");
                     return  View();
                    
                    }
                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }





                return RedirectToAction("Index");
                
            
            }
            else
            {
                return View();
            }


        }
        
        public ActionResult AddPromoVideo(int id, PromoVideoData file)
        {

          
            if (ModelState.IsValid)
            {
                try
                {
                   if (file != null)
                    {
                        //Call Post Method
                       APIMethods.APIPost<PropertyPhoto>(file, "PropertyPhotoes");
                     return RedirectToAction("Index");
                    
                    }
                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }





                return RedirectToAction("Index");
                
            
            }
            else
            {
                return View();
            }


        }

        // GET: SellersAccount/Edit/5

        public ActionResult Edit(int id, Property model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   APIMethods.APIPut<Property>(model, id.ToString(), "Properties");
                    return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }

            }
            else
            {
                return View(APIMethods.APIGet<Property>(id.ToString(), "Properties"));
            }

        }

        // GET: SellersAccount/Edit/5
        public ActionResult Delete(int id, Property model)
        {
            if (model.PropertyID != 0)
            {
                try
                {
                    APIMethods.APIDelete<Property>( model.PropertyID.ToString(), "Properties");
                    return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    throw new Exception(E.ToString());
                }

            }
            else
            {
                return View(APIMethods.APIGet<Property>(id.ToString(), "Properties"));
            }

        }


      

        public ActionResult Details(int id, Property model)
        {
            if (ModelState.IsValid)
            {

                return View();


            }
            else
            {
                return View(APIMethods.APIGet<Property>(id.ToString(), "Properties"));
            }
        }



        public ActionResult _PhotoPartial(PropertyPhoto propertyPhoto)
        {
           
            if ( ModelState.IsValid)
            {
               // NewPropView.PropertyPhotos.Add(propertyPhoto);
                
                return PartialView();
            }
            else
            {
                return PartialView();
            }


        }

    }

}
