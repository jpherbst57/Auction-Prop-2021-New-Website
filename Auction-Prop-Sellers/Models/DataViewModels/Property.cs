namespace Auction_Prop_Sellers.Models.DataViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Property
    {
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

        public int? BedRooms { get; set; }

        public int? BathRooms { get; set; }

        public int? FloorSize { get; set; }

        public int? YardSize { get; set; }

        public int? Garages { get; set; }

        public decimal? OpeningBid { get; set; }

        public decimal? Reserve { get; set; }

        public string PlansPath { get; set; }

        public decimal? TaxesAndRate { get; set; }

        public decimal? levies { get; set; }

        [StringLength(500)]
        public string TaxesAndRates { get; set; }

        [StringLength(500)]
        public string TitleDeedPath { get; set; }

        [StringLength(500)]
        public string HOARules { get; set; }

       // public DbGeography Location { get; set; }

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

         public string MandateType { get; set; }

        public DateTime? MandateSingedDate { get; set; }

         public DateTime? MandateExpireDate { get; set; }

        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual ICollection<PromoVideo> PromoVideos { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual ICollection<PropertyPhoto> PropertyPhotos { get; set; }

        public virtual ConcludedAuction ConcludedAuction { get; set; }
    }
    


    public partial class PropertyView
    {
        public PropertyView()
        {
            AuctionRegistrations = new HashSet<AuctionRegistration>();
            PromoVideos = new HashSet<PromoVideo>();
            PropertyPhotos = new HashSet<PropertyPhoto>();
        }

        public int PropertyID { get; set; }

        public string SellerID { get; set; }

        [Required]
        [Display(Name = "Add a title that would be displayed with the property for buyers.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Country.")]
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
        [Display(Name = "Describe the Property for the Bidders.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Registraion Type.")]
        public string RegistrationType { get; set; }

        [Required]

        [Display(Name = "property Type.")]
        public string PropertyType { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "How Many Bedrooms.")]
        public int? BedRooms { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "How Many Bathrooms.")]
        public int? BathRooms { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Floor Size.")]
        public int? FloorSize { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Yard Size.")]
        public int? YardSize { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "How Many Gerages.")]
        public int? Garages { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Opening bid. The auction wil start on this amount.")]
        public decimal? OpeningBid { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Reserve, the auction is succesfull if it surpasses the Resurve.")]
        public decimal? Reserve { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Upload Property plans if you have.")]
        public HttpPostedFileBase PlansPath { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Montly Taxes.")]
        public decimal? TaxesAndRate { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal? levies { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Upload Taxes and rates documents if possible.")]
        public HttpPostedFileBase TaxesAndRates { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Title Deed:")]
        public string TitleDeedPath { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Upload HOA Rules if possible.")]
        public HttpPostedFileBase HOARules { get; set; }

       // public DbGeography Location { get; set; }

        public bool ApprovalStatus { get; set; }


        [Display(Name = "Click the checkbox if you accept our Terms And Conditions.")]
        public bool SellerSigniture { get; set; }

        public bool Garden { get; set; }

        public bool Terrace { get; set; }

        public bool Gerages { get; set; }


        [Display(Name = "Swimming Pool.")]
        public bool SwimmingPool { get; set; }

        public bool Fibre { get; set; }


        [Display(Name = "Club house.")]
        public bool Clubhouse { get; set; }

        public bool Braai { get; set; }

        [Display(Name = "Outdoor Kitchen.")]
        public bool OutdoorKitchen { get; set; }

        [Display(Name = "Fire Place.")]
        public bool FireplacePit { get; set; }


        [Display(Name = "Tennis Court.")]
        public bool TennisCourts { get; set; }

        public bool Jacquizzi { get; set; }

        public bool Parking { get; set; }

        public bool Borehole { get; set; }

        [Display(Name = "Mandate Type.")]
        public string MandateType { get; set; }

        public DateTime? MandateSingedDate { get; set; }

        public DateTime? MandateExpireDate { get; set; }

        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual ICollection<PromoVideo> PromoVideos { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual ICollection<PropertyPhoto> PropertyPhotos { get; set; }

        public virtual ConcludedAuction ConcludedAuction { get; set; }
    }
}
