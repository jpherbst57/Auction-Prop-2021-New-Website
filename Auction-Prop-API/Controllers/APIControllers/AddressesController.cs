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
    public class AddressesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Addresses
        public ICollection<AddressNoR> GetAddresses()
        {

            List<AddressNoR> addresLys = new List<AddressNoR>();
            foreach (Address add in db.Addresses)
            {


                AddressNoR newAdd = new AddressNoR()
                {

                    AddressID = add.AddressID,
                    Country = add.Country,
                    City = add.City,
                    Supburb = add.Supburb,
                    Area = add.Area,
                    Street = add.Street,
                    Number = add.Number,
                    // BuyerAddresses = add.BuyerAddresses,
                    //"SellerAddresses": []
                };


                addresLys.Add(newAdd);
            }

            return addresLys;
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Address))]
        public async Task<IHttpActionResult> GetAddress(int id)
        {
            Address add = await db.Addresses.FindAsync(id);
            if (add == null)
            {
                return NotFound();
            }


            AddressNoR newAdd = new AddressNoR()
            {

                AddressID = add.AddressID,
                Country = add.Country,
                City = add.City,
                Supburb = add.Supburb,
                Area = add.Area,
                Street = add.Street,
                Number = add.Number,
                // BuyerAddresses = add.BuyerAddresses,
                //"SellerAddresses": []
            };

            return Ok(newAdd);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.AddressID)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public async Task<IHttpActionResult> PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(address);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = address.AddressID }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public async Task<IHttpActionResult> DeleteAddress(int id)
        {
            Address address = await db.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            await db.SaveChangesAsync();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.AddressID == id) > 0;
        }
    }
}