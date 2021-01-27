namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBaseModels : DbContext
    {
        public DataBaseModels()
            : base("name=DataBaseModels")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AdminFee> AdminFees { get; set; }
        public virtual DbSet<Auctioneer> Auctioneers { get; set; }
        public virtual DbSet<AuctionRegistration> AuctionRegistrations { get; set; }
        public virtual DbSet<Auction> Auctions { get; set; }
        public virtual DbSet<BankApproval> BankApprovals { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<BuyerAddress> BuyerAddresses { get; set; }
        public virtual DbSet<ConcludedAuction> ConcludedAuctions { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Guarintee> Guarintees { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PrivateSeller> PrivateSellers { get; set; }
        public virtual DbSet<PromoVideo> PromoVideos { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyPhoto> PropertyPhotos { get; set; }
        public virtual DbSet<RegisteredBuyer> RegisteredBuyers { get; set; }
        public virtual DbSet<Retailer> Retailers { get; set; }
        public virtual DbSet<SellerAddress> SellerAddresses { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.Country)
                .IsFixedLength();

            modelBuilder.Entity<Address>()
                .Property(e => e.City)
                .IsFixedLength();

            modelBuilder.Entity<Address>()
                .Property(e => e.Supburb)
                .IsFixedLength();

            modelBuilder.Entity<Address>()
                .Property(e => e.Area)
                .IsFixedLength();

            modelBuilder.Entity<Address>()
                .Property(e => e.Street)
                .IsFixedLength();

            modelBuilder.Entity<Address>()
                .HasMany(e => e.BuyerAddresses)
                .WithRequired(e => e.Address)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<AdminFee>()
                .Property(e => e.ProofOfPaymentPath)
                .IsFixedLength();

            modelBuilder.Entity<AdminFee>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Auctioneer>()
                .Property(e => e.CompanyContactNumber)
                .IsFixedLength();

            modelBuilder.Entity<AuctionRegistration>()
                .HasOptional(e => e.AdminFee)
                .WithRequired(e => e.AuctionRegistration);

            modelBuilder.Entity<AuctionRegistration>()
                .HasOptional(e => e.BankApproval)
                .WithRequired(e => e.AuctionRegistration);

            modelBuilder.Entity<AuctionRegistration>()
                .HasOptional(e => e.Guarintee)
                .WithRequired(e => e.AuctionRegistration);

            modelBuilder.Entity<Auction>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Auction)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Bid>()
                .Property(e => e.AmuntOfBid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bid>()
                .HasMany(e => e.ConcludedAuctions)
                .WithRequired(e => e.Bid)
                .HasForeignKey(e => e.HiegestBid)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Deposit>()
                .Property(e => e.ProofOfPaymentPath)
                .IsFixedLength();

            modelBuilder.Entity<Deposit>()
                .Property(e => e.ProofOfReturnPayment)
                .IsFixedLength();

            modelBuilder.Entity<Deposit>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Guarintee>()
                .Property(e => e.GuarinteePath)
                .IsFixedLength();

            modelBuilder.Entity<Message>()
                .Property(e => e.UserID)
                .IsFixedLength();

            modelBuilder.Entity<Message>()
                .Property(e => e.SellerID)
                .IsFixedLength();

            modelBuilder.Entity<Message>()
                .Property(e => e.Message1)
                .IsFixedLength();

            modelBuilder.Entity<PrivateSeller>()
                .Property(e => e.IDNumber)
                .IsFixedLength();

            modelBuilder.Entity<PrivateSeller>()
                .Property(e => e.ProofOfResedence)
                .IsFixedLength();

            modelBuilder.Entity<PromoVideo>()
                .Property(e => e.VideoPath)
                .IsFixedLength();

            modelBuilder.Entity<Property>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Property>()
                .Property(e => e.OpeningBid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Property>()
                .Property(e => e.Reserve)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Property>()
                .Property(e => e.TaxesAndRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Property>()
                .Property(e => e.levies)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Property>()
                .Property(e => e.MandateType)
                .IsFixedLength();

            modelBuilder.Entity<Property>()
                .HasMany(e => e.AuctionRegistrations)
                .WithRequired(e => e.Property)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Property>()
                .HasOptional(e => e.Auction)
                .WithRequired(e => e.Property);

            modelBuilder.Entity<Property>()
                .HasOptional(e => e.ConcludedAuction)
                .WithRequired(e => e.Property);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.PromoVideos)
                .WithRequired(e => e.Property)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RegisteredBuyer>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<RegisteredBuyer>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<RegisteredBuyer>()
                .Property(e => e.IDNumber)
                .IsFixedLength();

            modelBuilder.Entity<RegisteredBuyer>()
                .Property(e => e.IDBuyerVerifyPhoto)
                .IsFixedLength();

            modelBuilder.Entity<RegisteredBuyer>()
                .HasMany(e => e.AuctionRegistrations)
                .WithRequired(e => e.RegisteredBuyer)
                .HasForeignKey(e => e.BuyerId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RegisteredBuyer>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.RegisteredBuyer)
                .HasForeignKey(e => e.BuyerID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RegisteredBuyer>()
                .HasMany(e => e.BuyerAddresses)
                .WithRequired(e => e.RegisteredBuyer)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RegisteredBuyer>()
                .HasMany(e => e.ConcludedAuctions)
                .WithRequired(e => e.RegisteredBuyer)
                .HasForeignKey(e => e.WinningBidder)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RegisteredBuyer>()
                .HasOptional(e => e.Deposit)
                .WithRequired(e => e.RegisteredBuyer);

            modelBuilder.Entity<Retailer>()
                .Property(e => e.CompanyContactNumber)
                .IsFixedLength();

            modelBuilder.Entity<Seller>()
                .Property(e => e.FirtstName)
                .IsFixedLength();

            modelBuilder.Entity<Seller>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<Seller>()
                .Property(e => e.SellerType)
                .IsFixedLength();

            modelBuilder.Entity<Seller>()
                .HasOptional(e => e.Auctioneer)
                .WithRequired(e => e.Seller);

            modelBuilder.Entity<Seller>()
                .HasOptional(e => e.PrivateSeller)
                .WithRequired(e => e.Seller)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Properties)
                .WithRequired(e => e.Seller)
                .HasForeignKey(e => e.SellerID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Seller>()
                .HasOptional(e => e.Retailer)
                .WithRequired(e => e.Seller)
                .WillCascadeOnDelete();
        }

   }
}
