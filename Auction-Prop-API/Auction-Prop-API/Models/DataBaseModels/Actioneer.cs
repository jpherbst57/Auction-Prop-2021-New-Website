namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Actioneer")]
    public partial class Actioneer
    {
        [Key]
        public string UserID { get; set; }

        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(128)]
        public string LastName { get; set; }

        [StringLength(128)]
        public string CompanyName { get; set; }

        [StringLength(128)]
        public string CompanyLogo { get; set; }

        [StringLength(128)]
        public string Branch { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
