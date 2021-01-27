namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
    public partial class DepositNoR
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

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

    }
}
