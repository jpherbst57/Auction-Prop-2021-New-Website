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
    public class BuyerAddressesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: BuyerAddresses
        public async Task<ActionResult> Index()
        {
            var buyerAddresses = db.BuyerAddresses.Include(b => b.Address).Include(b => b.RegisteredBuyer);
            return View(await buyerAddresses.ToListAsync());
        }

        // GET: BuyerAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerAddress buyerAddress = await db.BuyerAddresses.FindAsync(id);
            if (buyerAddress == null)
            {
                return HttpNotFound();
            }
            return View(buyerAddress);
        }

        // GET: BuyerAddresses/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country");
            ViewBag.UserID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName");
            return View();
        }

        // POST: BuyerAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,AddressID,UserID")] BuyerAddress buyerAddress)
        {
            if (ModelState.IsValid)
            {
                db.BuyerAddresses.Add(buyerAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", buyerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", buyerAddress.UserID);
            return View(buyerAddress);
        }

        // GET: BuyerAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerAddress buyerAddress = await db.BuyerAddresses.FindAsync(id);
            if (buyerAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", buyerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", buyerAddress.UserID);
            return View(buyerAddress);
        }

        // POST: BuyerAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,AddressID,UserID")] BuyerAddress buyerAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyerAddress).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", buyerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", buyerAddress.UserID);
            return View(buyerAddress);
        }

        // GET: BuyerAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerAddress buyerAddress = await db.BuyerAddresses.FindAsync(id);
            if (buyerAddress == null)
            {
                return HttpNotFound();
            }
            return View(buyerAddress);
        }

        // POST: BuyerAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BuyerAddress buyerAddress = await db.BuyerAddresses.FindAsync(id);
            db.BuyerAddresses.Remove(buyerAddress);
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
