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
    public class PropertiesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Properties
        public async Task<ActionResult> Index()
        {
            var properties = db.Properties.Include(p => p.Auction).Include(p => p.Seller);
            return View(await properties.ToListAsync());
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
            return View(property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID");
            ViewBag.SellerID = new SelectList(db.Sellers, "UserID", "FirtstName");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PropertyID,SellerID,Title,Country,Province,City,Address,Description,Type,Status,BedRooms,BathRooms,BuildingArea,TerraceArea,Garages,PrpertyValue,MinimubBid,Reserve,PlansPath,TaxesAndRates,TitleDeedPath,Location,ApprovalStatus,SellerSigniture,A_C,PetsAllowed,Garden,CableTV,Terrace,wi_fi,Fibre,Pool,Balcony,Parquet,Beach,Gerage,RoofTarrace,Sauna,OutdoorKitchen,FireplacePit,SunRoom,ConcreteFlooring,WoodFloring,TennisCourts")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID", property.PropertyID);
            ViewBag.SellerID = new SelectList(db.Sellers, "UserID", "FirtstName", property.SellerID);
            return View(property);
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
            ViewBag.SellerID = new SelectList(db.Sellers, "UserID", "FirtstName", property.SellerID);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PropertyID,SellerID,Title,Country,Province,City,Address,Description,Type,Status,BedRooms,BathRooms,BuildingArea,TerraceArea,Garages,PrpertyValue,MinimubBid,Reserve,PlansPath,TaxesAndRates,TitleDeedPath,Location,ApprovalStatus,SellerSigniture,A_C,PetsAllowed,Garden,CableTV,Terrace,wi_fi,Fibre,Pool,Balcony,Parquet,Beach,Gerage,RoofTarrace,Sauna,OutdoorKitchen,FireplacePit,SunRoom,ConcreteFlooring,WoodFloring,TennisCourts")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Auctions, "PropertyID", "PropertyID", property.PropertyID);
            ViewBag.SellerID = new SelectList(db.Sellers, "UserID", "FirtstName", property.SellerID);
            return View(property);
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
            return View(property);
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
