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
    public class AuctionRegistrationsController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: AuctionRegistrations
        public async Task<ActionResult> Index()
        {
            var auctionRegistrations = db.AuctionRegistrations.Include(a => a.AdminFee).Include(a => a.Property).Include(a => a.RegisteredBuyer);
            return View(await auctionRegistrations.ToListAsync());
        }

        // GET: AuctionRegistrations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionRegistration auctionRegistration = await db.AuctionRegistrations.FindAsync(id);
            if (auctionRegistration == null)
            {
                return HttpNotFound();
            }
            return View(auctionRegistration);
        }

        // GET: AuctionRegistrations/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.AdminFees, "PaymentID", "ProofOfPaymentPath");
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID");
            ViewBag.BuyerId = new SelectList(db.RegisteredBuyers, "UserId", "FirstName");
            return View();
        }

        // POST: AuctionRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,BuyerId,PropertyID,RegistrationFees,RegesterDate,Signiture,RegistrationStatus")] AuctionRegistration auctionRegistration)
        {
            if (ModelState.IsValid)
            {
                db.AuctionRegistrations.Add(auctionRegistration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.AdminFees, "PaymentID", "ProofOfPaymentPath", auctionRegistration.id);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", auctionRegistration.PropertyID);
            ViewBag.BuyerId = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", auctionRegistration.BuyerId);
            return View(auctionRegistration);
        }

        // GET: AuctionRegistrations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionRegistration auctionRegistration = await db.AuctionRegistrations.FindAsync(id);
            if (auctionRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.AdminFees, "PaymentID", "ProofOfPaymentPath", auctionRegistration.id);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", auctionRegistration.PropertyID);
            ViewBag.BuyerId = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", auctionRegistration.BuyerId);
            return View(auctionRegistration);
        }

        // POST: AuctionRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,BuyerId,PropertyID,RegistrationFees,RegesterDate,Signiture,RegistrationStatus")] AuctionRegistration auctionRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auctionRegistration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.AdminFees, "PaymentID", "ProofOfPaymentPath", auctionRegistration.id);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", auctionRegistration.PropertyID);
            ViewBag.BuyerId = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", auctionRegistration.BuyerId);
            return View(auctionRegistration);
        }

        // GET: AuctionRegistrations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionRegistration auctionRegistration = await db.AuctionRegistrations.FindAsync(id);
            if (auctionRegistration == null)
            {
                return HttpNotFound();
            }
            return View(auctionRegistration);
        }

        // POST: AuctionRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AuctionRegistration auctionRegistration = await db.AuctionRegistrations.FindAsync(id);
            db.AuctionRegistrations.Remove(auctionRegistration);
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
