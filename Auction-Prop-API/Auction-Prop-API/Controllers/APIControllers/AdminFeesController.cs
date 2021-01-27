﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers.APIControllers
{
    public class AdminFeesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/AdminFees
        public IQueryable<AdminFee> GetAdminFees()
        {
            return db.AdminFees;
        }

        // GET: api/AdminFees/5
        [ResponseType(typeof(AdminFee))]
        public async Task<IHttpActionResult> GetAdminFee(int id)
        {
            AdminFee adminFee = await db.AdminFees.FindAsync(id);
            if (adminFee == null)
            {
                return NotFound();
            }

            return Ok(adminFee);
        }

        // PUT: api/AdminFees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdminFee(int id, AdminFee adminFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminFee.PaymentID)
            {
                return BadRequest();
            }

            db.Entry(adminFee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminFeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AdminFees
        [ResponseType(typeof(AdminFee))]
        public async Task<IHttpActionResult> PostAdminFee(AdminFee adminFee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdminFees.Add(adminFee);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminFeeExists(adminFee.PaymentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = adminFee.PaymentID }, adminFee);
        }

        // DELETE: api/AdminFees/5
        [ResponseType(typeof(AdminFee))]
        public async Task<IHttpActionResult> DeleteAdminFee(int id)
        {
            AdminFee adminFee = await db.AdminFees.FindAsync(id);
            if (adminFee == null)
            {
                return NotFound();
            }

            db.AdminFees.Remove(adminFee);
            await db.SaveChangesAsync();

            return Ok(adminFee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminFeeExists(int id)
        {
            return db.AdminFees.Count(e => e.PaymentID == id) > 0;
        }
    }
}