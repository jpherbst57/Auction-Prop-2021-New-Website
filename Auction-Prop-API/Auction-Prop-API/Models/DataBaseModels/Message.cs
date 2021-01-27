namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int id { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        [StringLength(128)]
        public string SellerID { get; set; }

        [Column("Message")]
        [StringLength(1000)]
        public string Message1 { get; set; }
    }
}
