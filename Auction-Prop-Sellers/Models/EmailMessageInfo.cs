using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models
{
    public class EmailMessageInfo
    {
        public string FromEmailAddress { get; set; }



        public string ToEmailAddress { get; set; }



        public string CcEmailAddress { get; set; }



        public string BccEmailAddress { get; set; }



        public string EmailSubject { get; set; }



        public string EmailBody { get; set; }

    }
}