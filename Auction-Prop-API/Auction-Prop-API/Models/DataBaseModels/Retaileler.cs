namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Retaileler
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string RetailerName { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        [StringLength(128)]
        public string CompanyEmail { get; set; }

        [StringLength(500)]
        public string ProfilePhotoPath { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfResedence { get; set; }

        public bool Signature { get; set; }

        [StringLength(500)]
        public string CompanyDescription { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
