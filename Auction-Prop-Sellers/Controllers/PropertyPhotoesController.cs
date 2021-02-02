using Auction_Prop_API.Models.DataBaseModels;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class PropertyPhotoesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: PropertyPhotoes
        public async Task<ActionResult> Index()
        {
            var propertyPhotos = db.PropertyPhotos.Include(p => p.Property);
            return View((object)await propertyPhotos.ToListAsync());
        }

        // GET: PropertyPhotoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPhoto propertyPhoto = await db.PropertyPhotos.FindAsync(id);
            if (propertyPhoto == null)
            {
                return HttpNotFound();
            }
            return View((object)propertyPhoto);
        }

        // GET: PropertyPhotoes/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyID", "PropertyID");
            return View();
        }

        // POST: PropertyPhotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ImageID,PropertyId,Title,Description,PropertyPhotoPath")] PropertyPhoto propertyPhoto)
        {
            if (ModelState.IsValid)
            {
                db.PropertyPhotos.Add(propertyPhoto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyID", "PropertyID", propertyPhoto.PropertyId);
            return View((object)propertyPhoto);
        }

        // GET: PropertyPhotoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPhoto propertyPhoto = await db.PropertyPhotos.FindAsync(id);
            if (propertyPhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyID", "PropertyID", propertyPhoto.PropertyId);
            return View((object)propertyPhoto);
        }

        // POST: PropertyPhotoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ImageID,PropertyId,Title,Description,PropertyPhotoPath")] PropertyPhoto propertyPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyPhoto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyID", "PropertyID", propertyPhoto.PropertyId);
            return View((object)propertyPhoto);
        }

        // GET: PropertyPhotoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPhoto propertyPhoto = await db.PropertyPhotos.FindAsync(id);
            if (propertyPhoto == null)
            {
                return HttpNotFound();
            }
            return View((object)propertyPhoto);
        }

        // POST: PropertyPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PropertyPhoto propertyPhoto = await db.PropertyPhotos.FindAsync(id);
            db.PropertyPhotos.Remove(propertyPhoto);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
