namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegisteredBuyer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegisteredBuyer()
        {
            AuctionRegistrations = new HashSet<AuctionRegistration>();
            Bids = new HashSet<Bid>();
            BuyerAddresses = new HashSet<BuyerAddress>();
            ConcludedAuctions = new HashSet<ConcludedAuction>();
        }

        [Key]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(13)]
        public string IDNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(500)]
        public string ProfilePhotoPath { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfResidencePath { get; set; }

        [Required]
        [StringLength(500)]
        public string CopyOfIDPath { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfBankAccount { get; set; }

        [Required]
        [StringLength(500)]
        public string IDBuyerVerifyPhoto { get; set; }

        public bool ApprovalStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public bool Signiture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConcludedAuction> ConcludedAuctions { get; set; }

        public virtual Deposit Deposit { get; set; }
    }
    public partial class RegisteredBuyerNoR
    {
        public RegisteredBuyerNoR()
        {
            AuctionRegistrations = new HashSet<AuctionRegistrationNoR>();
            Bids = new HashSet<BidNoR>();
            BuyerAddresses = new HashSet<BuyerAddressNoR>();
            ConcludedAuctions = new HashSet<ConcludedAuctionNoR>();
        }

        [Key]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(13)]
        public string IDNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(500)]
        public string ProfilePhotoPath { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfResidencePath { get; set; }

        [Required]
        [StringLength(500)]
        public string CopyOfIDPath { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfBankAccount { get; set; }

        [Required]
        [StringLength(500)]
        public string IDBuyerVerifyPhoto { get; set; }

        public bool ApprovalStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public bool Signiture { get; set; }

        public virtual ICollection<AuctionRegistrationNoR> AuctionRegistrations { get; set; }

        public virtual ICollection<BidNoR> Bids { get; set; }

        public virtual ICollection<BuyerAddressNoR> BuyerAddresses { get; set; }

        public virtual ICollection<ConcludedAuctionNoR> ConcludedAuctions { get; set; }

        public virtual DepositNoR Deposit { get; set; }

    }
}
