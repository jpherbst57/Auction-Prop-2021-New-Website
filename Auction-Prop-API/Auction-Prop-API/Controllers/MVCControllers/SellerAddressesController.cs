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
    public class SellerAddressesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: SellerAddresses
        public async Task<ActionResult> Index()
        {
            var sellerAddresses = db.SellerAddresses.Include(s => s.Address).Include(s => s.Seller);
            return View(await sellerAddresses.ToListAsync());
        }

        // GET: SellerAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerAddress sellerAddress = await db.SellerAddresses.FindAsync(id);
            if (sellerAddress == null)
            {
                return HttpNotFound();
            }
            return View(sellerAddress);
        }

        // GET: SellerAddresses/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country");
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName");
            return View();
        }

        // POST: SellerAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,AddressID,UserID")] SellerAddress sellerAddress)
        {
            if (ModelState.IsValid)
            {
                db.SellerAddresses.Add(sellerAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", sellerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", sellerAddress.UserID);
            return View(sellerAddress);
        }

        // GET: SellerAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerAddress sellerAddress = await db.SellerAddresses.FindAsync(id);
            if (sellerAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", sellerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", sellerAddress.UserID);
            return View(sellerAddress);
        }

        // POST: SellerAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,AddressID,UserID")] SellerAddress sellerAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellerAddress).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", sellerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", sellerAddress.UserID);
            return View(sellerAddress);
        }

        // GET: SellerAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerAddress sellerAddress = await db.SellerAddresses.FindAsync(id);
            if (sellerAddress == null)
            {
                return HttpNotFound();
            }
            return View(sellerAddress);
        }

        // POST: SellerAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SellerAddress sellerAddress = await db.SellerAddresses.FindAsync(id);
            db.SellerAddresses.Remove(sellerAddress);
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
