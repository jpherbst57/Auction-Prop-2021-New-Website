namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuctionRegistration")]
    public partial class AuctionRegistration
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string BuyerId { get; set; }

        public int PropertyID { get; set; }

        public bool RegistrationFees { get; set; }

        public DateTime RegesterDate { get; set; }

        public bool Signiture { get; set; }

        public bool RegistrationStatus { get; set; }

        public bool Bonded { get; set; }

        public virtual AdminFee AdminFee { get; set; }

        public virtual Property Property { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }

        public virtual BankApproval BankApproval { get; set; }

        public virtual Guarintee Guarintee { get; set; }
    }
    [Table("AuctionRegistration")]
    public partial class AuctionRegistrationNoR
    {
        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string BuyerId { get; set; }

        public int PropertyID { get; set; }

        public bool RegistrationFees { get; set; }

        public DateTime RegesterDate { get; set; }

        public bool Signiture { get; set; }

        public bool RegistrationStatus { get; set; }

        public bool Bonded { get; set; }


        public virtual AdminFeeNoR AdminFee { get; set; }

        public virtual PropertyNoR Property { get; set; }

        public virtual RegisteredBuyerNoR RegisteredBuyer { get; set; }

        public virtual BankApprovalNoR BankApproval { get; set; }

        public virtual GuarinteeNoR Guarintee { get; set; }
    }
}
