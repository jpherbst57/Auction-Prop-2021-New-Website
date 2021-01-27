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
    public class BankApprovalsController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: BankApprovals
        public ActionResult Index()
        {
            var bankApprovals = db.BankApprovals.Include(b => b.AuctionRegistration);
            return View(bankApprovals.ToList());
        }

        // GET: BankApprovals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankApproval bankApproval = db.BankApprovals.Find(id);
            if (bankApproval == null)
            {
                return HttpNotFound();
            }
            return View(bankApproval);
        }

        // GET: BankApprovals/Create
        public ActionResult Create()
        {
            ViewBag.AuctionRegistrationID = new SelectList(db.AuctionRegistrations, "id", "BuyerId");
            return View();
        }

        // POST: BankApprovals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuctionRegistrationID,ApprovalPath,BankApprovalApprovalstatus,DateOfSubmision")] BankApproval bankApproval)
        {
            if (ModelState.IsValid)
            {
                db.BankApprovals.Add(bankApproval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionRegistrationID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", bankApproval.AuctionRegistrationID);
            return View(bankApproval);
        }

        // GET: BankApprovals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankApproval bankApproval = db.BankApprovals.Find(id);
            if (bankApproval == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionRegistrationID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", bankApproval.AuctionRegistrationID);
            return View(bankApproval);
        }

        // POST: BankApprovals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuctionRegistrationID,ApprovalPath,BankApprovalApprovalstatus,DateOfSubmision")] BankApproval bankApproval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankApproval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionRegistrationID = new SelectList(db.AuctionRegistrations, "id", "BuyerId", bankApproval.AuctionRegistrationID);
            return View(bankApproval);
        }

        // GET: BankApprovals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankApproval bankApproval = db.BankApprovals.Find(id);
            if (bankApproval == null)
            {
                return HttpNotFound();
            }
            return View(bankApproval);
        }

        // POST: BankApprovals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankApproval bankApproval = db.BankApprovals.Find(id);
            db.BankApprovals.Remove(bankApproval);
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
