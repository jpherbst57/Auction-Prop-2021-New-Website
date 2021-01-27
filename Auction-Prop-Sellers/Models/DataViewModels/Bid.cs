using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        public Bid()
        {
            ConcludedAuctions = new HashSet<ConcludedAuction>();
        }

        public int BidID { get; set; }

        [Required]
        [StringLength(128)]
        public string BuyerID { get; set; }

        public int PropertyID { get; set; }

        public decimal AmuntOfBid { get; set; }

        public DateTime TimeOfbid { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }

        public virtual ICollection<ConcludedAuction> ConcludedAuctions { get; set; }
    }
}