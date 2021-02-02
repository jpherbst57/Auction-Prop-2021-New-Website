using Auction_Prop_API.Models.DataBaseModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class SellerAddressesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: SellerAddresses
        public ActionResult Index()
        {
            var sellerAddresses = db.SellerAddresses.Include(s => s.Address).Include(s => s.Seller);
            return View((object)sellerAddresses.ToList());
        }

        // GET: SellerAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerAddress sellerAddress = db.SellerAddresses.Find(id);
            if (sellerAddress == null)
            {
                return HttpNotFound();
            }
            return View((object)sellerAddress);
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
        public ActionResult Create([Bind(Include = "id,AddressID,UserID")] SellerAddress sellerAddress)
        {
            if (ModelState.IsValid)
            {
                db.SellerAddresses.Add(sellerAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", sellerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", sellerAddress.UserID);
            return View((object)sellerAddress);
        }

        // GET: SellerAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerAddress sellerAddress = db.SellerAddresses.Find(id);
            if (sellerAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", sellerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", sellerAddress.UserID);
            return View((object)sellerAddress);
        }

        // POST: SellerAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,AddressID,UserID")] SellerAddress sellerAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellerAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Country", sellerAddress.AddressID);
            ViewBag.UserID = new SelectList(db.Sellers, "UserID", "FirtstName", sellerAddress.UserID);
            return View((object)sellerAddress);
        }

        // GET: SellerAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellerAddress sellerAddress = db.SellerAddresses.Find(id);
            if (sellerAddress == null)
            {
                return HttpNotFound();
            }
            return View((object)sellerAddress);
        }

        // POST: SellerAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellerAddress sellerAddress = db.SellerAddresses.Find(id);
            db.SellerAddresses.Remove(sellerAddress);
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
