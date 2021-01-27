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
    public class RetailersController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Retailers
        public ICollection<RetailerNoR> GetRetailers()
        {

            List<RetailerNoR> Lys = new List<RetailerNoR>();
            foreach (Retailer objct in db.Retailers.Include(r => r.Seller))
            {


                RetailerNoR newObject = new RetailerNoR()
                {
                     Branch = objct.Branch,
                      CompanyContactNumber = objct.CompanyContactNumber,
                     CompanyDescription = objct.CompanyDescription,
                     CompanyEmail = objct.CompanyEmail,
                     CompaynLogoPath = objct.CompaynLogoPath,
                    RetailerName  =  objct.RetailerName,
                    // Seller = objct.Seller,
                     Signature = objct.Signature,
                     UserID = objct.UserID,
                     };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/Retailers/5
        [ResponseType(typeof(Retailer))]
        public async Task<IHttpActionResult> GetRetailer(string id)
        {
            Retailer objct = await db.Retailers.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            RetailerNoR newObject = new RetailerNoR()
            {
                Branch = objct.Branch,
                CompanyContactNumber = objct.CompanyContactNumber,
                CompanyDescription = objct.CompanyDescription,
                CompanyEmail = objct.CompanyEmail,
                CompaynLogoPath = objct.CompaynLogoPath,
                RetailerName = objct.RetailerName,
                // Seller = objct.Seller,
                Signature = objct.Signature,
                UserID = objct.UserID,
            };

            return Ok(newObject);
        }

        // PUT: api/Retailers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRetailer(string id, Retailer retailer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != retailer.UserID)
            {
                return BadRequest();
            }

            db.Entry(retailer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetailerExists(id))
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

        // POST: api/Retailers
        [ResponseType(typeof(Retailer))]
        public async Task<IHttpActionResult> PostRetailer(Retailer retailer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Retailers.Add(retailer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RetailerExists(retailer.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = retailer.UserID }, retailer);
        }

        // DELETE: api/Retailers/5
        [ResponseType(typeof(Retailer))]
        public async Task<IHttpActionResult> DeleteRetailer(string id)
        {
            Retailer retailer = await db.Retailers.FindAsync(id);
            if (retailer == null)
            {
                return NotFound();
            }

            db.Retailers.Remove(retailer);
            await db.SaveChangesAsync();

            return Ok(retailer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RetailerExists(string id)
        {
            return db.Retailers.Count(e => e.UserID == id) > 0;
        }
    }
}