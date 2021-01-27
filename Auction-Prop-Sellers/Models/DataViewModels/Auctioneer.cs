using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Auctioneer
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string CompanyName { get; set; }

        [StringLength(40)]
        public string Branch { get; set; }

        [StringLength(128)]
        public string CompanyLogo { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        [StringLength(228)]
        public string CompanyEmail { get; set; }

        public bool Signature { get; set; }

        [StringLength(500)]
        public string CompanyDescriprion { get; set; }

        public virtual Seller Seller { get; set; }
    }
    public partial class AuctioneerView
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "Auction Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Branch")]
        public string Branch { get; set; }


        [Display(Name = "Upload Youre Company Logo.")]
        public HttpPostedFileBase CompanyLogo { get; set; }

        [StringLength(11)]

        [Display(Name = "Company Contact number")]
        public string CompanyContactNumber { get; set; }


        [Display(Name = "Company Email Address")]
        public string CompanyEmail { get; set; }


        [Display(Name = "Click the checkbox if you accept our Terms And Conditions")]
        public bool Signature { get; set; }


        [Display(Name = "Describe youre company.")]
        public string CompanyDescriprion { get; set; }

        public virtual Seller Seller { get; set; }
    }
}