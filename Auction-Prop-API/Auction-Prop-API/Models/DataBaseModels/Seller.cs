namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Seller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seller()
        {
            Properties = new HashSet<Property>();
            SellerAddresses = new HashSet<SellerAddress>();
        }

        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string FirtstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string SellerType { get; set; }

        public bool Signature { get; set; }

        public bool ApprovalStatus { get; set; }

        public virtual Actioneer Actioneer { get; set; }

        public virtual PrivateSeller PrivateSeller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Property> Properties { get; set; }

        public virtual Retaileler Retaileler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SellerAddress> SellerAddresses { get; set; }
    }
}
