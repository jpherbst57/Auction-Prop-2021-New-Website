namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Auctioneer")]
    public partial class Auctioneer
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string CompanyName { get; set; }

        [StringLength(40)]
        public string Branch { get; set; }

        [StringLength(128)]
        public string CompanyLogo { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        [StringLength(228)]
        public string CompanyEmail { get; set; }

        public bool Signature { get; set; }

        [StringLength(500)]
        public string CompanyDescriprion { get; set; }

        public virtual Seller Seller { get; set; }
    }

    [Table("Auctioneer")]
    public partial class AuctioneerNoR
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string CompanyName { get; set; }

        [StringLength(40)]
        public string Branch { get; set; }

        [StringLength(128)]
        public string CompanyLogo { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        [StringLength(228)]
        public string CompanyEmail { get; set; }

        public bool Signature { get; set; }

        [StringLength(500)]
        public string CompanyDescriprion { get; set; }

        public virtual SellerNoR Seller { get; set; }

    }
}
