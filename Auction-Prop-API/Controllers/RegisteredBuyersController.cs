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
    public class RegisteredBuyersController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/RegisteredBuyers
        public ICollection<RegisteredBuyerNoR> GetRegisteredBuyers()
        {

         

            List<RegisteredBuyerNoR> Lys = new List<RegisteredBuyerNoR>();
            foreach (RegisteredBuyer objct in db.RegisteredBuyers.Include(r => r.Deposit))
            {


                RegisteredBuyerNoR newObject = new RegisteredBuyerNoR()
                {
                    ApprovalStatus = objct.ApprovalStatus,
                   // Deposit = objct.Deposit,
                   // AuctionRegistrations = objct.AuctionRegistrations,
                   // Bids = objct.Bids,
                  //  BuyerAddresses = objct.BuyerAddresses,
                    FirstName = objct.FirstName,
                    // ConcludedAuctions = objct.ConcludedAuctions,
                     Signiture= objct.Signiture,
                   //  CopyOfIDPath = objct.DateOfBirth,
                     DateOfBirth = objct.DateOfBirth,
                     IDBuyerVerifyPhoto = objct.IDBuyerVerifyPhoto,
                     LastName = objct.LastName,
                     IDNumber = objct.IDNumber,
                     ProfilePhotoPath = objct.ProfilePhotoPath,
                     ProofOfBankAccount = objct.ProofOfBankAccount,
                     ProofOfResidencePath = objct.ProofOfResidencePath,
                     UserId= objct.UserId,
                     RegistrationDate = objct.RegistrationDate
                };
                try
                {
                    DepositNoR newDep = new DepositNoR();
                    newDep.Amount = objct.Deposit.Amount;
                    newDep.BuyerID = objct.Deposit.BuyerID;
                    newDep.DateOfPayment = objct.Deposit.DateOfPayment;
                    newDep.DepositReturned = objct.Deposit.DepositReturned;
                    newDep.ProofOfPaymentPath = objct.Deposit.ProofOfPaymentPath;
                    newDep.ProofOfReturnPayment = objct.Deposit.ProofOfReturnPayment;

                    newObject.Deposit = newDep;
                }
                catch { }

                try
                {
                    List<BuyerAddressNoR> lys = new List<BuyerAddressNoR>();

                    foreach (BuyerAddress bAdd in objct.BuyerAddresses)
                    {

                        BuyerAddressNoR newAdd = new BuyerAddressNoR();
                        newAdd.AddressID = bAdd.Address.AddressID;
                        newAdd.id = bAdd.id;
                        newAdd.UserID = bAdd.UserID;

                        lys.Add(newAdd);

                    }
                    newObject.BuyerAddresses = lys;

                }
                catch
                {

                }


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/RegisteredBuyers/5
        [ResponseType(typeof(RegisteredBuyer))]
        public async Task<IHttpActionResult> GetRegisteredBuyer(string id)
        {
            RegisteredBuyer objct = await db.RegisteredBuyers.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }


            RegisteredBuyerNoR newObject = new RegisteredBuyerNoR()
            {
                ApprovalStatus = objct.ApprovalStatus,
                // Deposit = objct.Deposit,
                // AuctionRegistrations = objct.AuctionRegistrations,
                // Bids = objct.Bids,
                //  BuyerAddresses = objct.BuyerAddresses,
                FirstName = objct.FirstName,
                // ConcludedAuctions = objct.ConcludedAuctions,
                Signiture = objct.Signiture,
                //  CopyOfIDPath = objct.DateOfBirth,
                DateOfBirth = objct.DateOfBirth,
                IDBuyerVerifyPhoto = objct.IDBuyerVerifyPhoto,
                LastName = objct.LastName,
                IDNumber = objct.IDNumber,
                ProfilePhotoPath = objct.ProfilePhotoPath,
                ProofOfBankAccount = objct.ProofOfBankAccount,
                ProofOfResidencePath = objct.ProofOfResidencePath,
                UserId = objct.UserId,
                RegistrationDate = objct.RegistrationDate
            };
            try
            {
                DepositNoR newDep = new DepositNoR();
                newDep.Amount = objct.Deposit.Amount;
                newDep.BuyerID = objct.Deposit.BuyerID;
                newDep.DateOfPayment = objct.Deposit.DateOfPayment;
                newDep.DepositReturned = objct.Deposit.DepositReturned;
                newDep.ProofOfPaymentPath = objct.Deposit.ProofOfPaymentPath;
                newDep.ProofOfReturnPayment = objct.Deposit.ProofOfReturnPayment;


                newObject.Deposit = newDep;
            }
            catch { }

            try
            {
                List<BuyerAddressNoR> lys = new List<BuyerAddressNoR>(); 

                foreach(BuyerAddress bAdd in objct.BuyerAddresses)
                {

                    BuyerAddressNoR newAdd = new BuyerAddressNoR();
                    newAdd.AddressID = bAdd.Address.AddressID;
                    newAdd.id = bAdd.id;
                    newAdd.UserID = bAdd.UserID;

                    lys.Add(newAdd);
                    
                }
                newObject.BuyerAddresses = lys;
              
            }
            catch
            {

            }

            return Ok(newObject);
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