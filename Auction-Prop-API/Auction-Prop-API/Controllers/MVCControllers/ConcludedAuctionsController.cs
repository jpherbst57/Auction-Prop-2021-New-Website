using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers.MVCControllers
{
    public class ConcludedAuctionsController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: ConcludedAuctions
        public async Task<ActionResult> Index()
        {
            var concludedAuctions = db.ConcludedAuctions.Include(c => c.Bid).Include(c => c.RegisteredBuyer);
            return View(await concludedAuctions.ToListAsync());
        }

        // GET: ConcludedAuctions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcludedAuction concludedAuction = await db.ConcludedAuctions.FindAsync(id);
            if (concludedAuction == null)
            {
                return HttpNotFound();
            }
            return View(concludedAuction);
        }

        // GET: ConcludedAuctions/Create
        public ActionResult Create()
        {
            ViewBag.HiegestBid = new SelectList(db.Bids, "BidID", "BuyerID");
            ViewBag.WinningBidder = new SelectList(db.RegisteredBuyers, "UserId", "FirstName");
            return View();
        }

        // POST: ConcludedAuctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PropertyID,HiegestBid,WinningBidder,TimeOfConclution,ExceededReserve")] ConcludedAuction concludedAuction)
        {
            if (ModelState.IsValid)
            {
                db.ConcludedAuctions.Add(concludedAuction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.HiegestBid = new SelectList(db.Bids, "BidID", "BuyerID", concludedAuction.HiegestBid);
            ViewBag.WinningBidder = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", concludedAuction.WinningBidder);
            return View(concludedAuction);
        }

        // GET: ConcludedAuctions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcludedAuction concludedAuction = await db.ConcludedAuctions.FindAsync(id);
            if (concludedAuction == null)
            {
                return HttpNotFound();
            }
            ViewBag.HiegestBid = new SelectList(db.Bids, "BidID", "BuyerID", concludedAuction.HiegestBid);
            ViewBag.WinningBidder = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", concludedAuction.WinningBidder);
            return View(concludedAuction);
        }

        // POST: ConcludedAuctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PropertyID,HiegestBid,WinningBidder,TimeOfConclution,ExceededReserve")] ConcludedAuction concludedAuction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concludedAuction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HiegestBid = new SelectList(db.Bids, "BidID", "BuyerID", concludedAuction.HiegestBid);
            ViewBag.WinningBidder = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", concludedAuction.WinningBidder);
            return View(concludedAuction);
        }

        // GET: ConcludedAuctions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcludedAuction concludedAuction = await db.ConcludedAuctions.FindAsync(id);
            if (concludedAuction == null)
            {
                return HttpNotFound();
            }
            return View(concludedAuction);
        }

        // POST: ConcludedAuctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ConcludedAuction concludedAuction = await db.ConcludedAuctions.FindAsync(id);
            db.ConcludedAuctions.Remove(concludedAuction);
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
