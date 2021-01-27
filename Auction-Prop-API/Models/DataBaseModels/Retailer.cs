namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Retailer
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string RetailerName { get; set; }

        [StringLength(40)]
        public string Branch { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        [StringLength(128)]
        public string CompanyEmail { get; set; }

        [StringLength(500)]
        public string CompaynLogoPath { get; set; }

        public bool Signature { get; set; }

        [StringLength(500)]
        public string CompanyDescription { get; set; }

        public virtual Seller Seller { get; set; }
    }
    public partial class RetailerNoR
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string RetailerName { get; set; }

        [StringLength(40)]
        public string Branch { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        [StringLength(128)]
        public string CompanyEmail { get; set; }

        [StringLength(500)]
        public string CompaynLogoPath { get; set; }

        public bool Signature { get; set; }

        [StringLength(500)]
        public string CompanyDescription { get; set; }


        public virtual SellerNoR Seller { get; set; }
    }
}
