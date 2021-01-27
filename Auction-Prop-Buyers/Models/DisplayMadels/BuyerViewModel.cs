using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class BuyerViewModel
    {
        public BuyerViewModel()
        {
            AuctionRegistrations = new HashSet<AuctionRegistration>();
            BankApprovals = new HashSet<BankApproval>();
            Bids = new HashSet<Bid>();
            BuyerAddresses = new HashSet<BuyerAddress>();
            ConcludedAuctions = new HashSet<ConcludedAuction>();
            Guarintees = new HashSet<Guarintee>();
        }

        public string UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Enter youre ID number.")]
        public string IDNumber { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Click the checkbox if you are a bonded buyer.")]
        public bool BondedOrCash { get; set; }

        [Required]
        [Display(Name = "Upload youre profile photo to be displayed to other bidders.")]
        public HttpPostedFileBase ProfilePhotoPath { get; set; }

        [Required]
        [Display(Name = "Upload proof of residence.")]
        public HttpPostedFileBase ProofOfResidencePath { get; set; }

        [Required]
        [Display(Name = "Upload a copy of youre id document.")]
        public HttpPostedFileBase CopyOfIDPath { get; set; }

        [Required]
        [Display(Name = "Upload a proof of your bank account.")]
        public HttpPostedFileBase ProofOfBankAccount { get; set; }

        [Required]

        [Display(Name = "Upload a photo of you holding youre ID document.")]
        public HttpPostedFileBase IDBuyerVerifyPhoto { get; set; }


        public bool ApprovalStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Display(Name = "Terms And Conitions")]
        public bool Signiture { get; set; }

        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual ICollection<BankApproval> BankApprovals { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }

        public virtual ICollection<ConcludedAuction> ConcludedAuctions { get; set; }

        public virtual Deposit Deposit { get; set; }

        public virtual ICollection<Guarintee> Guarintees { get; set; }


    }
    
    public partial class RegisteredBuyer
    {
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

        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }

        public virtual ICollection<ConcludedAuction> ConcludedAuctions { get; set; }

        public virtual Deposit Deposit { get; set; }

    }
    }