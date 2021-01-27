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
    public class BankApprovalsController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/BankApprovals
        public ICollection<BankApprovalNoR> GetBankApprovals()
        {

           
            List<BankApprovalNoR> Lys = new List<BankApprovalNoR>();
            foreach (BankApproval objct in db.BankApprovals.Include(b => b.AuctionRegistration))
            {


                BankApprovalNoR newObject = new BankApprovalNoR()
                {
                    // Bids= objct.Bids,
                    //  BankApproval = objct.BankApproval,
                    ApprovalPath = objct.ApprovalPath,
                   // AuctionRegistration = objct.AuctionRegistration,
                    //  Guarintee = objct.Guarintee,
                    DateOfSubmision = objct.DateOfSubmision,
                    //  Property = objct.Property,
                    BankApprovalApprovalstatus = objct.BankApprovalApprovalstatus,
                    AuctionRegistrationID = objct.AuctionRegistrationID,
                    //RegisteredBuyer = objct.RegisteredBuyer,
                    //  RegistrationFees = objct.RegistrationFees,
                    //  Signiture = objct.Signiture,
                    //  RegistrationStatus = objct.RegistrationStatus
                    //Seller = objct.Seller
                    // AuctionRegistration = fee.AuctionRegistration
                };

                try
                {
                    newObject.AuctionRegistration = new AuctionRegistrationNoR();
                    newObject.AuctionRegistration.id = objct.AuctionRegistration.id;
                    newObject.AuctionRegistration.PropertyID = objct.AuctionRegistration.id;
                    newObject.AuctionRegistration.RegesterDate= objct.AuctionRegistration.RegesterDate;
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

        // GET: api/BankApprovals/5
        [ResponseType(typeof(BankApproval))]
        public async Task<IHttpActionResult> GetBankApproval(int id)
        {
            BankApproval objct = await db.BankApprovals.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }


            BankApprovalNoR newObject = new BankApprovalNoR()
            {
                // Bids= objct.Bids,
                //  BankApproval = objct.BankApproval,
                ApprovalPath = objct.ApprovalPath,
                // AuctionRegistration = objct.AuctionRegistration,
                //  Guarintee = objct.Guarintee,
                DateOfSubmision = objct.DateOfSubmision,
                //  Property = objct.Property,
                BankApprovalApprovalstatus = objct.BankApprovalApprovalstatus,
                AuctionRegistrationID = objct.AuctionRegistrationID,
                //RegisteredBuyer = objct.RegisteredBuyer,
                //  RegistrationFees = objct.RegistrationFees,
                //  Signiture = objct.Signiture,
                //  RegistrationStatus = objct.RegistrationStatus
                //Seller = objct.Seller
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

        // PUT: api/BankApprovals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBankApproval(int id, BankApproval bankApproval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bankApproval.AuctionRegistrationID)
            {
                return BadRequest();
            }

            db.Entry(bankApproval).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankApprovalExists(id))
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

        // POST: api/BankApprovals
        [ResponseType(typeof(BankApproval))]
        public async Task<IHttpActionResult> PostBankApproval(BankApproval bankApproval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BankApprovals.Add(bankApproval);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BankApprovalExists(bankApproval.AuctionRegistrationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bankApproval.AuctionRegistrationID }, bankApproval);
        }

        // DELETE: api/BankApprovals/5
        [ResponseType(typeof(BankApproval))]
        public async Task<IHttpActionResult> DeleteBankApproval(int id)
        {
            BankApproval bankApproval = await db.BankApprovals.FindAsync(id);
            if (bankApproval == null)
            {
                return NotFound();
            }

            db.BankApprovals.Remove(bankApproval);
            await db.SaveChangesAsync();

            return Ok(bankApproval);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BankApprovalExists(int id)
        {
            return db.BankApprovals.Count(e => e.AuctionRegistrationID == id) > 0;
        }
    }
}