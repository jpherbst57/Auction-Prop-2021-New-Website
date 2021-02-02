using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_Sellers.Controllers
{
    public class PropertiesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Properties
        public async Task<ActionResult> Index()
        {
            var properties = db.Properties.Include(p => p.Auction).Include(p => p.ConcludedAuction).Include(p => p.Seller);
            return View((object)await properties.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = await db.Properties.FindAsync(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View((object)property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID");
            ViewBag.PropertyID = new SelectList(db.ConcludedAuctions, "PropertyID", "WinningBidder");
            ViewBag.SellerID = new SelectList(db.Sellers, "UserID", "FirtstName");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PropertyID,SellerID,Title,Country,Province,City,Address,Description,RegistrationType,PropertyType,BedRooms,BathRooms,FloorSize,YardSize,Garages,OpeningBid,Reserve,PlansPath,TaxesAndRate,levies,TaxesAndRates,TitleDeedPath,HOARules,ApprovalStatus,SellerSigniture,Garden,Terrace,Gerages,SwimmingPool,Fibre,Clubhouse,Braai,OutdoorKitchen,FireplacePit,TennisCourts,Jacquizzi,Parking,Borehole,MandateType,MandateSingedDate,MandateExpireDate")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID", property.PropertyID);
            ViewBag.PropertyID = new SelectList(db.ConcludedAuctions, "PropertyID", "WinningBidder", property.PropertyID);
            ViewBag.SellerID = new SelectList(db.Sellers, "UserID", "FirtstName", property.SellerID);
            return View((object)property);
        }

        // GET: Properties/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = await db.Properties.FindAsync(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID", property.PropertyID);
            ViewBag.PropertyID = new SelectList(db.ConcludedAuctions, "PropertyID", "WinningBidder", property.PropertyID);
            ViewBag.SellerID = new SelectList(db.Sellers, "UserID", "FirtstName", property.SellerID);
            return View((object)property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PropertyID,SellerID,Title,Country,Province,City,Address,Description,RegistrationType,PropertyType,BedRooms,BathRooms,FloorSize,YardSize,Garages,OpeningBid,Reserve,PlansPath,TaxesAndRate,levies,TaxesAndRates,TitleDeedPath,HOARules,ApprovalStatus,SellerSigniture,Garden,Terrace,Gerages,SwimmingPool,Fibre,Clubhouse,Braai,OutdoorKitchen,FireplacePit,TennisCourts,Jacquizzi,Parking,Borehole,MandateType,MandateSingedDate,MandateExpireDate")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID", property.PropertyID);
            ViewBag.PropertyID = new SelectList(db.ConcludedAuctions, "PropertyID", "WinningBidder", property.PropertyID);
            ViewBag.SellerID = new SelectList(db.Sellers, "UserID", "FirtstName", property.SellerID);
            return View((object)property);
        }

        // GET: Properties/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = await db.Properties.FindAsync(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View((object)property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Property property = await db.Properties.FindAsync(id);
            db.Properties.Remove(property);
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
