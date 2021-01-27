namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
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
        [StringLength(20)]
        public string Type { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        public int? BedRooms { get; set; }

        public int? BathRooms { get; set; }

        public int? BuildingArea { get; set; }

        public int? TerraceArea { get; set; }

        public int? Garages { get; set; }

        [Column(TypeName = "money")]
        public decimal PrpertyValue { get; set; }

        [Column(TypeName = "money")]
        public decimal? MinimubBid { get; set; }

        [Column(TypeName = "money")]
        public decimal? Reserve { get; set; }

        [Required]
        [StringLength(500)]
        public string PlansPath { get; set; }

        [Required]
        [StringLength(500)]
        public string TaxesAndRates { get; set; }

        [Required]
        [StringLength(500)]
        public string TitleDeedPath { get; set; }

        public DbGeography Location { get; set; }

        public bool ApprovalStatus { get; set; }

        public bool SellerSigniture { get; set; }

        [Column("A/C")]
        public bool A_C { get; set; }

        public bool PetsAllowed { get; set; }

        public bool Garden { get; set; }

        public bool CableTV { get; set; }

        public bool Terrace { get; set; }

        [Column("wi-fi")]
        public bool wi_fi { get; set; }

        public bool Fibre { get; set; }

        public bool Pool { get; set; }

        public bool Balcony { get; set; }

        public bool Parquet { get; set; }

        public bool Beach { get; set; }

        public bool Gerage { get; set; }

        public bool RoofTarrace { get; set; }

        public bool Sauna { get; set; }

        public bool OutdoorKitchen { get; set; }

        public bool FireplacePit { get; set; }

        public bool SunRoom { get; set; }

        public bool ConcreteFlooring { get; set; }

        public bool WoodFloring { get; set; }

        public bool TennisCourts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual Auction Auction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromoVideo> PromoVideos { get; set; }

        public virtual Seller Seller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyPhoto> PropertyPhotos { get; set; }
    }
}
