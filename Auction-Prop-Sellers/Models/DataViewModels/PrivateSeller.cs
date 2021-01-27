using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    public class PrivateSellerData
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(13)]

        [Display(Name = "Enter your ID number")]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "Upload proof of residence.")]
        public HttpPostedFileBase ProofOfResedence { get; set; }


        [Display(Name = "Click the checkbox if you accept our Terms And Conditions")]
        public bool Signiture { get; set; }

        public virtual Seller Seller { get; set; }
    }
    
    public class PrivateSeller
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        [StringLength(13)]
        public string IDNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfResedence { get; set; }

        public bool Signiture { get; set; }

        public virtual Seller Seller { get; set; }

    }
}
