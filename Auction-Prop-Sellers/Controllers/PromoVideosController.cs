using Auction_Prop_API.Models.DataBaseModels;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class PromoVideosController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: PromoVideos
        public async Task<ActionResult> Index()
        {
            var promoVideos = db.PromoVideos.Include(p => p.Property);
            return View((object)await promoVideos.ToListAsync());
        }

        // GET: PromoVideos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            if (promoVideo == null)
            {
                return HttpNotFound();
            }
            return View((object)promoVideo);
        }

        // GET: PromoVideos/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyID");
            return View();
        }

        // POST: PromoVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VideoID,PropertyID,VideoPath")] PromoVideo promoVideo)
        {
            if (ModelState.IsValid)
            {
                db.PromoVideos.Add(promoVideo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyID", promoVideo.PropertyID);
            return View((object)promoVideo);
        }

        // GET: PromoVideos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            if (promoVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyID", promoVideo.PropertyID);
            return View((object)promoVideo);
        }

        // POST: PromoVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VideoID,PropertyID,VideoPath")] PromoVideo promoVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promoVideo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyID", promoVideo.PropertyID);
            return View((object)promoVideo);
        }

        // GET: PromoVideos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            if (promoVideo == null)
            {
                return HttpNotFound();
            }
            return View((object)promoVideo);
        }

        // POST: PromoVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            db.PromoVideos.Remove(promoVideo);
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
