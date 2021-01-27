namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PrivateSeller
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(13)]
        public string IDNumber { get; set; }

        [StringLength(500)]
        public string ProfilePhotoPath { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfResedence { get; set; }

        public bool Signiture { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
