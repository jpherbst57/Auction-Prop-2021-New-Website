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
    public class AuctionsController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Auctions
        public ICollection<AuctionNoR> GetAuctions()
        {



            List<AuctionNoR> Lys = new List<AuctionNoR>();
            foreach (Auction objct in db.Auctions.Include(a => a.Property))
            {


                AuctionNoR newObject = new AuctionNoR()
                {
                   // Bids= objct.Bids,
                    //  BankApproval = objct.BankApproval,
                    EndTime = objct.EndTime,
                   // Property = objct.Property,
                    //  Guarintee = objct.Guarintee,
                    StartTime = objct.StartTime,
                    //  Property = objct.Property,
                    PropertyID = objct.PropertyID,
                  //  RegesterDate = objct.RegesterDate,
                    //RegisteredBuyer = objct.RegisteredBuyer,
                  //  RegistrationFees = objct.RegistrationFees,
                  //  Signiture = objct.Signiture,
                  //  RegistrationStatus = objct.RegistrationStatus
                    //Seller = objct.Seller
                    // AuctionRegistration = fee.AuctionRegistration
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/Auctions/5
        [ResponseType(typeof(Auction))]
        public async Task<IHttpActionResult> GetAuction(int id)
        {
            Auction objct = await db.Auctions.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            AuctionNoR newObject = new AuctionNoR()
            {
                // Bids= objct.Bids,
                //  BankApproval = objct.BankApproval,
                EndTime = objct.EndTime,
               // Property = objct.Property,
                //  Guarintee = objct.Guarintee,
                StartTime = objct.StartTime,
                //  Property = objct.Property,
                PropertyID = objct.PropertyID,
                //  RegesterDate = objct.RegesterDate,
                //RegisteredBuyer = objct.RegisteredBuyer,
                //  RegistrationFees = objct.RegistrationFees,
                //  Signiture = objct.Signiture,
                //  RegistrationStatus = objct.RegistrationStatus
                //Seller = objct.Seller
                // AuctionRegistration = fee.AuctionRegistration
            };

            return Ok(newObject);
        }

        // PUT: api/Auctions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuction(int id, Auction auction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auction.PropertyID)
            {
                return BadRequest();
            }

            db.Entry(auction).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(id))
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

        // POST: api/Auctions
        [ResponseType(typeof(Auction))]
        public async Task<IHttpActionResult> PostAuction(Auction auction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Auctions.Add(auction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuctionExists(auction.PropertyID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = auction.PropertyID }, auction);
        }

        // DELETE: api/Auctions/5
        [ResponseType(typeof(Auction))]
        public async Task<IHttpActionResult> DeleteAuction(int id)
        {
            Auction auction = await db.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }

            db.Auctions.Remove(auction);
            await db.SaveChangesAsync();

            return Ok(auction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuctionExists(int id)
        {
            return db.Auctions.Count(e => e.PropertyID == id) > 0;
        }
    }
}