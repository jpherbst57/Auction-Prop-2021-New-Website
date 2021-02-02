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
    public class AuctioneersController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Auctioneers
        public ICollection<AuctioneerNoR> GetAuctioneers()
        {

           


            List<AuctioneerNoR> Lys = new List<AuctioneerNoR>();
            foreach (Auctioneer objct in db.Auctioneers.Include(a => a.Seller))
            {


                AuctioneerNoR newObject = new AuctioneerNoR()
                {
                    Branch= objct.Branch,
                    CompanyContactNumber = objct.CompanyContactNumber,
                    CompanyDescriprion = objct.CompanyDescriprion,
                    CompanyEmail = objct.CompanyEmail,
                    CompanyName = objct.CompanyName,
                    CompanyLogo = objct.CompanyLogo,
                    Signature = objct.Signature,
                    UserID = objct.UserID
                    //Seller = objct.Seller
                    // AuctionRegistration = fee.AuctionRegistration
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/Auctioneers/5
        [ResponseType(typeof(Auctioneer))]
        public async Task<IHttpActionResult> GetAuctioneer(string id)
        {
            Auctioneer objct = await db.Auctioneers.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            AuctioneerNoR newObject = new AuctioneerNoR()
            {
                Branch = objct.Branch,
                CompanyContactNumber = objct.CompanyContactNumber,
                CompanyDescriprion = objct.CompanyDescriprion,
                CompanyEmail = objct.CompanyEmail,
                CompanyName = objct.CompanyName,
                CompanyLogo = objct.CompanyLogo,
                Signature = objct.Signature,
                UserID = objct.UserID
                //Seller = objct.Seller
                // AuctionRegistration = fee.AuctionRegistration
            };

            return Ok(newObject);
        }

        // PUT: api/Auctioneers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuctioneer(string id, Auctioneer auctioneer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auctioneer.UserID)
            {
                return BadRequest();
            }

            db.Entry(auctioneer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctioneerExists(id))
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

        // POST: api/Auctioneers
        [ResponseType(typeof(Auctioneer))]
        public async Task<IHttpActionResult> PostAuctioneer(Auctioneer auctioneer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Auctioneers.Add(auctioneer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuctioneerExists(auctioneer.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = auctioneer.UserID }, auctioneer);
        }

        // DELETE: api/Auctioneers/5
        [ResponseType(typeof(Auctioneer))]
        public async Task<IHttpActionResult> DeleteAuctioneer(string id)
        {
            Auctioneer auctioneer = await db.Auctioneers.FindAsync(id);
            if (auctioneer == null)
            {
                return NotFound();
            }

            db.Auctioneers.Remove(auctioneer);
            await db.SaveChangesAsync();

            return Ok(auctioneer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuctioneerExists(string id)
        {
            return db.Auctioneers.Count(e => e.UserID == id) > 0;
        }
    }
}