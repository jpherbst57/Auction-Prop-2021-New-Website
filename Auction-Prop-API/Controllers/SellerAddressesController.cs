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
    public class SellerAddressesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/SellerAddresses
        public ICollection<SellerAddressNoR> GetSellerAddresses()
        {

         
            List<SellerAddressNoR> Lys = new List<SellerAddressNoR>();
            foreach (SellerAddress objct in db.SellerAddresses.Include(s => s.Address).Include(s => s.Seller))
            {


                SellerAddressNoR newObject = new SellerAddressNoR()
                {
                   //  Seller = objct.Seller,
                  //  Address = objct.Address,
                    AddressID = objct.AddressID,
                    id = objct.id,
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/SellerAddresses/5
        [ResponseType(typeof(SellerAddress))]
        public async Task<IHttpActionResult> GetSellerAddress(int id)
        {
            SellerAddress objct = await db.SellerAddresses.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            SellerAddressNoR newObject = new SellerAddressNoR()
            {
                //  Seller = objct.Seller,
                //  Address = objct.Address,
                AddressID = objct.AddressID,
                id = objct.id,
            };

            return Ok(newObject);
        }

        // PUT: api/SellerAddresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSellerAddress(int id, SellerAddress sellerAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sellerAddress.id)
            {
                return BadRequest();
            }

            db.Entry(sellerAddress).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerAddressExists(id))
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

        // POST: api/SellerAddresses
        [ResponseType(typeof(SellerAddress))]
        public async Task<IHttpActionResult> PostSellerAddress(SellerAddress sellerAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SellerAddresses.Add(sellerAddress);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sellerAddress.id }, sellerAddress);
        }

        // DELETE: api/SellerAddresses/5
        [ResponseType(typeof(SellerAddress))]
        public async Task<IHttpActionResult> DeleteSellerAddress(int id)
        {
            SellerAddress sellerAddress = await db.SellerAddresses.FindAsync(id);
            if (sellerAddress == null)
            {
                return NotFound();
            }

            db.SellerAddresses.Remove(sellerAddress);
            await db.SaveChangesAsync();

            return Ok(sellerAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SellerAddressExists(int id)
        {
            return db.SellerAddresses.Count(e => e.id == id) > 0;
        }
    }
}