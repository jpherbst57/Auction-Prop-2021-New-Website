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

    public partial class PromoVideo
    {
        [Key]
       public int VideoID { get; set; }

        public int PropertyID { get; set; }

        [Required]
         public string VideoPath { get; set; }

        public virtual Property Property { get; set; }
    }


    public partial class PromoVideoData
    {
        [Key]
        public int VideoID { get; set; }

        public int PropertyID { get; set; }

        [Required]
        public HttpPostedFileBase VideoPath { get; set; }

        public virtual Property Property { get; set; }
    }
}