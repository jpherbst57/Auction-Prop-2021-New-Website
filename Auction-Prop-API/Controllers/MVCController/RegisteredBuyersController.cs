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
    public class RegisteredBuyersController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: RegisteredBuyers
        public async Task<ActionResult> Index()
        {
            var registeredBuyers = db.RegisteredBuyers.Include(r => r.Deposit);
            return View(await registeredBuyers.ToListAsync());
        }

        // GET: RegisteredBuyers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredBuyer registeredBuyer = await db.RegisteredBuyers.FindAsync(id);
            if (registeredBuyer == null)
            {
                return HttpNotFound();
            }
            return View(registeredBuyer);
        }

        // GET: RegisteredBuyers/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Deposits, "BuyerID", "ProofOfPaymentPath");
            return View();
        }

        // POST: RegisteredBuyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,FirstName,LastName,IDNumber,DateOfBirth,ProfilePhotoPath,ProofOfResidencePath,CopyOfIDPath,ProofOfBankAccount,IDBuyerVerifyPhoto,ApprovalStatus,RegistrationDate,Signiture")] RegisteredBuyer registeredBuyer)
        {
            if (ModelState.IsValid)
            {
                db.RegisteredBuyers.Add(registeredBuyer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Deposits, "BuyerID", "ProofOfPaymentPath", registeredBuyer.UserId);
            return View(registeredBuyer);
        }

        // GET: RegisteredBuyers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredBuyer registeredBuyer = await db.RegisteredBuyers.FindAsync(id);
            if (registeredBuyer == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Deposits, "BuyerID", "ProofOfPaymentPath", registeredBuyer.UserId);
            return View(registeredBuyer);
        }

        // POST: RegisteredBuyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,FirstName,LastName,IDNumber,DateOfBirth,ProfilePhotoPath,ProofOfResidencePath,CopyOfIDPath,ProofOfBankAccount,IDBuyerVerifyPhoto,ApprovalStatus,RegistrationDate,Signiture")] RegisteredBuyer registeredBuyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registeredBuyer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Deposits, "BuyerID", "ProofOfPaymentPath", registeredBuyer.UserId);
            return View(registeredBuyer);
        }

        // GET: RegisteredBuyers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredBuyer registeredBuyer = await db.RegisteredBuyers.FindAsync(id);
            if (registeredBuyer == null)
            {
                return HttpNotFound();
            }
            return View(registeredBuyer);
        }

        // POST: RegisteredBuyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            RegisteredBuyer registeredBuyer = await db.RegisteredBuyers.FindAsync(id);
            db.RegisteredBuyers.Remove(registeredBuyer);
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
