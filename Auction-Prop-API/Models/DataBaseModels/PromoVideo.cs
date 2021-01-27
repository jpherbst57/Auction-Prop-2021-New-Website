namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PromoVideo")]
    public partial class PromoVideo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VideoID { get; set; }

        public int PropertyID { get; set; }

        [Required]
        [StringLength(500)]
        public string VideoPath { get; set; }

        public virtual Property Property { get; set; }
    }
    [Table("PromoVideo")]
    public partial class PromoVideoNoR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VideoID { get; set; }

        public int PropertyID { get; set; }

        [Required]
        [StringLength(500)]
        public string VideoPath { get; set; }


        public virtual PropertyNoR Property { get; set; }
    }
}
