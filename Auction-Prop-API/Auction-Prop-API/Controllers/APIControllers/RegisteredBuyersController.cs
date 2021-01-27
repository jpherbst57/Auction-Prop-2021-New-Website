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
    public class RegisteredBuyersController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/RegisteredBuyers
        public IQueryable<RegisteredBuyer> GetRegisteredBuyers()
        {
            return db.RegisteredBuyers;
        }

        // GET: api/RegisteredBuyers/5
        [ResponseType(typeof(RegisteredBuyer))]
        public async Task<IHttpActionResult> GetRegisteredBuyer(string id)
        {
            RegisteredBuyer registeredBuyer = await db.RegisteredBuyers.FindAsync(id);
            if (registeredBuyer == null)
            {
                return NotFound();
            }

            return Ok(registeredBuyer);
        }

        // PUT: api/RegisteredBuyers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegisteredBuyer(string id, RegisteredBuyer registeredBuyer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registeredBuyer.UserId)
            {
                return BadRequest();
            }

            db.Entry(registeredBuyer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisteredBuyerExists(id))
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

        // POST: api/RegisteredBuyers
        [ResponseType(typeof(RegisteredBuyer))]
        public async Task<IHttpActionResult> PostRegisteredBuyer(RegisteredBuyer registeredBuyer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegisteredBuyers.Add(registeredBuyer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegisteredBuyerExists(registeredBuyer.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = registeredBuyer.UserId }, registeredBuyer);
        }

        // DELETE: api/RegisteredBuyers/5
        [ResponseType(typeof(RegisteredBuyer))]
        public async Task<IHttpActionResult> DeleteRegisteredBuyer(string id)
        {
            RegisteredBuyer registeredBuyer = await db.RegisteredBuyers.FindAsync(id);
            if (registeredBuyer == null)
            {
                return NotFound();
            }

            db.RegisteredBuyers.Remove(registeredBuyer);
            await db.SaveChangesAsync();

            return Ok(registeredBuyer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisteredBuyerExists(string id)
        {
            return db.RegisteredBuyers.Count(e => e.UserId == id) > 0;
        }
    }
}