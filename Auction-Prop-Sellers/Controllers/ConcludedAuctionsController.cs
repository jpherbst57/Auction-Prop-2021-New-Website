using Auction_Prop_API.Models.DataBaseModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class ConcludedAuctionsController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: ConcludedAuctions
        public ActionResult Index()
        {
            var concludedAuctions = db.ConcludedAuctions.Include(c => c.Bid).Include(c => c.Property).Include(c => c.RegisteredBuyer);
            return View((object)concludedAuctions.ToList());
        }

        // GET: ConcludedAuctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcludedAuction concludedAuction = db.ConcludedAuctions.Find(id);
            if (concludedAuction == null)
            {
                return HttpNotFound();
            }
            return View((object)concludedAuction);
        }

        // GET: ConcludedAuctions/Create
        public ActionResult Create()
        {
            ViewBag.HiegestBid = new SelectList(db.Bids, "BidID", "BuyerID");
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID");
            ViewBag.WinningBidder = new SelectList(db.RegisteredBuyers, "UserId", "FirstName");
            return View();
        }

        // POST: ConcludedAuctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropertyID,HiegestBid,WinningBidder,TimeOfConclution,ExceededReserve")] ConcludedAuction concludedAuction)
        {
            if (ModelState.IsValid)
            {
                db.ConcludedAuctions.Add(concludedAuction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HiegestBid = new SelectList(db.Bids, "BidID", "BuyerID", concludedAuction.HiegestBid);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", concludedAuction.PropertyID);
            ViewBag.WinningBidder = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", concludedAuction.WinningBidder);
            return View((object)concludedAuction);
        }

        // GET: ConcludedAuctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcludedAuction concludedAuction = db.ConcludedAuctions.Find(id);
            if (concludedAuction == null)
            {
                return HttpNotFound();
            }
            ViewBag.HiegestBid = new SelectList(db.Bids, "BidID", "BuyerID", concludedAuction.HiegestBid);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", concludedAuction.PropertyID);
            ViewBag.WinningBidder = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", concludedAuction.WinningBidder);
            return View((object)concludedAuction);
        }

        // POST: ConcludedAuctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropertyID,HiegestBid,WinningBidder,TimeOfConclution,ExceededReserve")] ConcludedAuction concludedAuction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concludedAuction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HiegestBid = new SelectList(db.Bids, "BidID", "BuyerID", concludedAuction.HiegestBid);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", concludedAuction.PropertyID);
            ViewBag.WinningBidder = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", concludedAuction.WinningBidder);
            return View((object)concludedAuction);
        }

        // GET: ConcludedAuctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcludedAuction concludedAuction = db.ConcludedAuctions.Find(id);
            if (concludedAuction == null)
            {
                return HttpNotFound();
            }
            return View((object)concludedAuction);
        }

        // POST: ConcludedAuctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConcludedAuction concludedAuction = db.ConcludedAuctions.Find(id);
            db.ConcludedAuctions.Remove(concludedAuction);
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
