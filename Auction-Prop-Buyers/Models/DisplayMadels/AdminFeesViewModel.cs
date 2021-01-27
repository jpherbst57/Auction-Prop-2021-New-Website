using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class AdminFeesViewModel
    {
    }
    public partial class AdminFee
    {
        [Key]
        public int PaymentID { get; set; }

        [StringLength(500)]
        public string ProofOfPaymentPath { get; set; }

        public DateTime? DateOfPayment { get; set; }

        public decimal? Amount { get; set; }


        public virtual AuctionRegistration AuctionRegistration { get; set; }
    }
}