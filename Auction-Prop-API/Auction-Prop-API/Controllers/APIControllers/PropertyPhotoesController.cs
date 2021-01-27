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
    public class PropertyPhotoesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/PropertyPhotoes
        public IQueryable<PropertyPhoto> GetPropertyPhotos()
        {
            return db.PropertyPhotos;
        }

        // GET: api/PropertyPhotoes/5
        [ResponseType(typeof(PropertyPhoto))]
        public async Task<IHttpActionResult> GetPropertyPhoto(int id)
        {
            PropertyPhoto propertyPhoto = await db.PropertyPhotos.FindAsync(id);
            if (propertyPhoto == null)
            {
                return NotFound();
            }

            return Ok(propertyPhoto);
        }

        // PUT: api/PropertyPhotoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPropertyPhoto(int id, PropertyPhoto propertyPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertyPhoto.ImageID)
            {
                return BadRequest();
            }

            db.Entry(propertyPhoto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyPhotoExists(id))
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

        // POST: api/PropertyPhotoes
        [ResponseType(typeof(PropertyPhoto))]
        public async Task<IHttpActionResult> PostPropertyPhoto(PropertyPhoto propertyPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PropertyPhotos.Add(propertyPhoto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = propertyPhoto.ImageID }, propertyPhoto);
        }

        // DELETE: api/PropertyPhotoes/5
        [ResponseType(typeof(PropertyPhoto))]
        public async Task<IHttpActionResult> DeletePropertyPhoto(int id)
        {
            PropertyPhoto propertyPhoto = await db.PropertyPhotos.FindAsync(id);
            if (propertyPhoto == null)
            {
                return NotFound();
            }

            db.PropertyPhotos.Remove(propertyPhoto);
            await db.SaveChangesAsync();

            return Ok(propertyPhoto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyPhotoExists(int id)
        {
            return db.PropertyPhotos.Count(e => e.ImageID == id) > 0;
        }
    }
}