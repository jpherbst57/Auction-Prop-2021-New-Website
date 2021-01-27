using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers.APIControllers
{
    public class BuyerAddressesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/BuyerAddresses
        public ICollection<BuyerAddressNoR> GetBuyerAddresses()
        {

         


            List<BuyerAddressNoR> Lys = new List<BuyerAddressNoR>();
            foreach (BuyerAddress objct in db.BuyerAddresses.Include(b => b.Address).Include(b => b.RegisteredBuyer))
            {


                BuyerAddressNoR newObject = new BuyerAddressNoR()
                {
                    // Bids= objct.Bids,
                    //  BankApproval = objct.BankApproval,
                    AddressID = objct.AddressID,
                    id= objct.id,
                    //  Guarintee = objct.Guarintee,
                    //  Auction = objct.Auction,
                    //  Property = objct.Property,
                   // RegisteredBuyer = objct.RegisteredBuyer,
                    UserID = objct.UserID,
                    //  ConcludedAuctions = objct.ConcludedAuctions,
                 //   PropertyID = objct.PropertyID,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                   // TimeOfbid = objct.TimeOfbid
                    //Seller = objct.Seller
                    // AuctionRegistration = fee.AuctionRegistration
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/BuyerAddresses/5
        [ResponseType(typeof(BuyerAddress))]
        public async Task<IHttpActionResult> GetBuyerAddress(int id)
        {
            BuyerAddress objct = await db.BuyerAddresses.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            BuyerAddressNoR newObject = new BuyerAddressNoR()
            {
                // Bids= objct.Bids,
                //  BankApproval = objct.BankApproval,
                AddressID = objct.AddressID,
                id = objct.id,
                //  Guarintee = objct.Guarintee,
                //  Auction = objct.Auction,
                //  Property = objct.Property,
                // RegisteredBuyer = objct.RegisteredBuyer,
                UserID = objct.UserID,
                //  ConcludedAuctions = objct.ConcludedAuctions,
                //   PropertyID = objct.PropertyID,
                // RegisteredBuyer = objct.RegisteredBuyer,
                // TimeOfbid = objct.TimeOfbid
                //Seller = objct.Seller
                // AuctionRegistration = fee.AuctionRegistration
            };

            return Ok(newObject);
        }

        // PUT: api/BuyerAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBuyerAddress(int id, BuyerAddress buyerAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != buyerAddress.id)
            {
                return BadRequest();
            }

            db.Entry(buyerAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerAddressExists(id))
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

        // POST: api/BuyerAddresses
        [ResponseType(typeof(BuyerAddress))]
        public async Task<IHttpActionResult> PostBuyerAddress(BuyerAddress buyerAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BuyerAddresses.Add(buyerAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = buyerAddress.id }, buyerAddress);
        }

        // DELETE: api/BuyerAddresses/5
        [ResponseType(typeof(BuyerAddress))]
        public async Task<IHttpActionResult> DeleteBuyerAddress(int id)
        {
            BuyerAddress buyerAddress = await db.BuyerAddresses.FindAsync(id);
            if (buyerAddress == null)
            {
                return NotFound();
            }

            db.BuyerAddresses.Remove(buyerAddress);
            await db.SaveChangesAsync();

            return Ok(buyerAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BuyerAddressExists(int id)
        {
            return db.BuyerAddresses.Count(e => e.id == id) > 0;
        }
    }
}