using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    public class RetailerView
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string RetailerName { get; set; }

        [StringLength(40)]
        public string Branch { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        [StringLength(128)]
        public string CompanyEmail { get; set; }
    
        public HttpPostedFileBase CompaynLogoPath { get; set; }

        public bool Signature { get; set; }

        public string CompanyDescription { get; set; }

        public virtual Seller Seller { get; set; }
    }

    public class Retailer
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string RetailerName { get; set; }

        [StringLength(40)]
        public string Branch { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        [StringLength(128)]
        public string CompanyEmail { get; set; }

        [StringLength(500)]
        public string CompaynLogoPath { get; set; }

        public bool Signature { get; set; }

        [StringLength(500)]
        public string CompanyDescription { get; set; }

        public virtual Seller Seller { get; set; }
    }
}