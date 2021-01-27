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
    public class AuctionRegistrationsController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/AuctionRegistrations
        public IQueryable<AuctionRegistration> GetAuctionRegistrations()
        {
            return db.AuctionRegistrations;
        }

        // GET: api/AuctionRegistrations/5
        [ResponseType(typeof(AuctionRegistration))]
        public async Task<IHttpActionResult> GetAuctionRegistration(int id)
        {
            AuctionRegistration auctionRegistration = await db.AuctionRegistrations.FindAsync(id);
            if (auctionRegistration == null)
            {
                return NotFound();
            }

            return Ok(auctionRegistration);
        }

        // PUT: api/AuctionRegistrations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuctionRegistration(int id, AuctionRegistration auctionRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auctionRegistration.id)
            {
                return BadRequest();
            }

            db.Entry(auctionRegistration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionRegistrationExists(id))
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

        // POST: api/AuctionRegistrations
        [ResponseType(typeof(AuctionRegistration))]
        public async Task<IHttpActionResult> PostAuctionRegistration(AuctionRegistration auctionRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AuctionRegistrations.Add(auctionRegistration);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = auctionRegistration.id }, auctionRegistration);
        }

        // DELETE: api/AuctionRegistrations/5
        [ResponseType(typeof(AuctionRegistration))]
        public async Task<IHttpActionResult> DeleteAuctionRegistration(int id)
        {
            AuctionRegistration auctionRegistration = await db.AuctionRegistrations.FindAsync(id);
            if (auctionRegistration == null)
            {
                return NotFound();
            }

            db.AuctionRegistrations.Remove(auctionRegistration);
            await db.SaveChangesAsync();

            return Ok(auctionRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuctionRegistrationExists(int id)
        {
            return db.AuctionRegistrations.Count(e => e.id == id) > 0;
        }
    }
}