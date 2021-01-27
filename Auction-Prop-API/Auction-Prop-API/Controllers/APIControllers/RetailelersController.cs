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
    public class RetailelersController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Retailelers
        public IQueryable<Retaileler> GetRetailelers()
        {
            return db.Retailelers;
        }

        // GET: api/Retailelers/5
        [ResponseType(typeof(Retaileler))]
        public async Task<IHttpActionResult> GetRetaileler(string id)
        {
            Retaileler retaileler = await db.Retailelers.FindAsync(id);
            if (retaileler == null)
            {
                return NotFound();
            }

            return Ok(retaileler);
        }

        // PUT: api/Retailelers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRetaileler(string id, Retaileler retaileler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != retaileler.UserID)
            {
                return BadRequest();
            }

            db.Entry(retaileler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetailelerExists(id))
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

        // POST: api/Retailelers
        [ResponseType(typeof(Retaileler))]
        public async Task<IHttpActionResult> PostRetaileler(Retaileler retaileler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Retailelers.Add(retaileler);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RetailelerExists(retaileler.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = retaileler.UserID }, retaileler);
        }

        // DELETE: api/Retailelers/5
        [ResponseType(typeof(Retaileler))]
        public async Task<IHttpActionResult> DeleteRetaileler(string id)
        {
            Retaileler retaileler = await db.Retailelers.FindAsync(id);
            if (retaileler == null)
            {
                return NotFound();
            }

            db.Retailelers.Remove(retaileler);
            await db.SaveChangesAsync();

            return Ok(retaileler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RetailelerExists(string id)
        {
            return db.Retailelers.Count(e => e.UserID == id) > 0;
        }
    }
}