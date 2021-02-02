using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers
{
    public class PropertiesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Properties
        public ICollection<PropertyNoR> GetProperties()
        {


            List<PropertyNoR> Lys = new List<PropertyNoR>();
            foreach (Property objct in db.Properties.Include(p => p.Auction).Include(p => p.ConcludedAuction).Include(p => p.Seller))
            {


                PropertyNoR newObject = new PropertyNoR()
                {
                    BathRooms = objct.BathRooms,
                    //  AuctionRegistrations = objct.AuctionRegistrations,
                    Auction = new AuctionNoR(),
                    ApprovalStatus = objct.ApprovalStatus,
                    Description = objct.Description,
                    Jacquizzi = objct.Jacquizzi,
                    PropertyID = objct.PropertyID,
                    Address = objct.Address,
                    levies = objct.levies,
                    BedRooms = objct.BedRooms,
                    Borehole = objct.Borehole,
                    HOARules = objct.HOARules,
                    OutdoorKitchen = objct.OutdoorKitchen,
                    Braai = objct.Braai,
                    City = objct.City,
                    OpeningBid = objct.OpeningBid,
                    //  Seller=objct.Seller,
                    Clubhouse = objct.Clubhouse,
                    MandateExpireDate = objct.MandateExpireDate,
                    SellerID = objct.SellerID,
                    //  ConcludedAuction = objct.ConcludedAuction,
                    SellerSigniture = objct.SellerSigniture,
                    SwimmingPool = objct.SwimmingPool,
                    FloorSize = objct.FloorSize,
                    MandateSingedDate = objct.MandateSingedDate,
                    Country = objct.Country,
                    YardSize = objct.YardSize,
                    Fibre = objct.Fibre,
                    TitleDeedPath = objct.TitleDeedPath,
                    FireplacePit = objct.FireplacePit,
                    Garages = objct.Garages,
                    Garden = objct.Garden,
                    Gerages = objct.Gerages,
                    MandateType = objct.MandateType,
                    Parking = objct.Parking,
                    PlansPath = objct.PlansPath,
                    PropertyType = objct.PropertyType,
                    Province = objct.Province,
                    RegistrationType = objct.RegistrationType,
                    Reserve = objct.Reserve,
                    TaxesAndRate = objct.TaxesAndRate,
                    TaxesAndRates = objct.TaxesAndRates,
                    TennisCourts = objct.TennisCourts,
                    Terrace = objct.Terrace,
                    Title = objct.Title
                };

                if (objct.PropertyPhotos.Count != 0)
                    foreach (PropertyPhoto pp in objct.PropertyPhotos)
                    {
                        PropertyPhotoNoR ppnr = new PropertyPhotoNoR();
                        ppnr.Description = pp.Description;
                        ppnr.ImageID = pp.ImageID;
                        ppnr.PropertyPhotoPath = pp.PropertyPhotoPath;
                        ppnr.PropertyId = pp.ImageID;
                        ppnr.Title = pp.Title;
                        newObject.PropertyPhotos.Add(ppnr);
                    }
                if (objct.PromoVideos.Count != 0)
                    foreach (PromoVideo pp in objct.PromoVideos)
                    {
                        PromoVideoNoR ppnr = new PromoVideoNoR();
                        ppnr.PropertyID = pp.PropertyID;
                        ppnr.VideoPath = pp.VideoPath;
                        ppnr.VideoID = pp.VideoID;
                        newObject.PromoVideos.Add(ppnr);
                    }

                foreach (AuctionRegistration pp in objct.AuctionRegistrations)
                {
                    AuctionRegistrationNoR ppnr = new AuctionRegistrationNoR();
                    ppnr.PropertyID = pp.PropertyID;
                    try
                    {

                        ppnr.AdminFee = new AdminFeeNoR();
                        ppnr.AdminFee.Amount = pp.AdminFee.Amount;
                        ppnr.AdminFee.DateOfPayment = pp.AdminFee.DateOfPayment;
                        ppnr.AdminFee.PaymentID = pp.AdminFee.PaymentID;
                        ppnr.AdminFee.ProofOfPaymentPath = pp.AdminFee.ProofOfPaymentPath;

                     }
                    catch { }
                    try
                    {
                        ppnr.RegisteredBuyer = new RegisteredBuyerNoR();
                        ppnr.RegisteredBuyer.Deposit.Amount = pp.RegisteredBuyer.Deposit.Amount;
                        ppnr.RegisteredBuyer.Deposit.BuyerID = pp.RegisteredBuyer.Deposit.BuyerID;
                        ppnr.RegisteredBuyer.Deposit.DateOfPayment = pp.RegisteredBuyer.Deposit.DateOfPayment;
                        ppnr.RegisteredBuyer.Deposit.DepositReturned = pp.RegisteredBuyer.Deposit.DepositReturned;
                        ppnr.RegisteredBuyer.Deposit.ProofOfPaymentPath = pp.RegisteredBuyer.Deposit.ProofOfPaymentPath;
                        ppnr.RegisteredBuyer.Deposit.ProofOfReturnPayment = pp.RegisteredBuyer.Deposit.ProofOfReturnPayment;
                    }
                    catch { }
                    try
                    {
                        ppnr.BankApproval = new BankApprovalNoR();
                        ppnr.BankApproval.ApprovalPath = pp.BankApproval.ApprovalPath;
                        ppnr.BankApproval.BankApprovalApprovalstatus = pp.BankApproval.BankApprovalApprovalstatus;
                        ppnr.BankApproval.DateOfSubmision = pp.BankApproval.DateOfSubmision;
                    }
                    catch { }

                    try
                    {
                        ppnr.Guarintee = new GuarinteeNoR();
                        ppnr.Guarintee.AuctionRegistrationID = pp.Guarintee.AuctionRegistrationID;
                        ppnr.Guarintee.DateOfSubmition = pp.Guarintee.DateOfSubmition;
                        ppnr.Guarintee.GuarinteeApproval = pp.Guarintee.GuarinteeApproval;
                        ppnr.Guarintee.GuarinteePath = pp.Guarintee.GuarinteePath;
                    }
                    catch
                    {

                    }

                    ppnr.id = pp.id;
                    ppnr.Bonded = pp.Bonded;
                    ppnr.BuyerId = pp.BuyerId;
                    ppnr.RegesterDate = pp.RegesterDate;
                    ppnr.RegistrationFees = pp.RegistrationFees;
                    ppnr.RegistrationStatus = pp.RegistrationStatus;

                    newObject.AuctionRegistrations.Add(ppnr);
                }

                try
                {

                    newObject.Auction.StartTime = objct.Auction.StartTime;
                    newObject.Auction.EndTime = objct.Auction.EndTime;
                    newObject.Auction.PropertyID = objct.Auction.PropertyID;

                }
                catch (Exception E) 
                {

                }
                try
                {

                    newObject.Seller = new SellerNoR();
                    newObject.Seller.FirtstName = objct.Seller.FirtstName;
                    newObject.Seller.ApprovalStatus = objct.Seller.ApprovalStatus;
                    newObject.Seller.LastName = objct.Seller.LastName;
                    newObject.Seller.ProfilePhoto = objct.Seller.ProfilePhoto;
                    newObject.Seller.SellerNumber = objct.Seller.SellerNumber;
                    newObject.Seller.SellerEmail = objct.Seller.SellerEmail;
                    newObject.Seller.SellerType = objct.Seller.SellerType;
                    newObject.Seller.Signature = objct.Seller.Signature;
                    newObject.Seller.UserID = objct.Seller.UserID;
                }
                catch { }
                try
                {
                    if(objct.Seller.Retailer !=null)
                    {

                    newObject.Seller.Retailer = new RetailerNoR();
                    newObject.Seller.Retailer.Branch = objct.Seller.Retailer.Branch;
                    newObject.Seller.Retailer.CompanyContactNumber = objct.Seller.Retailer.CompanyContactNumber;
                    newObject.Seller.Retailer.CompanyEmail = objct.Seller.Retailer.CompanyEmail;
                    newObject.Seller.Retailer.CompaynLogoPath = objct.Seller.Retailer.CompaynLogoPath;
                    newObject.Seller.Retailer.RetailerName = objct.Seller.Retailer.RetailerName;
                    newObject.Seller.Retailer.UserID = objct.Seller.Retailer.UserID;
                    newObject.Seller.Retailer.CompanyDescription = objct.Seller.Retailer.CompanyDescription;
                    }
                }
                catch { }
                try
                {

                    if (objct.Seller.Auctioneer != null)
                    {

                        newObject.Seller.Auctioneer = new AuctioneerNoR();
                    newObject.Seller.Auctioneer.Branch = objct.Seller.Auctioneer.Branch;
                    newObject.Seller.Auctioneer.CompanyContactNumber = objct.Seller.Auctioneer.CompanyContactNumber;
                    newObject.Seller.Auctioneer.CompanyEmail = objct.Seller.Auctioneer.CompanyEmail;
                    newObject.Seller.Auctioneer.CompanyLogo = objct.Seller.Auctioneer.CompanyLogo;
                    newObject.Seller.Auctioneer.CompanyName = objct.Seller.Auctioneer.CompanyName;
                    newObject.Seller.Auctioneer.UserID = objct.Seller.Auctioneer.UserID;
                    newObject.Seller.Auctioneer.CompanyDescriprion = objct.Seller.Auctioneer.CompanyDescriprion;
                    }
                }
                catch { }
                try
                {

                    if (objct.Seller.PrivateSeller != null)
                    {

                        newObject.Seller.PrivateSeller = new PrivateSellerNoR();
                    newObject.Seller.PrivateSeller.UserID = objct.Seller.PrivateSeller.UserID;
                    newObject.Seller.PrivateSeller.Signiture = objct.Seller.Auctioneer.Signature;
                    newObject.Seller.PrivateSeller.IDNumber = objct.Seller.PrivateSeller.IDNumber;
                    newObject.Seller.PrivateSeller.ProofOfResedence = objct.Seller.PrivateSeller.ProofOfResedence;
                    }
                }
                catch { }
                try
                {

                    if (objct.ConcludedAuction != null)
                    {

                        newObject.ConcludedAuction = new ConcludedAuctionNoR();
                        newObject.ConcludedAuction.WinningBidder = objct.ConcludedAuction.WinningBidder;
                        newObject.ConcludedAuction.TimeOfConclution = objct.ConcludedAuction.TimeOfConclution;
                        newObject.ConcludedAuction.PropertyID = objct.ConcludedAuction.PropertyID;
                        newObject.ConcludedAuction.ExceededReserve = objct.ConcludedAuction.ExceededReserve;
                    }
                }
                catch { }

                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/Properties/5
        [ResponseType(typeof(Property))]
        public async Task<IHttpActionResult> GetProperty(int id)
        {
            Property objct = await db.Properties.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }



            PropertyNoR newObject = new PropertyNoR()
            {
                BathRooms = objct.BathRooms,
                //  AuctionRegistrations = objct.AuctionRegistrations,
                Auction = new AuctionNoR(),
                ApprovalStatus = objct.ApprovalStatus,
                Description = objct.Description,
                Jacquizzi = objct.Jacquizzi,
                PropertyID = objct.PropertyID,
                Address = objct.Address,
                levies = objct.levies,
                BedRooms = objct.BedRooms,
                Borehole = objct.Borehole,
                HOARules = objct.HOARules,
                OutdoorKitchen = objct.OutdoorKitchen,
                Braai = objct.Braai,
                City = objct.City,
                OpeningBid = objct.OpeningBid,
                //  Seller=objct.Seller,
                Clubhouse = objct.Clubhouse,
                MandateExpireDate = objct.MandateExpireDate,
                SellerID = objct.SellerID,
                //  ConcludedAuction = objct.ConcludedAuction,
                SellerSigniture = objct.SellerSigniture,
                SwimmingPool = objct.SwimmingPool,
                FloorSize = objct.FloorSize,
                MandateSingedDate = objct.MandateSingedDate,
                Country = objct.Country,
                YardSize = objct.YardSize,
                Fibre = objct.Fibre,
                TitleDeedPath = objct.TitleDeedPath,
                FireplacePit = objct.FireplacePit,
                Garages = objct.Garages,
                Garden = objct.Garden,
                Gerages = objct.Gerages,
                MandateType = objct.MandateType,
                Parking = objct.Parking,
                PlansPath = objct.PlansPath,
                PropertyType = objct.PropertyType,
                Province = objct.Province,
                RegistrationType = objct.RegistrationType,
                Reserve = objct.Reserve,
                TaxesAndRate = objct.TaxesAndRate,
                TaxesAndRates = objct.TaxesAndRates,
                TennisCourts = objct.TennisCourts,
                Terrace = objct.Terrace,
                Title = objct.Title
            };
            foreach (PropertyPhoto pp in objct.PropertyPhotos)
            {
                PropertyPhotoNoR ppnr = new PropertyPhotoNoR();
                ppnr.Description = pp.Description;
                ppnr.ImageID = pp.ImageID;
                ppnr.PropertyPhotoPath = pp.PropertyPhotoPath;
                ppnr.PropertyId = pp.ImageID;
                ppnr.Title = pp.Title;
                newObject.PropertyPhotos.Add(ppnr);
            }
            foreach (PromoVideo pp in objct.PromoVideos)
            {
                PromoVideoNoR ppnr = new PromoVideoNoR();
                ppnr.PropertyID = pp.PropertyID;
                ppnr.VideoPath = pp.VideoPath;
                ppnr.VideoID = pp.VideoID;
                newObject.PromoVideos.Add(ppnr);
            }
            foreach (AuctionRegistration pp in objct.AuctionRegistrations)
            {
                AuctionRegistrationNoR ppnr = new AuctionRegistrationNoR();
                ppnr.PropertyID = pp.PropertyID;
                try
                {

                    ppnr.AdminFee = new AdminFeeNoR();
                    ppnr.AdminFee.Amount = pp.AdminFee.Amount;
                    ppnr.AdminFee.DateOfPayment = pp.AdminFee.DateOfPayment;
                    ppnr.AdminFee.PaymentID = pp.AdminFee.PaymentID;
                    ppnr.AdminFee.ProofOfPaymentPath = pp.AdminFee.ProofOfPaymentPath;
                }
                catch { }

                try
                {
                    ppnr.RegisteredBuyer = new RegisteredBuyerNoR();
                    ppnr.RegisteredBuyer.Deposit.Amount = pp.RegisteredBuyer.Deposit.Amount;
                    ppnr.RegisteredBuyer.Deposit.BuyerID = pp.RegisteredBuyer.Deposit.BuyerID;
                    ppnr.RegisteredBuyer.Deposit.DateOfPayment = pp.RegisteredBuyer.Deposit.DateOfPayment;
                    ppnr.RegisteredBuyer.Deposit.DepositReturned = pp.RegisteredBuyer.Deposit.DepositReturned;
                    ppnr.RegisteredBuyer.Deposit.ProofOfPaymentPath = pp.RegisteredBuyer.Deposit.ProofOfPaymentPath;
                    ppnr.RegisteredBuyer.Deposit.ProofOfReturnPayment = pp.RegisteredBuyer.Deposit.ProofOfReturnPayment;
                }
                catch { }

                try
                {
                    ppnr.BankApproval = new BankApprovalNoR();
                    ppnr.BankApproval.ApprovalPath = pp.BankApproval.ApprovalPath;
                    ppnr.BankApproval.BankApprovalApprovalstatus = pp.BankApproval.BankApprovalApprovalstatus;
                    ppnr.BankApproval.DateOfSubmision = pp.BankApproval.DateOfSubmision;
                }
                catch { }

                try {       
                    ppnr.Guarintee = new GuarinteeNoR();
                ppnr.Guarintee.AuctionRegistrationID = pp.Guarintee.AuctionRegistrationID;
                ppnr.Guarintee.DateOfSubmition = pp.Guarintee.DateOfSubmition;
                ppnr.Guarintee.GuarinteeApproval = pp.Guarintee.GuarinteeApproval;
                ppnr.Guarintee.GuarinteePath = pp.Guarintee.GuarinteePath;
                }
                catch
                {

                }
       
                ppnr.id = pp.id;
                ppnr.Bonded = pp.Bonded;
                ppnr.BuyerId = pp.BuyerId;
                ppnr.RegesterDate = pp.RegesterDate;
                ppnr.RegistrationFees = pp.RegistrationFees;
                ppnr.RegistrationStatus = pp.RegistrationStatus;

                newObject.AuctionRegistrations.Add(ppnr);
            }
            try
            {
                newObject.Auction.PropertyID = objct.Auction.PropertyID;
                newObject.Auction.StartTime = objct.Auction.StartTime;
                newObject.Auction.EndTime = objct.Auction.EndTime;
            }
            catch
            {

            }

            try
            {

                newObject.Seller = new SellerNoR();
                newObject.Seller.FirtstName = objct.Seller.FirtstName;
                newObject.Seller.ApprovalStatus = objct.Seller.ApprovalStatus;
                newObject.Seller.LastName = objct.Seller.LastName;
                newObject.Seller.ProfilePhoto = objct.Seller.ProfilePhoto;
                newObject.Seller.SellerNumber = objct.Seller.SellerNumber;
                newObject.Seller.SellerEmail = objct.Seller.SellerEmail;
                newObject.Seller.SellerType = objct.Seller.SellerType;
                newObject.Seller.Signature = objct.Seller.Signature;
                newObject.Seller.UserID = objct.Seller.UserID;
            }
            catch { }
            try
            {
                if (objct.Seller.Retailer != null)
                {

                    newObject.Seller.Retailer = new RetailerNoR();
                    newObject.Seller.Retailer.Branch = objct.Seller.Retailer.Branch;
                    newObject.Seller.Retailer.CompanyContactNumber = objct.Seller.Retailer.CompanyContactNumber;
                    newObject.Seller.Retailer.CompanyEmail = objct.Seller.Retailer.CompanyEmail;
                    newObject.Seller.Retailer.CompaynLogoPath = objct.Seller.Retailer.CompaynLogoPath;
                    newObject.Seller.Retailer.RetailerName = objct.Seller.Retailer.RetailerName;
                    newObject.Seller.Retailer.UserID = objct.Seller.Retailer.UserID;
                    newObject.Seller.Retailer.CompanyDescription = objct.Seller.Retailer.CompanyDescription;
                }
            }
            catch { }
            try
            {

                if (objct.Seller.Auctioneer != null)
                {

                    newObject.Seller.Auctioneer = new AuctioneerNoR();
                    newObject.Seller.Auctioneer.Branch = objct.Seller.Auctioneer.Branch;
                    newObject.Seller.Auctioneer.CompanyContactNumber = objct.Seller.Auctioneer.CompanyContactNumber;
                    newObject.Seller.Auctioneer.CompanyEmail = objct.Seller.Auctioneer.CompanyEmail;
                    newObject.Seller.Auctioneer.CompanyLogo = objct.Seller.Auctioneer.CompanyLogo;
                    newObject.Seller.Auctioneer.CompanyName = objct.Seller.Auctioneer.CompanyName;
                    newObject.Seller.Auctioneer.UserID = objct.Seller.Auctioneer.UserID;
                    newObject.Seller.Auctioneer.CompanyDescriprion = objct.Seller.Auctioneer.CompanyDescriprion;
                }
            }
            catch { }
            try
            {

                if (objct.Seller.PrivateSeller != null)
                {

                    newObject.Seller.PrivateSeller = new PrivateSellerNoR();
                    newObject.Seller.PrivateSeller.UserID = objct.Seller.PrivateSeller.UserID;
                    newObject.Seller.PrivateSeller.Signiture = objct.Seller.Auctioneer.Signature;
                    newObject.Seller.PrivateSeller.IDNumber = objct.Seller.PrivateSeller.IDNumber;
                    newObject.Seller.PrivateSeller.ProofOfResedence = objct.Seller.PrivateSeller.ProofOfResedence;
                }
            }
            catch { }
            try
            {

                if (objct.ConcludedAuction != null)
                {

                    newObject.ConcludedAuction = new ConcludedAuctionNoR();
                    newObject.ConcludedAuction.WinningBidder = objct.ConcludedAuction.WinningBidder;
                    newObject.ConcludedAuction.TimeOfConclution = objct.ConcludedAuction.TimeOfConclution;
                    newObject.ConcludedAuction.PropertyID = objct.ConcludedAuction.PropertyID;
                    newObject.ConcludedAuction.ExceededReserve = objct.ConcludedAuction.ExceededReserve;
                }
            }
            catch { }

            return Ok(newObject);
        }

        // PUT: api/Properties/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProperty(int id, Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.PropertyID)
            {
                return BadRequest();
            }

            db.Entry(property).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Properties
        [ResponseType(typeof(Property))]
        public async Task<IHttpActionResult> PostProperty(Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Properties.Add(property);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = property.PropertyID }, property);
        }

        // DELETE: api/Properties/5
        [ResponseType(typeof(Property))]
        public async Task<IHttpActionResult> DeleteProperty(int id)
        {
            Property property = await db.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            await db.SaveChangesAsync();

            return Ok(property);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.PropertyID == id) > 0;
        }
    }
}