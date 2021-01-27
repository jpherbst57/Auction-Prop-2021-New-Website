using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    public class SellerAddress
    {
        public int id { get; set; }

        public int AddressID { get; set; }

        [Required]
        public string UserID { get; set; }

        public virtual Address Address { get; set; }

        public virtual Seller Seller { get; set; }
    }
}