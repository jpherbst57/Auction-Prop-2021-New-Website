namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConcludedAuction
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyID { get; set; }

        public int HiegestBid { get; set; }

        [Required]
        [StringLength(128)]
        public string WinningBidder { get; set; }

        public DateTime TimeOfConclution { get; set; }

        public bool ExceededReserve { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual Property Property { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
    public partial class ConcludedAuctionNoR
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyID { get; set; }

        public int HiegestBid { get; set; }

        [Required]
        [StringLength(128)]
        public string WinningBidder { get; set; }

        public DateTime TimeOfConclution { get; set; }

        public bool ExceededReserve { get; set; }



        public virtual BidNoR Bid { get; set; }

        public virtual PropertyNoR Property { get; set; }

        public virtual RegisteredBuyerNoR RegisteredBuyer { get; set; }
    }
}
