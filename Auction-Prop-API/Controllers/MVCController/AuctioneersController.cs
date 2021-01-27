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

namespace Auction_Prop_API.Controllers.MVCController
{
    public class AuctioneersController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Auctioneers
        public async Task<ActionResult> Index()
        {
            var auctioneers = db.Auctioneers.Include(a => a.Seller);
            return View(await auctioneers.ToListAsync());
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
            return View(auctioneer);
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
            return View(auctioneer);
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
            return View(auctioneer);
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
            return View(auctioneer);
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
            return View(auctioneer);
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
