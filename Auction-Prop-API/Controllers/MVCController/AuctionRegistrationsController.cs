using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers.MVCController
{
    public class AuctionRegistrationsController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: AuctionRegistrations
        public ActionResult Index()
        {
            var auctionRegistrations = db.AuctionRegistrations.Include(a => a.AdminFee).Include(a => a.BankApproval).Include(a => a.Guarintee).Include(a => a.Property).Include(a => a.RegisteredBuyer);
            return View(auctionRegistrations.ToList());
        }

        // GET: AuctionRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionRegistration auctionRegistration = db.AuctionRegistrations.Find(id);
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
            ViewBag.id = new SelectList(db.BankApprovals, "AuctionRegistrationID", "ApprovalPath");
            ViewBag.id = new SelectList(db.Guarintees, "AuctionRegistrationID", "GuarinteePath");
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID");
            ViewBag.BuyerId = new SelectList(db.RegisteredBuyers, "UserId", "FirstName");
            return View();
        }

        // POST: AuctionRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,BuyerId,PropertyID,RegistrationFees,RegesterDate,Signiture,RegistrationStatus,Bonded")] AuctionRegistration auctionRegistration)
        {
            if (ModelState.IsValid)
            {
                db.AuctionRegistrations.Add(auctionRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.AdminFees, "PaymentID", "ProofOfPaymentPath", auctionRegistration.id);
            ViewBag.id = new SelectList(db.BankApprovals, "AuctionRegistrationID", "ApprovalPath", auctionRegistration.id);
            ViewBag.id = new SelectList(db.Guarintees, "AuctionRegistrationID", "GuarinteePath", auctionRegistration.id);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", auctionRegistration.PropertyID);
            ViewBag.BuyerId = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", auctionRegistration.BuyerId);
            return View(auctionRegistration);
        }

        // GET: AuctionRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionRegistration auctionRegistration = db.AuctionRegistrations.Find(id);
            if (auctionRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.AdminFees, "PaymentID", "ProofOfPaymentPath", auctionRegistration.id);
            ViewBag.id = new SelectList(db.BankApprovals, "AuctionRegistrationID", "ApprovalPath", auctionRegistration.id);
            ViewBag.id = new SelectList(db.Guarintees, "AuctionRegistrationID", "GuarinteePath", auctionRegistration.id);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", auctionRegistration.PropertyID);
            ViewBag.BuyerId = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", auctionRegistration.BuyerId);
            return View(auctionRegistration);
        }

        // POST: AuctionRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,BuyerId,PropertyID,RegistrationFees,RegesterDate,Signiture,RegistrationStatus,Bonded")] AuctionRegistration auctionRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auctionRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.AdminFees, "PaymentID", "ProofOfPaymentPath", auctionRegistration.id);
            ViewBag.id = new SelectList(db.BankApprovals, "AuctionRegistrationID", "ApprovalPath", auctionRegistration.id);
            ViewBag.id = new SelectList(db.Guarintees, "AuctionRegistrationID", "GuarinteePath", auctionRegistration.id);
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "SellerID", auctionRegistration.PropertyID);
            ViewBag.BuyerId = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", auctionRegistration.BuyerId);
            return View(auctionRegistration);
        }

        // GET: AuctionRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionRegistration auctionRegistration = db.AuctionRegistrations.Find(id);
            if (auctionRegistration == null)
            {
                return HttpNotFound();
            }
            return View(auctionRegistration);
        }

        // POST: AuctionRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuctionRegistration auctionRegistration = db.AuctionRegistrations.Find(id);
            db.AuctionRegistrations.Remove(auctionRegistration);
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
