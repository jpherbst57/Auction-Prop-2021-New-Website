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
    public class PrivateSellersController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/PrivateSellers
        public ICollection<PrivateSellerNoR> GetPrivateSellers()
        {

       
            List<PrivateSellerNoR> Lys = new List<PrivateSellerNoR>();
            foreach (PrivateSeller objct in db.PrivateSellers.Include(p => p.Seller))
            {


                PrivateSellerNoR newObject = new PrivateSellerNoR()
                {
                   IDNumber= objct.IDNumber,
                    //  BankApproval = objct.BankApproval,
                    // Bid = objct.Bid,
                    //  AuctionRegistration = objct.AuctionRegistration,
                    ProofOfResedence= objct.ProofOfResedence,
                    // Property = objct.Property,
                    //  Property = objct.Property,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                  //  Seller = objct.Seller,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                    Signiture = objct.Signiture,
                    UserID = objct.UserID,
                    // = objct.ProofOfPaymentPath,
                    // ProofOfReturnPayment = objct.ProofOfReturnPayment
                    // AuctionRegistration = fee.AuctionRegistration
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/PrivateSellers/5
        [ResponseType(typeof(PrivateSeller))]
        public async Task<IHttpActionResult> GetPrivateSeller(string id)
        {
            PrivateSeller objct = await db.PrivateSellers.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            PrivateSellerNoR newObject = new PrivateSellerNoR()
            {
                IDNumber = objct.IDNumber,
                //  BankApproval = objct.BankApproval,
                // Bid = objct.Bid,
                //  AuctionRegistration = objct.AuctionRegistration,
                ProofOfResedence = objct.ProofOfResedence,
                // Property = objct.Property,
                //  Property = objct.Property,
                // RegisteredBuyer = objct.RegisteredBuyer,
                //  Seller = objct.Seller,
                // RegisteredBuyer = objct.RegisteredBuyer,
                Signiture = objct.Signiture,
                UserID = objct.UserID,
                // = objct.ProofOfPaymentPath,
                // ProofOfReturnPayment = objct.ProofOfReturnPayment
                // AuctionRegistration = fee.AuctionRegistration
            };

            return Ok(newObject);
        }

        // PUT: api/PrivateSellers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrivateSeller(string id, PrivateSeller privateSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != privateSeller.UserID)
            {
                return BadRequest();
            }

            db.Entry(privateSeller).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateSellerExists(id))
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

        // POST: api/PrivateSellers
        [ResponseType(typeof(PrivateSeller))]
        public async Task<IHttpActionResult> PostPrivateSeller(PrivateSeller privateSeller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrivateSellers.Add(privateSeller);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrivateSellerExists(privateSeller.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = privateSeller.UserID }, privateSeller);
        }

        // DELETE: api/PrivateSellers/5
        [ResponseType(typeof(PrivateSeller))]
        public async Task<IHttpActionResult> DeletePrivateSeller(string id)
        {
            PrivateSeller privateSeller = await db.PrivateSellers.FindAsync(id);
            if (privateSeller == null)
            {
                return NotFound();
            }

            db.PrivateSellers.Remove(privateSeller);
            await db.SaveChangesAsync();

            return Ok(privateSeller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrivateSellerExists(string id)
        {
            return db.PrivateSellers.Count(e => e.UserID == id) > 0;
        }
    }
}