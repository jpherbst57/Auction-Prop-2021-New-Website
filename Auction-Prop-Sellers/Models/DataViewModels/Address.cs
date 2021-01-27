using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    
        public partial class Address
        {
            public Address()
            {
                SellerAddresses = new HashSet<SellerAddress>();
            }
        
            public int AddressID { get; set; }

            [Required]

        [Display(Name = "Country")]
        public string Country { get; set; }

            [Required]
            public string City { get; set; }

            [StringLength(128)]
            public string Supburb { get; set; }

            [StringLength(128)]
            public string Area { get; set; }

            [Required]
            [StringLength(100)]
            public string Street { get; set; }

            public int Number { get; set; }

            public virtual ICollection<SellerAddress> SellerAddresses { get; set; }
        }

}