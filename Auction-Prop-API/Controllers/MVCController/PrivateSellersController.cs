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
    public class PrivateSellersController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: PrivateSellers
        public ActionResult Index()
        {
            var privateSellers = db.PrivateSellers.Include(p => p.Seller);
            return View(privateSellers.ToList());
        }

        // GET: PrivateSellers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = db.PrivateSellers.Find(id);
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
        public ActionResult Create([Bind(Include = "UserID,IDNumber,ProofOfResedence,Signiture")] PrivateSeller privateSeller)
        {
            if (ModelState.IsValid)
            {
                db.PrivateSellers.Add(privateSeller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", privateSeller.UserID);
            return View(privateSeller);
        }

        // GET: PrivateSellers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = db.PrivateSellers.Find(id);
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
        public ActionResult Edit([Bind(Include = "UserID,IDNumber,ProofOfResedence,Signiture")] PrivateSeller privateSeller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privateSeller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", privateSeller.UserID);
            return View(privateSeller);
        }

        // GET: PrivateSellers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivateSeller privateSeller = db.PrivateSellers.Find(id);
            if (privateSeller == null)
            {
                return HttpNotFound();
            }
            return View(privateSeller);
        }

        // POST: PrivateSellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PrivateSeller privateSeller = db.PrivateSellers.Find(id);
            db.PrivateSellers.Remove(privateSeller);
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
