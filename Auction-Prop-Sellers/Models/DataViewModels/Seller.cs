using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    public partial class Seller
    {
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
        [StringLength(11)]
        public string SellerType { get; set; }

        [StringLength(500)]
        public string ProfilePhoto { get; set; }

        [StringLength(128)]
        public string SellerNumber { get; set; }

        [StringLength(128)]
        public string SellerEmail { get; set; }

        public bool Signature { get; set; }

        public bool ApprovalStatus { get; set; }

        public virtual Auctioneer Auctioneer { get; set; }

        public virtual PrivateSeller PrivateSeller { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        public virtual Retailer Retailer { get; set; }

        public virtual ICollection<SellerAddress> SellerAddresses { get; set; }
    }
     
    public partial class SellersView
    {
        public SellersView()
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
        [StringLength(11)]
        public string SellerType { get; set; }

        public HttpPostedFileBase ProfilePhoto { get; set; }

        [StringLength(128)]
        public string SellerNumber { get; set; }

        [StringLength(128)]
        public string SellerEmail { get; set; }

        public bool Signature { get; set; }

        public bool ApprovalStatus { get; set; }

        public virtual Auctioneer Auctioneer { get; set; }

        public virtual PrivateSeller PrivateSeller { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        public virtual Retailer Retailer { get; set; }

        public virtual ICollection<SellerAddress> SellerAddresses { get; set; }
    }
}