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
    public class PropertyPhotoesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/PropertyPhotoes
        public ICollection<PropertyPhotoNoR> GetPropertyPhotos()
        {

           


            List<PropertyPhotoNoR> Lys = new List<PropertyPhotoNoR>();
            foreach (PropertyPhoto objct in db.PropertyPhotos.Include(p => p.Property))
            {


                PropertyPhotoNoR newObject = new PropertyPhotoNoR()
                {
                    Description = objct.Description,
                    ImageID = objct.ImageID,
                    PropertyId = objct.PropertyId,
                    PropertyPhotoPath = objct.PropertyPhotoPath,
                //   PropertyNoR = objct.PropertyNoR,
                    Title = objct.Title
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/PropertyPhotoes/5
        [ResponseType(typeof(PropertyPhoto))]
        public async Task<IHttpActionResult> GetPropertyPhoto(int id)
        {
            PropertyPhoto objct = await db.PropertyPhotos.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            PropertyPhotoNoR newObject = new PropertyPhotoNoR()
            {
                Description = objct.Description,
                ImageID = objct.ImageID,
                PropertyId = objct.PropertyId,
                PropertyPhotoPath = objct.PropertyPhotoPath,
                //   PropertyNoR = objct.PropertyNoR,
                Title = objct.Title
            };

            return Ok(newObject);
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