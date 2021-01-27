using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class GuarinteeViewModel
    {
        [Key]
        public int AuctionRegistrationID { get; set; }

        [Display(Name = "Upload youre bank Guarintees document.")]
        public HttpPostedFileBase GuarinteePath { get; set; }

        public bool GuarinteeApproval { get; set; }

        public DateTime DateOfSubmition { get; set; }

        public virtual AuctionRegistration AuctionRegistration { get; set; }
    }

    public partial class Guarintee
    {

        [Key]
        public int AuctionRegistrationID { get; set; }

        public string GuarinteePath { get; set; }

        public bool GuarinteeApproval { get; set; }

        public DateTime DateOfSubmition { get; set; }

        public virtual AuctionRegistration AuctionRegistration { get; set; }
    }
}