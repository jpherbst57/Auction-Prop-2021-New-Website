using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class PromoVideo
    {
        [Key]
        public int VideoID { get; set; }

        public int PropertyID { get; set; }

        [Required]

        [Display(Name = "Upload youre video here.")]
        public string VideoPath { get; set; }

        public virtual Property Property { get; set; }
    }
}