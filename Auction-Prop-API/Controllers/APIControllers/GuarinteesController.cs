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
    public class GuarinteesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Guarintees
        public ICollection<GuarinteeNoR> GetGuarintees()
        {

            

            List<GuarinteeNoR> Lys = new List<GuarinteeNoR>();
            foreach (Guarintee objct in db.Guarintees.Include(g => g.AuctionRegistration))
            {


                GuarinteeNoR newObject = new GuarinteeNoR()
                {
                    // Bids= objct.Bids,
                    //  BankApproval = objct.BankApproval,
                    // Bid = objct.Bid,
                  //  AuctionRegistration = objct.AuctionRegistration,
                    DateOfSubmition = objct.DateOfSubmition,
                    // Property = objct.Property,
                    //  Property = objct.Property,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                    AuctionRegistrationID = objct.AuctionRegistrationID,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                    GuarinteeApproval = objct.GuarinteeApproval,
                    GuarinteePath = objct.GuarinteePath,
                    // = objct.ProofOfPaymentPath,
                   // ProofOfReturnPayment = objct.ProofOfReturnPayment
                    // AuctionRegistration = fee.AuctionRegistration
                };

                try
                {
                    newObject.AuctionRegistration = new AuctionRegistrationNoR();
                    newObject.AuctionRegistration.id = objct.AuctionRegistration.id;
                    newObject.AuctionRegistration.PropertyID = objct.AuctionRegistration.id;
                    newObject.AuctionRegistration.RegesterDate = objct.AuctionRegistration.RegesterDate;
                    newObject.AuctionRegistration.RegistrationFees = objct.AuctionRegistration.RegistrationFees;
                    newObject.AuctionRegistration.Signiture = objct.AuctionRegistration.Signiture;
                    newObject.AuctionRegistration.RegistrationStatus = objct.AuctionRegistration.RegistrationStatus;
                    newObject.AuctionRegistration.BuyerId = objct.AuctionRegistration.BuyerId;
                    newObject.AuctionRegistration.Bonded = objct.AuctionRegistration.Bonded;

                }
                catch { }



                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/Guarintees/5
        [ResponseType(typeof(Guarintee))]
        public async Task<IHttpActionResult> GetGuarintee(int id)
        {
            Guarintee objct = await db.Guarintees.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            GuarinteeNoR newObject = new GuarinteeNoR()
            {
                // Bids= objct.Bids,
                //  BankApproval = objct.BankApproval,
                // Bid = objct.Bid,
                //  AuctionRegistration = objct.AuctionRegistration,
                DateOfSubmition = objct.DateOfSubmition,
                // Property = objct.Property,
                //  Property = objct.Property,
                // RegisteredBuyer = objct.RegisteredBuyer,
                AuctionRegistrationID = objct.AuctionRegistrationID,
                // RegisteredBuyer = objct.RegisteredBuyer,
                GuarinteeApproval = objct.GuarinteeApproval,
                GuarinteePath = objct.GuarinteePath,
                // = objct.ProofOfPaymentPath,
                // ProofOfReturnPayment = objct.ProofOfReturnPayment
                // AuctionRegistration = fee.AuctionRegistration
            };

            try
            {
                newObject.AuctionRegistration = new AuctionRegistrationNoR();
                newObject.AuctionRegistration.id = objct.AuctionRegistration.id;
                newObject.AuctionRegistration.PropertyID = objct.AuctionRegistration.id;
                newObject.AuctionRegistration.RegesterDate = objct.AuctionRegistration.RegesterDate;
                newObject.AuctionRegistration.RegistrationFees = objct.AuctionRegistration.RegistrationFees;
                newObject.AuctionRegistration.Signiture = objct.AuctionRegistration.Signiture;
                newObject.AuctionRegistration.RegistrationStatus = objct.AuctionRegistration.RegistrationStatus;
                newObject.AuctionRegistration.BuyerId = objct.AuctionRegistration.BuyerId;
                newObject.AuctionRegistration.Bonded = objct.AuctionRegistration.Bonded;

            }
            catch { }


            return Ok(newObject);
        }

        // PUT: api/Guarintees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGuarintee(int id, Guarintee guarintee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guarintee.AuctionRegistrationID)
            {
                return BadRequest();
            }

            db.Entry(guarintee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuarinteeExists(id))
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

        // POST: api/Guarintees
        [ResponseType(typeof(Guarintee))]
        public async Task<IHttpActionResult> PostGuarintee(Guarintee guarintee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guarintees.Add(guarintee);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GuarinteeExists(guarintee.AuctionRegistrationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guarintee.AuctionRegistrationID }, guarintee);
        }

        // DELETE: api/Guarintees/5
        [ResponseType(typeof(Guarintee))]
        public async Task<IHttpActionResult> DeleteGuarintee(int id)
        {
            Guarintee guarintee = await db.Guarintees.FindAsync(id);
            if (guarintee == null)
            {
                return NotFound();
            }

            db.Guarintees.Remove(guarintee);
            await db.SaveChangesAsync();

            return Ok(guarintee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuarinteeExists(int id)
        {
            return db.Guarintees.Count(e => e.AuctionRegistrationID == id) > 0;
        }
    }
}