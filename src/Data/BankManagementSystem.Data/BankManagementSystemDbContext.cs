namespace BankManagementSystem.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using BankManagementSystem.Models;

    public class BankManagementSystemDbContext : IdentityDbContext<Client>
    {
        public BankManagementSystemDbContext(DbContextOptions<BankManagementSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Asset> Assets { get; set; }
        
        public DbSet<Credit> Credits { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Asset>()
                .HasOne(a => a.Owner)
                .WithMany(c => c.CreatedAssets)
                .HasForeignKey(a => a.OwnerId);

            builder.Entity<Asset>()
                .HasOne(a => a.Vendor)
                .WithMany(c => c.PurchasedAssets)
                .HasForeignKey(a => a.VendorId);

            builder.Entity<Credit>()
                .HasOne(cr => cr.Client)
                .WithMany(cl => cl.Credits)
                .HasForeignKey(cr => cr.ClientId);

            builder.Entity<CreditCard>()
                .HasOne(cc => cc.Client)
                .WithMany(c => c.CreditCards)
                .HasForeignKey(cc => cc.ClientId);

            builder.Entity<Deposit>()
                .HasOne(d => d.Client)
                .WithMany(c => c.Deposits)
                .HasForeignKey(d => d.ClientId);

            builder.Entity<Transaction>()
                .HasOne(t => t.Client)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.ClientId);

            base.OnModelCreating(builder);
        }
    }
}
