using Auction_Prop_API.Models.DataBaseModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class BuyerAddressesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: BuyerAddresses
        public ActionResult Index()
        {
            var buyerAddresses = db.BuyerAddresses.Include(b => b.Address).Include(b => b.RegisteredBuyer);
            return View((object)buyerAddresses.ToList());
        }

        // GET: BuyerAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerAddress buyerAddress = db.BuyerAddresses.Find(id);
            if (buyerAddress == null)
            {
                return HttpNotFound();
            }
            return View((object)buyerAddress);
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
        public ActionResult Create([Bind(Include = "id,AddressID,UserID")] BuyerAddress buyerAddress)
        {
            if (ModelState.IsValid)
            {
                db.BuyerAddresses.Add(buyerAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", buyerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", buyerAddress.UserID);
            return View((object)buyerAddress);
        }

        // GET: BuyerAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerAddress buyerAddress = db.BuyerAddresses.Find(id);
            if (buyerAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", buyerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", buyerAddress.UserID);
            return View((object)buyerAddress);
        }

        // POST: BuyerAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,AddressID,UserID")] BuyerAddress buyerAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyerAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", buyerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", buyerAddress.UserID);
            return View((object)buyerAddress);
        }

        // GET: BuyerAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyerAddress buyerAddress = db.BuyerAddresses.Find(id);
            if (buyerAddress == null)
            {
                return HttpNotFound();
            }
            return View((object)buyerAddress);
        }

        // POST: BuyerAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyerAddress buyerAddress = db.BuyerAddresses.Find(id);
            db.BuyerAddresses.Remove(buyerAddress);
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
