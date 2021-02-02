﻿using System.Collections.Generic;
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
    public class ConcludedAuctionsController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/ConcludedAuctions
        public ICollection<ConcludedAuctionNoR> GetConcludedAuctions()
        {

            List<ConcludedAuctionNoR> Lys = new List<ConcludedAuctionNoR>();
            foreach (ConcludedAuction objct in db.ConcludedAuctions.Include(c => c.Bid).Include(c => c.Property).Include(c => c.RegisteredBuyer))
            {


                ConcludedAuctionNoR newObject = new ConcludedAuctionNoR()
                {
                    // Bids= objct.Bids,
                    //  BankApproval = objct.BankApproval,
                   // Bid = objct.Bid,
                    ExceededReserve = objct.ExceededReserve,
                    HiegestBid = objct.HiegestBid,
                   // Property = objct.Property,
                    //  Property = objct.Property,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                    PropertyID = objct.PropertyID,
                   // RegisteredBuyer = objct.RegisteredBuyer,
                    TimeOfConclution = objct.TimeOfConclution,
                    WinningBidder = objct.WinningBidder,
                    // TimeOfbid = objct.TimeOfbid
                    //Seller = objct.Seller
                    // AuctionRegistration = fee.AuctionRegistration
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/ConcludedAuctions/5
        [ResponseType(typeof(ConcludedAuction))]
        public async Task<IHttpActionResult> GetConcludedAuction(int id)
        {
            ConcludedAuction objct = await db.ConcludedAuctions.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            ConcludedAuctionNoR newObject = new ConcludedAuctionNoR()
            {
                // Bids= objct.Bids,
                //  BankApproval = objct.BankApproval,
                // Bid = objct.Bid,
                ExceededReserve = objct.ExceededReserve,
                HiegestBid = objct.HiegestBid,
                // Property = objct.Property,
                //  Property = objct.Property,
                // RegisteredBuyer = objct.RegisteredBuyer,
                PropertyID = objct.PropertyID,
                // RegisteredBuyer = objct.RegisteredBuyer,
                TimeOfConclution = objct.TimeOfConclution,
                WinningBidder = objct.WinningBidder,
                // TimeOfbid = objct.TimeOfbid
                //Seller = objct.Seller
                // AuctionRegistration = fee.AuctionRegistration
            };

            return Ok(newObject);
        }

        // PUT: api/ConcludedAuctions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConcludedAuction(int id, ConcludedAuction concludedAuction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != concludedAuction.PropertyID)
            {
                return BadRequest();
            }

            db.Entry(concludedAuction).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcludedAuctionExists(id))
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

        // POST: api/ConcludedAuctions
        [ResponseType(typeof(ConcludedAuction))]
        public async Task<IHttpActionResult> PostConcludedAuction(ConcludedAuction concludedAuction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConcludedAuctions.Add(concludedAuction);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConcludedAuctionExists(concludedAuction.PropertyID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = concludedAuction.PropertyID }, concludedAuction);
        }

        // DELETE: api/ConcludedAuctions/5
        [ResponseType(typeof(ConcludedAuction))]
        public async Task<IHttpActionResult> DeleteConcludedAuction(int id)
        {
            ConcludedAuction concludedAuction = await db.ConcludedAuctions.FindAsync(id);
            if (concludedAuction == null)
            {
                return NotFound();
            }

            db.ConcludedAuctions.Remove(concludedAuction);
            await db.SaveChangesAsync();

            return Ok(concludedAuction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConcludedAuctionExists(int id)
        {
            return db.ConcludedAuctions.Count(e => e.PropertyID == id) > 0;
        }
    }
}