using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction_Prop_API.Models;

namespace Auction_Prop_API.Controllers.AccountController
{
    public class UserInfoViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserInfoViewModels
        public async Task<ActionResult> Index()
        {
            return View(await db.UserInfoViewModels.ToListAsync());
        }

        // GET: UserInfoViewModels/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfoViewModel userInfoViewModel = await db.UserInfoViewModels.FindAsync(id);
            if (userInfoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userInfoViewModel);
        }

        // GET: UserInfoViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfoViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Email,HasRegistered,LoginProvider")] UserInfoViewModel userInfoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.UserInfoViewModels.Add(userInfoViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userInfoViewModel);
        }

        // GET: UserInfoViewModels/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfoViewModel userInfoViewModel = await db.UserInfoViewModels.FindAsync(id);
            if (userInfoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userInfoViewModel);
        }

        // POST: UserInfoViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Email,HasRegistered,LoginProvider")] UserInfoViewModel userInfoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfoViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userInfoViewModel);
        }

        // GET: UserInfoViewModels/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfoViewModel userInfoViewModel = await db.UserInfoViewModels.FindAsync(id);
            if (userInfoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userInfoViewModel);
        }

        // POST: UserInfoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            UserInfoViewModel userInfoViewModel = await db.UserInfoViewModels.FindAsync(id);
            db.UserInfoViewModels.Remove(userInfoViewModel);
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
