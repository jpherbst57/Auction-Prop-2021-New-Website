using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Auction_Prop_Buyers.Models.DisplayMadels;


namespace AuctionPortal.Hubs
{
    [HubName("auctionHub")]
    public class AuctionHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage2(name, message);
        }


        public void concludeAuction(int auctionID, string userID)
        {
            ICollection<Bid> bids = APILibrary.APIMethods.APIGetALL<ICollection<Bid>>("Bids");
            Bid maxBid = new Bid();
            bool first = true;
            foreach (Bid b in bids)
            {
                if (b.PropertyID == auctionID)
                {
                    if (first)
                    {
                        maxBid = b;
                        first = false;
                    }
                    else
                    {
                        if (b.AmuntOfBid > maxBid.AmuntOfBid)
                        {
                            maxBid = b;
                        }
                    }
                }
            }

            ConcludedAuction Conclution = new ConcludedAuction()
            {
                HiegestBid = Convert.ToInt32(maxBid.AmuntOfBid),
                    PropertyID = auctionID,
                TimeOfConclution = DateTime.Now,
                ExceededReserve = true,
                WinningBidder = userID
                };
                APILibrary.APIMethods.APIPost<Bid>(Conclution, "ConcludedAuctions");
            
          
        }
        public void Bid2(string name, decimal bid, int auctionID, string userID)
        {
            // Call the broadcastMessage method to update clients.
            ICollection< Bid> bids = APILibrary.APIMethods.APIGetALL<ICollection<Bid>>("Bids");
            Bid maxBid = new Bid();
            bool first = true;
            foreach(Bid b in bids)
            {
                if(b.PropertyID== auctionID)
                {
                    if(first)
                    {
                        maxBid = b;
                        first = false;
                    }
                    else
                    {
                        if(b.AmuntOfBid > maxBid.AmuntOfBid)
                        {
                            maxBid = b;
                        }
                    }
                }
            }
            if (bid > maxBid.AmuntOfBid)
            {
                Bid newBid = new Bid()
                {
                    BuyerID = userID,
                    PropertyID = auctionID,
                    TimeOfbid = DateTime.Now,
                    AmuntOfBid = (decimal)bid
                };
                Clients.All.broadcastMessage(name, bid);
                APILibrary.APIMethods.APIPost<Bid>(newBid, "Bids");
            }
            else
            {
                return;
            }
        }
        public void Bid3(string name, decimal bid, int auctionID, string userID)
        {
            // Call the broadcastMessage method to update clients.
            ICollection< Bid> bids = APILibrary.APIMethods.APIGetALL<ICollection<Bid>>("Bids");
            RegisteredBuyer buyer = APILibrary.APIMethods.APIGetALL<RegisteredBuyer>("RegisteredBuyers");
            Bid maxBid = new Bid();
            bool first = true;
            foreach(Bid b in bids)
            {
                if(b.PropertyID== auctionID)
                {
                    if(first)
                    {
                        maxBid = b;
                        first = false;
                    }
                    else
                    {
                        if(b.AmuntOfBid > maxBid.AmuntOfBid)
                        {
                            maxBid = b;
                        }
                    }
                }
            }
            if (bid > maxBid.AmuntOfBid)
            {
                Bid newBid = new Bid()
                {
                    BuyerID = userID,
                    PropertyID = auctionID,
                    TimeOfbid = DateTime.Now,
                    AmuntOfBid = (decimal)bid
                };
                Clients.All.broadcastMessage3(buyer.ProfilePhotoPath,name, bid);
                APILibrary.APIMethods.APIPost<Bid>(newBid, "Bids");
            }
            else
            {
                return;
            }
        }
      
        public void Bid(string name, double bid, double current)
        {
            // Call the broadcastMessage method to update clients.
            current += bid;
            Clients.All.broadcastMessage(name, current);
        }



    }
}