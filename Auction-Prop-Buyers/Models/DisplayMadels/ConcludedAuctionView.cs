using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class ConcludedAuctionView
    {
    }


    public partial class ConcludedAuction
    {
        public int PropertyID { get; set; }

        public int HiegestBid { get; set; }

        public string WinningBidder { get; set; }

        public DateTime? TimeOfConclution { get; set; }

        public bool? ExceededReserve { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }

        public virtual Property Property { get; set; }
    }
}