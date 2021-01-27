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
    public class BidsController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Bids
        public async Task<ActionResult> Index()
        {
            var bids = db.Bids.Include(b => b.Auction).Include(b => b.RegisteredBuyer);
            return View(await bids.ToListAsync());
        }

        // GET: Bids/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // GET: Bids/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID");
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BidID,BuyerID,PropertyID,AmuntOfBid,TimeOfbid")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID", bid.PropertyID);
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", bid.BuyerID);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID", bid.PropertyID);
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", bid.BuyerID);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BidID,BuyerID,PropertyID,AmuntOfBid,TimeOfbid")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bid).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID", bid.PropertyID);
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", bid.BuyerID);
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bid bid = await db.Bids.FindAsync(id);
            db.Bids.Remove(bid);
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
