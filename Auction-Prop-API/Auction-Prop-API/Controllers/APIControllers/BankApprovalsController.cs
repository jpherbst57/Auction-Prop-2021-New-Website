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
        public IQueryable<BankApproval> GetBankApprovals()
        {
            return db.BankApprovals;
        }

        // GET: api/BankApprovals/5
        [ResponseType(typeof(BankApproval))]
        public async Task<IHttpActionResult> GetBankApproval(int id)
        {
            BankApproval bankApproval = await db.BankApprovals.FindAsync(id);
            if (bankApproval == null)
            {
                return NotFound();
            }

            return Ok(bankApproval);
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