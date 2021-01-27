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
    public class AdminFeesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: AdminFees
        public async Task<ActionResult> Index()
        {
            var adminFees = db.AdminFees.Include(a => a.AuctionRegistration);
            return View(await adminFees.ToListAsync());
        }

        // GET: AdminFees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminFee adminFee = await db.AdminFees.FindAsync(id);
            if (adminFee == null)
            {
                return HttpNotFound();
            }
            return View(adminFee);
        }

        // GET: AdminFees/Create
        public ActionResult Create()
        {
            ViewBag.PaymentID = new SelectList(db.AuctionRegistrations, "id", "BuyerId");
            return View();
        }

        // POST: AdminFees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PaymentID,ProofOfPaymentPath,DateOfPayment,Amount")] AdminFee adminFee)
        {
            if (ModelState.IsValid)
            {
                db.AdminFees.Add(adminFee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PaymentID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", adminFee.PaymentID);
            return View(adminFee);
        }

        // GET: AdminFees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminFee adminFee = await db.AdminFees.FindAsync(id);
            if (adminFee == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaymentID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", adminFee.PaymentID);
            return View(adminFee);
        }

        // POST: AdminFees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PaymentID,ProofOfPaymentPath,DateOfPayment,Amount")] AdminFee adminFee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminFee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PaymentID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", adminFee.PaymentID);
            return View(adminFee);
        }

        // GET: AdminFees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminFee adminFee = await db.AdminFees.FindAsync(id);
            if (adminFee == null)
            {
                return HttpNotFound();
            }
            return View(adminFee);
        }

        // POST: AdminFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AdminFee adminFee = await db.AdminFees.FindAsync(id);
            db.AdminFees.Remove(adminFee);
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
