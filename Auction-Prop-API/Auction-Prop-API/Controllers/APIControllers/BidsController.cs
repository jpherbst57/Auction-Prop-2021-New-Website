﻿using System;
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
    public class BidsController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Bids
        public IQueryable<Bid> GetBids()
        {
            return db.Bids;
        }

        // GET: api/Bids/5
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> GetBid(int id)
        {
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
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