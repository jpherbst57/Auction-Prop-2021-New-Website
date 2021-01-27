namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PropertyPhotos")]
    public partial class PropertyPhoto
    {
        [Key]
        public int ImageID { get; set; }

        public int PropertyId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string PropertyPhotoPath { get; set; }

        public virtual Property Property { get; set; }
    }
    [Table("PropertyPhotos")]
    public partial class PropertyPhotoNoR
    {
        [Key]
        public int ImageID { get; set; }

        public int PropertyId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string PropertyPhotoPath { get; set; }

        public virtual Property PropertyNoR { get; set; }
    }
}
