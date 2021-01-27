using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class BuyerAddressViewModel
    {
    }
    public partial class BuyerAddress
    {
        public int id { get; set; }

        public int AddressID { get; set; }

        [Required]
        public string UserID { get; set; }

        public virtual Address Address { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
}