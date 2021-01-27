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
    public class PromoVideos1Controller : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: PromoVideos1
        public async Task<ActionResult> Index()
        {
            var promoVideos = db.PromoVideos.Include(p => p.Property);
            return View(await promoVideos.ToListAsync());
        }

        // GET: PromoVideos1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            if (promoVideo == null)
            {
                return HttpNotFound();
            }
            return View(promoVideo);
        }

        // GET: PromoVideos1/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyID");
            return View();
        }

        // POST: PromoVideos1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VideoID,PropertyID,VideoPath")] PromoVideo promoVideo)
        {
            if (ModelState.IsValid)
            {
                db.PromoVideos.Add(promoVideo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyID", promoVideo.PropertyID);
            return View(promoVideo);
        }

        // GET: PromoVideos1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            if (promoVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyID", promoVideo.PropertyID);
            return View(promoVideo);
        }

        // POST: PromoVideos1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VideoID,PropertyID,VideoPath")] PromoVideo promoVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promoVideo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "PropertyID", "PropertyID", promoVideo.PropertyID);
            return View(promoVideo);
        }

        // GET: PromoVideos1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            if (promoVideo == null)
            {
                return HttpNotFound();
            }
            return View(promoVideo);
        }

        // POST: PromoVideos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            db.PromoVideos.Remove(promoVideo);
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
