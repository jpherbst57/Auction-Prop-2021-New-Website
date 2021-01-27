using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    public partial class PropertyPhoto
    {
        [Key]
        public int ImageID { get; set; }

        public int PropertyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string PropertyPhotoPath { get; set; }

        public virtual Property Property { get; set; }
    }
    public class PropertyPhotoView
    {
        [Key]
        public int ImageID { get; set; }

        public int PropertyId { get; set; }

        
        public string Title { get; set; }

     
        public string Description { get; set; }

        [Required]
        public HttpPostedFileBase PropertyPhotoPath { get; set; }

        public virtual Property Property { get; set; }
    }
}