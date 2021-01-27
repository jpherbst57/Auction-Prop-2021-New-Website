namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Property()
        {
            AuctionRegistrations = new HashSet<AuctionRegistration>();
            PromoVideos = new HashSet<PromoVideo>();
            PropertyPhotos = new HashSet<PropertyPhoto>();
        }

        public int PropertyID { get; set; }

        [Required]
        [StringLength(128)]
        public string SellerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(128)]
        public string Country { get; set; }

        [Required]
        [StringLength(128)]
        public string Province { get; set; }

        [Required]
        [StringLength(128)]
        public string City { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationType { get; set; }

        [Required]
        [StringLength(50)]
        public string PropertyType { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DefaultValue(0)]
        public int? BedRooms { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DefaultValue(0)]
        public int? BathRooms { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DefaultValue(0)]
        public int? FloorSize { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DefaultValue(0)]
        public int? YardSize { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DefaultValue(0)]
        public int? Garages { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Column(TypeName = "money")]
        [DefaultValue(0)]
        public decimal? OpeningBid { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Column(TypeName = "money")]
        public decimal? Reserve { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PlansPath { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Column(TypeName = "money")]
        [DefaultValue(0)]
        public decimal? TaxesAndRate { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Column(TypeName = "money")]
        [DefaultValue(0)]
        public decimal? levies { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TaxesAndRates { get; set; }

        public string TitleDeedPath { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull=false)]
        public string HOARules { get; set; }

       // public DbGeography Location = DbGeography.FromText("POINT(53.095124 -0.864716)", 4326);

        public bool ApprovalStatus { get; set; }

        public bool SellerSigniture { get; set; }

        public bool Garden { get; set; }

        public bool Terrace { get; set; }

        public bool Gerages { get; set; }

        public bool SwimmingPool { get; set; }

        public bool Fibre { get; set; }

        public bool Clubhouse { get; set; }

        public bool Braai { get; set; }

        public bool OutdoorKitchen { get; set; }

        public bool FireplacePit { get; set; }

        public bool TennisCourts { get; set; }

        public bool Jacquizzi { get; set; }

        public bool Parking { get; set; }

        public bool Borehole { get; set; }

        [StringLength(10)]
        public string MandateType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MandateSingedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MandateExpireDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual ConcludedAuction ConcludedAuction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromoVideo> PromoVideos { get; set; }

        public virtual Seller Seller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyPhoto> PropertyPhotos { get; set; }
    }
      public partial class PropertyNoR
    {
        public PropertyNoR()
        {
            PromoVideos = new HashSet<PromoVideoNoR>();
            PropertyPhotos = new HashSet<PropertyPhotoNoR>();

            AuctionRegistrations = new HashSet<AuctionRegistrationNoR>();
        }

        public int PropertyID { get; set; }

        [Required]
        [StringLength(128)]
        public string SellerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(128)]
        public string Country { get; set; }

        [Required]
        [StringLength(128)]
        public string Province { get; set; }

        [Required]
        [StringLength(128)]
        public string City { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationType { get; set; }

        [Required]
        [StringLength(50)]
        public string PropertyType { get; set; }

        public int? BedRooms { get; set; }

        public int? BathRooms { get; set; }

        public int? FloorSize { get; set; }

        public int? YardSize { get; set; }

        public int? Garages { get; set; }

        [Column(TypeName = "money")]
        public decimal? OpeningBid { get; set; }

        [Column(TypeName = "money")]
        public decimal? Reserve { get; set; }

        [StringLength(500)]
        public string PlansPath { get; set; }

        [Column(TypeName = "money")]
        public decimal? TaxesAndRate { get; set; }

        [Column(TypeName = "money")]
        public decimal? levies { get; set; }

        [StringLength(500)]
        public string TaxesAndRates { get; set; }

        [StringLength(500)]
        public string TitleDeedPath { get; set; }

        [StringLength(500)]
        public string HOARules { get; set; }

       // public DbGeography Location = DbGeography.FromText("POINT(53.095124 -0.864716)", 4326);

        public bool ApprovalStatus { get; set; }

        public bool SellerSigniture { get; set; }

        public bool Garden { get; set; }

        public bool Terrace { get; set; }

        public bool Gerages { get; set; }

        public bool SwimmingPool { get; set; }

        public bool Fibre { get; set; }

        public bool Clubhouse { get; set; }

        public bool Braai { get; set; }

        public bool OutdoorKitchen { get; set; }

        public bool FireplacePit { get; set; }

        public bool TennisCourts { get; set; }

        public bool Jacquizzi { get; set; }

        public bool Parking { get; set; }

        public bool Borehole { get; set; }

        [StringLength(10)]
        public string MandateType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MandateSingedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? MandateExpireDate { get; set; }

        public virtual ICollection<AuctionRegistrationNoR> AuctionRegistrations { get; set; }

        public virtual AuctionNoR Auction { get; set; }

        public virtual ConcludedAuctionNoR ConcludedAuction { get; set; }

       public virtual ICollection<PromoVideoNoR> PromoVideos { get; set; }

        public virtual SellerNoR Seller { get; set; }

        public virtual ICollection<PropertyPhotoNoR> PropertyPhotos { get; set; }

    }


}
