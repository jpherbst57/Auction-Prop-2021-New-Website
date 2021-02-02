using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers
{
    public class PromoVideosController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/PromoVideos
        public ICollection<PromoVideoNoR> GetPromoVideos()
        {

          

            List<PromoVideoNoR> Lys = new List<PromoVideoNoR>();
            foreach (PromoVideo objct in db.PromoVideos.Include(p => p.Property))
            {


                PromoVideoNoR newObject = new PromoVideoNoR()
                {
                   // Property = objct.Property,
                    //  BankApproval = objct.BankApproval,
                    // Bid = objct.Bid,
                    //  AuctionRegistration = objct.AuctionRegistration,
                    PropertyID = objct.PropertyID,
                    // Property = objct.Property,
                    //  Property = objct.Property,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                    //  Seller = objct.Seller,
                    // RegisteredBuyer = objct.RegisteredBuyer,
                    VideoID = objct.VideoID,
                    VideoPath = objct.VideoPath,
                    // = objct.ProofOfPaymentPath,
                    // ProofOfReturnPayment = objct.ProofOfReturnPayment
                    // AuctionRegistration = fee.AuctionRegistration
                };


                Lys.Add(newObject);
            }

            return Lys;
        }

        // GET: api/PromoVideos/5
        [ResponseType(typeof(PromoVideo))]
        public async Task<IHttpActionResult> GetPromoVideo(int id)
        {
            PromoVideo objct = await db.PromoVideos.FindAsync(id);
            if (objct == null)
            {
                return NotFound();
            }

            PromoVideoNoR newObject = new PromoVideoNoR()
            {
                // Property = objct.Property,
                //  BankApproval = objct.BankApproval,
                // Bid = objct.Bid,
                //  AuctionRegistration = objct.AuctionRegistration,
                PropertyID = objct.PropertyID,
                // Property = objct.Property,
                //  Property = objct.Property,
                // RegisteredBuyer = objct.RegisteredBuyer,
                //  Seller = objct.Seller,
                // RegisteredBuyer = objct.RegisteredBuyer,
                VideoID = objct.VideoID,
                VideoPath = objct.VideoPath,
                // = objct.ProofOfPaymentPath,
                // ProofOfReturnPayment = objct.ProofOfReturnPayment
                // AuctionRegistration = fee.AuctionRegistration
            };

            return Ok(newObject);
        }

        // PUT: api/PromoVideos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPromoVideo(int id, PromoVideo promoVideo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promoVideo.VideoID)
            {
                return BadRequest();
            }

            db.Entry(promoVideo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoVideoExists(id))
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

        // POST: api/PromoVideos
        [ResponseType(typeof(PromoVideo))]
        public async Task<IHttpActionResult> PostPromoVideo(PromoVideo promoVideo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PromoVideos.Add(promoVideo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PromoVideoExists(promoVideo.VideoID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = promoVideo.VideoID }, promoVideo);
        }

        // DELETE: api/PromoVideos/5
        [ResponseType(typeof(PromoVideo))]
        public async Task<IHttpActionResult> DeletePromoVideo(int id)
        {
            PromoVideo promoVideo = await db.PromoVideos.FindAsync(id);
            if (promoVideo == null)
            {
                return NotFound();
            }

            db.PromoVideos.Remove(promoVideo);
            await db.SaveChangesAsync();

            return Ok(promoVideo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromoVideoExists(int id)
        {
            return db.PromoVideos.Count(e => e.VideoID == id) > 0;
        }
    }
}