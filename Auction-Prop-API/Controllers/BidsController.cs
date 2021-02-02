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
    public class BidsController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Bids
        public ICollection<BidNoR> GetBids()
        {



            List<BidNoR> Lys = new List<BidNoR>();
            foreach (Bid objct in db.Bids.Include(b => b.Auction).Include(b => b.RegisteredBuyer))
            {


                BidNoR newObject = new BidNoR()
                {
                    // Bids= objct.Bids,
                    //  BankApproval = objct.BankApproval,
                    AmuntOfBid = objct.AmuntOfBid,
                    // AuctionRegistration = objct.AuctionRegistration,
                    //  Guarintee = objct.Guarintee,
                  //  Auction = objct.Auction,
                    //  Property = objct.Property,
                    BidID = objct.BidID,
                    BuyerID = objct.BuyerID,
                  //  ConcludedAuctions = objct.ConcludedAuctions,
                    PropertyID = objct.PropertyID,
                   // RegisteredBuyer = objct.RegisteredBuyer,
                    TimeOfbid = objct.TimeOfbid
                    //Seller = objct.Seller
                    // AuctionRegistration = fee.AuctionRegistration
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/Bids/5
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> GetBid(int id)
        {
            Bid objct = await db.Bids.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            BidNoR newObject = new BidNoR()
            {
                // Bids= objct.Bids,
                //  BankApproval = objct.BankApproval,
                AmuntOfBid = objct.AmuntOfBid,
                // AuctionRegistration = objct.AuctionRegistration,
                //  Guarintee = objct.Guarintee,
                //  Auction = objct.Auction,
                //  Property = objct.Property,
                BidID = objct.BidID,
                BuyerID = objct.BuyerID,
                //  ConcludedAuctions = objct.ConcludedAuctions,
                PropertyID = objct.PropertyID,
                // RegisteredBuyer = objct.RegisteredBuyer,
                TimeOfbid = objct.TimeOfbid
                //Seller = objct.Seller
                // AuctionRegistration = fee.AuctionRegistration
            };

            return Ok(newObject);
        }

        // PUT: api/Bids/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBid(int id, Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bid.BidID)
            {
                return BadRequest();
            }

            db.Entry(bid).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(id))
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

        // POST: api/Bids
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> PostBid(Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bids.Add(bid);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bid.BidID }, bid);
        }

        // DELETE: api/Bids/5
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> DeleteBid(int id)
        {
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            db.Bids.Remove(bid);
            await db.SaveChangesAsync();

            return Ok(bid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BidExists(int id)
        {
            return db.Bids.Count(e => e.BidID == id) > 0;
        }
    }
}