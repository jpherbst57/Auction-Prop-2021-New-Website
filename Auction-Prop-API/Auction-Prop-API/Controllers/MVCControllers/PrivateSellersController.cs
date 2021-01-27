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
    public class PrivateSellersController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: PrivateSellers
        public async Task<ActionResult> Index()
        {
            var privateSellers = db.PrivateSellers.Include(p => p.Seller);
            return View(await privateSellers.ToListAsync());
        }

        // GET: PrivateSellers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = await db.PrivateSellers.FindAsync(id);
            if (privateSeller == null)
            {
                return HttpNotFound();
            }
            return View(privateSeller);
        }

        // GET: PrivateSellers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName");
            return View();
        }

        // POST: PrivateSellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,IDNumber,ProfilePhotoPath,ProofOfResedence,Signiture")] PrivateSeller privateSeller)
        {
            if (ModelState.IsValid)
            {
                db.PrivateSellers.Add(privateSeller);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", privateSeller.UserID);
            return View(privateSeller);
        }

        // GET: PrivateSellers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = await db.PrivateSellers.FindAsync(id);
            if (privateSeller == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", privateSeller.UserID);
            return View(privateSeller);
        }

        // POST: PrivateSellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserID,IDNumber,ProfilePhotoPath,ProofOfResedence,Signiture")] PrivateSeller privateSeller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privateSeller).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", privateSeller.UserID);
            return View(privateSeller);
        }

        // GET: PrivateSellers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = await db.PrivateSellers.FindAsync(id);
            if (privateSeller == null)
            {
                return HttpNotFound();
            }
            return View(privateSeller);
        }

        // POST: PrivateSellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PrivateSeller privateSeller = await db.PrivateSellers.FindAsync(id);
            db.PrivateSellers.Remove(privateSeller);
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
