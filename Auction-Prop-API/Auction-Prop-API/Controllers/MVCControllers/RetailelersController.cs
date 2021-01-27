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
    public class RetailelersController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Retailelers
        public async Task<ActionResult> Index()
        {
            var retailelers = db.Retailelers.Include(r => r.Seller);
            return View(await retailelers.ToListAsync());
        }

        // GET: Retailelers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retaileler retaileler = await db.Retailelers.FindAsync(id);
            if (retaileler == null)
            {
                return HttpNotFound();
            }
            return View(retaileler);
        }

        // GET: Retailelers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName");
            return View();
        }

        // POST: Retailelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,RetailerName,CompanyContactNumber,CompanyEmail,ProfilePhotoPath,ProofOfResedence,Signature,CompanyDescription")] Retaileler retaileler)
        {
            if (ModelState.IsValid)
            {
                db.Retailelers.Add(retaileler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", retaileler.UserID);
            return View(retaileler);
        }

        // GET: Retailelers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retaileler retaileler = await db.Retailelers.FindAsync(id);
            if (retaileler == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", retaileler.UserID);
            return View(retaileler);
        }

        // POST: Retailelers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserID,RetailerName,CompanyContactNumber,CompanyEmail,ProfilePhotoPath,ProofOfResedence,Signature,CompanyDescription")] Retaileler retaileler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retaileler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", retaileler.UserID);
            return View(retaileler);
        }

        // GET: Retailelers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retaileler retaileler = await db.Retailelers.FindAsync(id);
            if (retaileler == null)
            {
                return HttpNotFound();
            }
            return View(retaileler);
        }

        // POST: Retailelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Retaileler retaileler = await db.Retailelers.FindAsync(id);
            db.Retailelers.Remove(retaileler);
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
