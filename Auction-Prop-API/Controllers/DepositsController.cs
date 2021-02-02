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
    public class DepositsController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Deposits
        public ICollection<DepositNoR> GetDeposits()
        {

         
            List<DepositNoR> Lys = new List<DepositNoR>();
            foreach (Deposit objct in db.Deposits.Include(d => d.RegisteredBuyer))
            {


                DepositNoR newObject = new DepositNoR()
                {
                    // Bids= objct.Bids,
                    //  BankApproval = objct.BankApproval,
                    // Bid = objct.Bid,
                    Amount = objct.Amount,
                    BuyerID = objct.BuyerID,
                    // Property = objct.Property,
                    //  Property = objct.Property,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                    DateOfPayment = objct.DateOfPayment,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                    DepositReturned = objct.DepositReturned,
                    Paid = objct.Paid,
                    ProofOfPaymentPath = objct.ProofOfPaymentPath,
                    ProofOfReturnPayment = objct.ProofOfReturnPayment
                    // AuctionRegistration = fee.AuctionRegistration
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/Deposits/5
        [ResponseType(typeof(Deposit))]
        public async Task<IHttpActionResult> GetDeposit(string id)
        {
            Deposit objct = await db.Deposits.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            DepositNoR newObject = new DepositNoR()
            {
                // Bids= objct.Bids,
                //  BankApproval = objct.BankApproval,
                // Bid = objct.Bid,
                Amount = objct.Amount,
                BuyerID = objct.BuyerID,
                // Property = objct.Property,
                //  Property = objct.Property,
                // RegisteredBuyer = objct.RegisteredBuyer,
                DateOfPayment = objct.DateOfPayment,
                // RegisteredBuyer = objct.RegisteredBuyer,
                DepositReturned = objct.DepositReturned,
                Paid = objct.Paid,
                ProofOfPaymentPath = objct.ProofOfPaymentPath,
                ProofOfReturnPayment = objct.ProofOfReturnPayment
                // AuctionRegistration = fee.AuctionRegistration
            };

            return Ok(newObject);
        }

        // PUT: api/Deposits/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeposit(string id, Deposit deposit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deposit.BuyerID)
            {
                return BadRequest();
            }

            db.Entry(deposit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositExists(id))
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

        // POST: api/Deposits
        [ResponseType(typeof(Deposit))]
        public async Task<IHttpActionResult> PostDeposit(Deposit deposit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deposits.Add(deposit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepositExists(deposit.BuyerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deposit.BuyerID }, deposit);
        }

        // DELETE: api/Deposits/5
        [ResponseType(typeof(Deposit))]
        public async Task<IHttpActionResult> DeleteDeposit(string id)
        {
            Deposit deposit = await db.Deposits.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }

            db.Deposits.Remove(deposit);
            await db.SaveChangesAsync();

            return Ok(deposit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepositExists(string id)
        {
            return db.Deposits.Count(e => e.BuyerID == id) > 0;
        }
    }
}