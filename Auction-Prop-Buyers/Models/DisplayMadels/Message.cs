using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
   
        public partial class Message
        {
            public int id { get; set; }

            public string UserID { get; set; }

            public string SellerID { get; set; }
            
        [Display(Name ="Enter your email")]
            public string Message1 { get; set; }
        }
    
}