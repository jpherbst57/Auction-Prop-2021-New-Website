using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class DepesitsViewModel
    {
    }
    public partial class Deposit
    {
        [Key]
        public string BuyerID { get; set; }

        public DateTime DateOfPayment { get; set; }

        public bool Paid { get; set; }

        public bool DepositReturned { get; set; }

        [StringLength(500)]
        public string ProofOfPaymentPath { get; set; }

        [StringLength(500)]
        public string ProofOfReturnPayment { get; set; }

        public decimal? Amount { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
}