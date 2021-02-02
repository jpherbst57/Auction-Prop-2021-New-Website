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
    public class SellersController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Sellers
        public ICollection<SellerNoR> GetSellers()
        {

            List<SellerNoR> Lys = new List<SellerNoR>();
            foreach (Seller objct in db.Sellers.Include(s => s.Auctioneer).Include(s => s.PrivateSeller).Include(s => s.Retailer))
            {


                SellerNoR newObject = new SellerNoR()
                {
                     UserID= objct.UserID,
                     Signature = objct.Signature,
                    ApprovalStatus = objct.ApprovalStatus,
                 //   Auctioneer = objct.Auctioneer,
                     FirtstName = objct.FirtstName,
                     LastName = objct.LastName,
                  //   PrivateSeller= objct.PrivateSeller,
                     SellerNumber = objct.SellerNumber,
                     ProfilePhoto = objct.ProfilePhoto,
                  //   Properties = objct.Properties,
                  //   Retailer = objct.Retailer,
                   //  SellerAddresses = objct.SellerAddresses,
                     SellerEmail = objct.SellerEmail,
                     SellerType = objct.SellerType


                };
                try
                {

                    newObject.Retailer = new RetailerNoR();
                    newObject.Retailer.Branch = objct.Retailer.Branch;
                    newObject.Retailer.CompanyContactNumber = objct.Retailer.CompanyContactNumber;
                    newObject.Retailer.CompanyEmail = objct.Retailer.CompanyEmail;
                    newObject.Retailer.CompaynLogoPath = objct.Retailer.CompaynLogoPath;
                    newObject.Retailer.RetailerName = objct.Retailer.RetailerName;
                    newObject.Retailer.UserID = objct.Retailer.UserID;
                    newObject.Retailer.CompanyDescription = objct.Retailer.CompanyDescription;
                }
                catch { }
                try
                {

                    newObject.Auctioneer = new AuctioneerNoR();
                    newObject.Auctioneer.Branch = objct.Auctioneer.Branch;
                    newObject.Auctioneer.CompanyContactNumber = objct.Auctioneer.CompanyContactNumber;
                    newObject.Auctioneer.CompanyEmail = objct.Auctioneer.CompanyEmail;
                    newObject.Auctioneer.CompanyLogo = objct.Auctioneer.CompanyLogo;
                    newObject.Auctioneer.CompanyName = objct.Auctioneer.CompanyName;
                    newObject.Auctioneer.UserID = objct.Auctioneer.UserID;
                    newObject.Auctioneer.CompanyDescriprion = objct.Auctioneer.CompanyDescriprion;
                }
                catch { }
                try
                {

                    newObject.PrivateSeller = new PrivateSellerNoR();
                    newObject.PrivateSeller.UserID = objct.PrivateSeller.UserID;
                    newObject.PrivateSeller.Signiture = objct.Auctioneer.Signature;
                    newObject.PrivateSeller.IDNumber = objct.PrivateSeller.IDNumber;
                    newObject.PrivateSeller.ProofOfResedence = objct.PrivateSeller.ProofOfResedence;
                }
                catch { }

                List<PropertyNoR> lys = new List<PropertyNoR>();

                foreach(Property pop in objct.Properties)
                {
                    try
                    {
                        PropertyNoR newprop = new PropertyNoR()
                        {
                            BathRooms = pop.BathRooms,
                            //  AuctionRegistrations = objct.AuctionRegistrations,
                            Auction = new AuctionNoR(),
                            ApprovalStatus = pop.ApprovalStatus,
                            Description = pop.Description,
                            Jacquizzi = pop.Jacquizzi,
                            PropertyID = pop.PropertyID,
                            Address = pop.Address,
                            levies = pop.levies,
                            BedRooms = pop.BedRooms,
                            Borehole = pop.Borehole,
                            HOARules = pop.HOARules,
                            OutdoorKitchen = pop.OutdoorKitchen,
                            Braai = pop.Braai,
                            City = pop.City,
                            OpeningBid = pop.OpeningBid,
                            //  Seller=objct.Seller,
                            Clubhouse = pop.Clubhouse,
                            MandateExpireDate = pop.MandateExpireDate,
                            SellerID = pop.SellerID,
                            //  ConcludedAuction = objct.ConcludedAuction,
                            SellerSigniture = pop.SellerSigniture,
                            SwimmingPool = pop.SwimmingPool,
                            FloorSize = pop.FloorSize,
                            MandateSingedDate = pop.MandateSingedDate,
                            Country = pop.Country,
                            YardSize = pop.YardSize,
                            Fibre = pop.Fibre,
                            TitleDeedPath = pop.TitleDeedPath,
                            FireplacePit = pop.FireplacePit,
                            Garages = pop.Garages,
                            Garden = pop.Garden,
                            Gerages = pop.Gerages,
                            MandateType = pop.MandateType,
                            Parking = pop.Parking,
                            PlansPath = pop.PlansPath,
                            PropertyType = pop.PropertyType,
                            Province = pop.Province,
                            RegistrationType = pop.RegistrationType,
                            Reserve = pop.Reserve,
                            TaxesAndRate = pop.TaxesAndRate,
                            TaxesAndRates = pop.TaxesAndRates,
                            TennisCourts = pop.TennisCourts,
                            Terrace = pop.Terrace,
                            Title = pop.Title
                        };

                        if (pop.PropertyPhotos.Count != 0)
                            foreach (PropertyPhoto pp in pop.PropertyPhotos)
                            {
                                PropertyPhotoNoR ppnr = new PropertyPhotoNoR();
                                ppnr.Description = pp.Description;
                                ppnr.ImageID = pp.ImageID;
                                ppnr.PropertyPhotoPath = pp.PropertyPhotoPath;
                                ppnr.PropertyId = pp.ImageID;
                                ppnr.Title = pp.Title;
                                newprop.PropertyPhotos.Add(ppnr);
                            }
                        if (pop.PromoVideos.Count != 0)
                            foreach (PromoVideo pp in pop.PromoVideos)
                            {
                                PromoVideoNoR ppnr = new PromoVideoNoR();
                                ppnr.PropertyID = pp.PropertyID;
                                ppnr.VideoPath = pp.VideoPath;
                                ppnr.VideoID = pp.VideoID;
                                newprop.PromoVideos.Add(ppnr);
                            }
                        lys.Add(newprop);
                     
                }    catch
                    {

                    }

                    newObject.Properties = lys;

                }
               



                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public async Task<IHttpActionResult> GetSeller(string id)
        {
            Seller objct = await db.Sellers.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            
                SellerNoR newObject = new SellerNoR()
                {
                     UserID= objct.UserID,
                     Signature = objct.Signature,
                    ApprovalStatus = objct.ApprovalStatus,
                 //   Auctioneer = objct.Auctioneer,
                     FirtstName = objct.FirtstName,
                     LastName = objct.LastName,
                  //   PrivateSeller= objct.PrivateSeller,
                     SellerNumber = objct.SellerNumber,
                     ProfilePhoto = objct.ProfilePhoto,
                  //   Properties = objct.Properties,
                  //   Retailer = objct.Retailer,
                   //  SellerAddresses = objct.SellerAddresses,
                     SellerEmail = objct.SellerEmail,
                     SellerType = objct.SellerType


                };
            try
            {

                newObject.Retailer = new RetailerNoR();
                newObject.Retailer.Branch = objct.Retailer.Branch;
                newObject.Retailer.CompanyContactNumber = objct.Retailer.CompanyContactNumber;
                newObject.Retailer.CompanyEmail = objct.Retailer.CompanyEmail;
                newObject.Retailer.CompaynLogoPath = objct.Retailer.CompaynLogoPath;
                newObject.Retailer.RetailerName = objct.Retailer.RetailerName;
                newObject.Retailer.UserID = objct.Retailer.UserID;
                newObject.Retailer.CompanyDescription = objct.Retailer.CompanyDescription;
            }
            catch { }
            try
            {

                newObject.Auctioneer = new AuctioneerNoR();
                newObject.Auctioneer.Branch = objct.Auctioneer.Branch;
                newObject.Auctioneer.CompanyContactNumber = objct.Auctioneer.CompanyContactNumber;
                newObject.Auctioneer.CompanyEmail = objct.Auctioneer.CompanyEmail;
                newObject.Auctioneer.CompanyLogo = objct.Auctioneer.CompanyLogo;
                newObject.Auctioneer.CompanyName = objct.Auctioneer.CompanyName;
                newObject.Auctioneer.UserID = objct.Auctioneer.UserID;
                newObject.Auctioneer.CompanyDescriprion = objct.Auctioneer.CompanyDescriprion;
            }
            catch { }
            try
            {

                newObject.PrivateSeller = new PrivateSellerNoR();
                newObject.PrivateSeller.UserID = objct.PrivateSeller.UserID;
                newObject.PrivateSeller.Signiture = objct.Auctioneer.Signature;
                newObject.PrivateSeller.IDNumber = objct.PrivateSeller.IDNumber;
                newObject.PrivateSeller.ProofOfResedence = objct.PrivateSeller.ProofOfResedence;
            }
            catch { }


            List<PropertyNoR> lys = new List<PropertyNoR>();

            foreach (Property pop in objct.Properties)
            {
                try
                {
                    PropertyNoR newprop = new PropertyNoR()
                    {
                        BathRooms = pop.BathRooms,
                        //  AuctionRegistrations = objct.AuctionRegistrations,
                        Auction = new AuctionNoR(),
                        ApprovalStatus = pop.ApprovalStatus,
                        Description = pop.Description,
                        Jacquizzi = pop.Jacquizzi,
                        PropertyID = pop.PropertyID,
                        Address = pop.Address,
                        levies = pop.levies,
                        BedRooms = pop.BedRooms,
                        Borehole = pop.Borehole,
                        HOARules = pop.HOARules,
                        OutdoorKitchen = pop.OutdoorKitchen,
                        Braai = pop.Braai,
                        City = pop.City,
                        OpeningBid = pop.OpeningBid,
                        //  Seller=objct.Seller,
                        Clubhouse = pop.Clubhouse,
                        MandateExpireDate = pop.MandateExpireDate,
                        SellerID = pop.SellerID,
                        //  ConcludedAuction = objct.ConcludedAuction,
                        SellerSigniture = pop.SellerSigniture,
                        SwimmingPool = pop.SwimmingPool,
                        FloorSize = pop.FloorSize,
                        MandateSingedDate = pop.MandateSingedDate,
                        Country = pop.Country,
                        YardSize = pop.YardSize,
                        Fibre = pop.Fibre,
                        TitleDeedPath = pop.TitleDeedPath,
                        FireplacePit = pop.FireplacePit,
                        Garages = pop.Garages,
                        Garden = pop.Garden,
                        Gerages = pop.Gerages,
                        MandateType = pop.MandateType,
                        Parking = pop.Parking,
                        PlansPath = pop.PlansPath,
                        PropertyType = pop.PropertyType,
                        Province = pop.Province,
                        RegistrationType = pop.RegistrationType,
                        Reserve = pop.Reserve,
                        TaxesAndRate = pop.TaxesAndRate,
                        TaxesAndRates = pop.TaxesAndRates,
                        TennisCourts = pop.TennisCourts,
                        Terrace = pop.Terrace,
                        Title = pop.Title
                    };

                    if (pop.PropertyPhotos.Count != 0)
                        foreach (PropertyPhoto pp in pop.PropertyPhotos)
                        {
                            PropertyPhotoNoR ppnr = new PropertyPhotoNoR();
                            ppnr.Description = pp.Description;
                            ppnr.ImageID = pp.ImageID;
                            ppnr.PropertyPhotoPath = pp.PropertyPhotoPath;
                            ppnr.PropertyId = pp.ImageID;
                            ppnr.Title = pp.Title;
                            newprop.PropertyPhotos.Add(ppnr);
                        }
                    if (pop.PromoVideos.Count != 0)
                        foreach (PromoVideo pp in pop.PromoVideos)
                        {
                            PromoVideoNoR ppnr = new PromoVideoNoR();
                            ppnr.PropertyID = pp.PropertyID;
                            ppnr.VideoPath = pp.VideoPath;
                            ppnr.VideoID = pp.VideoID;
                            newprop.PromoVideos.Add(ppnr);
                        }
                    lys.Add(newprop);

                }
                catch
                {

                }

                newObject.Properties = lys;

                try
                {
                    List<SellerAddressNoR> lysAdd = new List<SellerAddressNoR>();

                    foreach (SellerAddress bAdd in objct.SellerAddresses)
                    {

                        SellerAddressNoR newAdd = new SellerAddressNoR();
                        newAdd.AddressID = bAdd.Address.AddressID;
                        newAdd.id = bAdd.id;
                        newAdd.UserID = bAdd.UserID;

                        lysAdd.Add(newAdd);

                    }
                    newObject.SellerAddresses = lysAdd;

                }
                catch
                {

                }

            }

            return Ok(newObject);
        }

        // PUT: api/Sellers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSeller(string id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seller.UserID)
            {
                return BadRequest();
            }

            db.Entry(seller).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
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

        // POST: api/Sellers
        [ResponseType(typeof(Seller))]
        public async Task<IHttpActionResult> PostSeller(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sellers.Add(seller);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SellerExists(seller.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = seller.UserID }, seller);
        }

        // DELETE: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public async Task<IHttpActionResult> DeleteSeller(string id)
        {
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            db.Sellers.Remove(seller);
            await db.SaveChangesAsync();

            return Ok(seller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SellerExists(string id)
        {
            return db.Sellers.Count(e => e.UserID == id) > 0;
        }
    }
}