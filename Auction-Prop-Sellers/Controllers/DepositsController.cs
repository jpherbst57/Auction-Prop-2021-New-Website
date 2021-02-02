using Auction_Prop_API.Models.DataBaseModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class DepositsController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Deposits
        public ActionResult Index()
        {
            var deposits = db.Deposits.Include(d => d.RegisteredBuyer);
            return View((object)deposits.ToList());
        }

        // GET: Deposits/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposit deposit = db.Deposits.Find(id);
            if (deposit == null)
            {
                return HttpNotFound();
            }
            return View((object)deposit);
        }

        // GET: Deposits/Create
        public ActionResult Create()
        {
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName");
            return View();
        }

        // POST: Deposits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuyerID,DateOfPayment,Paid,DepositReturned,ProofOfPaymentPath,ProofOfReturnPayment,Amount")] Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                db.Deposits.Add(deposit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", deposit.BuyerID);
            return View((object)deposit);
        }

        // GET: Deposits/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposit deposit = db.Deposits.Find(id);
            if (deposit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", deposit.BuyerID);
            return View((object)deposit);
        }

        // POST: Deposits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuyerID,DateOfPayment,Paid,DepositReturned,ProofOfPaymentPath,ProofOfReturnPayment,Amount")] Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deposit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", deposit.BuyerID);
            return View((object)deposit);
        }

        // GET: Deposits/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deposit deposit = db.Deposits.Find(id);
            if (deposit == null)
            {
                return HttpNotFound();
            }
            return View((object)deposit);
        }

        // POST: Deposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Deposit deposit = db.Deposits.Find(id);
            db.Deposits.Remove(deposit);
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
