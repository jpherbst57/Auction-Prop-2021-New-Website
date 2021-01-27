namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Guarintee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuctionRegistrationID { get; set; }

        [Required]
        [StringLength(500)]
        public string GuarinteePath { get; set; }

        public bool GuarinteeApproval { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfSubmition { get; set; }

        public virtual AuctionRegistration AuctionRegistration { get; set; }
    }
    public partial class GuarinteeNoR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuctionRegistrationID { get; set; }

        [Required]
        [StringLength(500)]
        public string GuarinteePath { get; set; }

        public bool GuarinteeApproval { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfSubmition { get; set; }

        public virtual AuctionRegistrationNoR AuctionRegistration { get; set; }

    }
}
