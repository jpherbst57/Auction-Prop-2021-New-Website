namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            BuyerAddresses = new HashSet<BuyerAddress>();
            SellerAddresses = new HashSet<SellerAddress>();
        }

        public int AddressID { get; set; }

        [Required]
        [StringLength(128)]
        public string Country { get; set; }

        [Required]
        [StringLength(128)]
        public string City { get; set; }

        [StringLength(128)]
        public string Supburb { get; set; }

        [StringLength(128)]
        public string Area { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        public int Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SellerAddress> SellerAddresses { get; set; }
    }
}
