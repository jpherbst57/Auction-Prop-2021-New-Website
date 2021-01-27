namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BuyerAddress")]
    public partial class BuyerAddress
    {
        public int id { get; set; }

        public int AddressID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public virtual Address Address { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
    [Table("BuyerAddress")]
    public partial class BuyerAddressNoR
    {
        public int id { get; set; }

        public int AddressID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public virtual RegisteredBuyerNoR RegisteredBuyer { get; set; }

    }
}
