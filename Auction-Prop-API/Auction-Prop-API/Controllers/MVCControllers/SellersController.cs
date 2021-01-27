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
    public class SellersController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Sellers
        public async Task<ActionResult> Index()
        {
            var sellers = db.Sellers.Include(s => s.PrivateSeller).Include(s => s.Retaileler);
            return View(await sellers.ToListAsync());
        }

        // GET: Sellers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // GET: Sellers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.PrivateSellers, "UserID", "IDNumber");
            ViewBag.UserID = new SelectList(db.Retailelers, "UserID", "RetailerName");
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,FirtstName,LastName,SellerType,Signature,ApprovalStatus")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Sellers.Add(seller);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.PrivateSellers, "UserID", "IDNumber", seller.UserID);
            ViewBag.UserID = new SelectList(db.Retailelers, "UserID", "RetailerName", seller.UserID);
            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.PrivateSellers, "UserID", "IDNumber", seller.UserID);
            ViewBag.UserID = new SelectList(db.Retailelers, "UserID", "RetailerName", seller.UserID);
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserID,FirtstName,LastName,SellerType,Signature,ApprovalStatus")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seller).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.PrivateSellers, "UserID", "IDNumber", seller.UserID);
            ViewBag.UserID = new SelectList(db.Retailelers, "UserID", "RetailerName", seller.UserID);
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Seller seller = await db.Sellers.FindAsync(id);
            db.Sellers.Remove(seller);
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
