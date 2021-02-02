using Auction_Prop_API.Models.DataBaseModels;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class AuctioneersController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Auctioneers
        public async Task<ActionResult> Index()
        {
            var auctioneers = db.Auctioneers.Include(a => a.Seller);
            return View((object)await auctioneers.ToListAsync());
        }

        // GET: Auctioneers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auctioneer auctioneer = await db.Auctioneers.FindAsync(id);
            if (auctioneer == null)
            {
                return HttpNotFound();
            }
            return View((object)auctioneer);
        }

        // GET: Auctioneers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName");
            return View();
        }

        // POST: Auctioneers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,CompanyName,Branch,CompanyLogo,CompanyContactNumber,CompanyEmail,Signature,CompanyDescriprion")] Auctioneer auctioneer)
        {
            if (ModelState.IsValid)
            {
                db.Auctioneers.Add(auctioneer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", auctioneer.UserID);
            return View((object)auctioneer);
        }

        // GET: Auctioneers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auctioneer auctioneer = await db.Auctioneers.FindAsync(id);
            if (auctioneer == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", auctioneer.UserID);
            return View((object)auctioneer);
        }

        // POST: Auctioneers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserID,CompanyName,Branch,CompanyLogo,CompanyContactNumber,CompanyEmail,Signature,CompanyDescriprion")] Auctioneer auctioneer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auctioneer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", auctioneer.UserID);
            return View((object)auctioneer);
        }

        // GET: Auctioneers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auctioneer auctioneer = await db.Auctioneers.FindAsync(id);
            if (auctioneer == null)
            {
                return HttpNotFound();
            }
            return View((object)auctioneer);
        }

        // POST: Auctioneers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Auctioneer auctioneer = await db.Auctioneers.FindAsync(id);
            db.Auctioneers.Remove(auctioneer);
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
