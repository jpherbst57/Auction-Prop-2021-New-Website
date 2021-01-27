namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SellerAddress")]
    public partial class SellerAddress
    {
        public int id { get; set; }

        public int AddressID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public virtual Address Address { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
