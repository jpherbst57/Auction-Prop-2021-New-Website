using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class BankApprovalView
    {

        [Key]
        public int AuctionRegistrationID { get; set; }

        [Display(Name = "Ubload youre banks Approvals.")]
        public HttpPostedFileBase ApprovalPath { get; set; }

        public bool BankApprovalApprovalstatus { get; set; }

        public DateTime DateOfSubmision { get; set; }

        public virtual AuctionRegistration AuctionRegistration { get; set; }
    }



    public partial class BankApproval
        {
            [Key]
            public int AuctionRegistrationID { get; set; }

            public string ApprovalPath { get; set; }

            public bool BankApprovalApprovalstatus { get; set; }

            public DateTime DateOfSubmision { get; set; }

            public virtual AuctionRegistration AuctionRegistration { get; set; }
        }
    


}