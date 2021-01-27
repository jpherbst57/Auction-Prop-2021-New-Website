namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdminFee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentID { get; set; }

        [StringLength(500)]
        public string ProofOfPaymentPath { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfPayment { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public virtual AuctionRegistration AuctionRegistration { get; set; }
    }
    public partial class AdminFeeNoR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentID { get; set; }

        [StringLength(500)]
        public string ProofOfPaymentPath { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfPayment { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public virtual AuctionRegistrationNoR AuctionRegistration { get; set; }

    }
}
