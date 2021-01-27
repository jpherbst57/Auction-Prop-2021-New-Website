using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public partial class AuctionRegistrationViewModel
    {

        public int id { get; set; }

        public string BuyerId { get; set; }

        public int PropertyID { get; set; }


        public bool RegistrationFees { get; set; }

        public DateTime RegesterDate { get; set; }

        [Required]
        [Display(Name = "Terms And Contitions")]
        public bool Signiture { get; set; }

        public bool RegistrationStatus { get; set; }

        public virtual AdminFee AdminFee { get; set; }

        public virtual Property Property { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
    public  class AuctionRegistration
    {
        public int id { get; set; }

        [Required]
         public string BuyerId { get; set; }

        public int PropertyID { get; set; }

        public bool RegistrationFees { get; set; }

        public DateTime RegesterDate { get; set; }

        [Required]
        [Display(Name = "Terms And Contitions")]
        public bool Signiture { get; set; }


        public bool RegistrationStatus { get; set; }

        public bool Bonded { get; set; }

        public virtual AdminFee AdminFee { get; set; }

        public virtual Property Property { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }

        public virtual BankApproval BankApproval { get; set; }

        public virtual Guarintee Guarintee { get; set; }
    }
    public class AuctionRegistrationInvitation
    {
        [Required]
        [Display(Name = "Enter youre invitation code.")]
        public string inInvitationCode { get; set; }


        public const string cInvitationCode = "AuctionInv-01";
        public virtual AuctionRegistration registration{get;set;}
    }
}