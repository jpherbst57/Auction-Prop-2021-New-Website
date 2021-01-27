using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class PropertyPhotoViewModel
    {
    }
    public class PropertyPhoto
    {
        public int ImageID { get; set; }

        public int PropertyId { get; set; }


        [Display(Name = "Enter a title for the photo. this is not required.")]
        public string Title { get; set; }


        [Display(Name = "Enter a Description to acompany the photo. this is not required.")]
        public string Description { get; set; }

        public string PropertyPhotoPath { get; set; }

        public virtual Property Property { get; set; }
    }
}