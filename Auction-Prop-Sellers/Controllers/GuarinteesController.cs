using Auction_Prop_API.Models.DataBaseModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class GuarinteesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Guarintees
        public ActionResult Index()
        {
            var guarintees = db.Guarintees.Include(g => g.AuctionRegistration);
            return View((object)guarintees.ToList());
        }

        // GET: Guarintees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guarintee guarintee = db.Guarintees.Find(id);
            if (guarintee == null)
            {
                return HttpNotFound();
            }
            return View((object)guarintee);
        }

        // GET: Guarintees/Create
        public ActionResult Create()
        {
            ViewBag.AuctionRegistrationID = new SelectList(db.AuctionRegistrations, "id", "BuyerId");
            return View();
        }

        // POST: Guarintees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuctionRegistrationID,GuarinteePath,GuarinteeApproval,DateOfSubmition")] Guarintee guarintee)
        {
            if (ModelState.IsValid)
            {
                db.Guarintees.Add(guarintee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionRegistrationID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", guarintee.AuctionRegistrationID);
            return View((object)guarintee);
        }

        // GET: Guarintees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guarintee guarintee = db.Guarintees.Find(id);
            if (guarintee == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionRegistrationID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", guarintee.AuctionRegistrationID);
            return View((object)guarintee);
        }

        // POST: Guarintees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuctionRegistrationID,GuarinteePath,GuarinteeApproval,DateOfSubmition")] Guarintee guarintee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guarintee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionRegistrationID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", guarintee.AuctionRegistrationID);
            return View((object)guarintee);
        }

        // GET: Guarintees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guarintee guarintee = db.Guarintees.Find(id);
            if (guarintee == null)
            {
                return HttpNotFound();
            }
            return View((object)guarintee);
        }

        // POST: Guarintees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guarintee guarintee = db.Guarintees.Find(id);
            db.Guarintees.Remove(guarintee);
            db.SaveChanges();
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
