
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AccountHolderDbContext : DbContext
    {
        public DbSet<AccountHolder> accountHolder { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Account> account { get; set; }
        public DbSet<Transaction> transaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sql-dev; Database = accountHolder1; Trusted_Connection=True; MultipleActiveResultSets=true;  TrustServerCertificate = true; Encrypt = false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId); // Primary key for Customer

            modelBuilder.Entity<Address>()
                .HasKey(a => a.AddressId); // Primary key for Address

            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountNumber);  // Primary Key for Account
              
            modelBuilder.Entity<AccountHolder>()
               .HasKey(a => a.AccountHolderId);  // Primary key for AccountHolder

            modelBuilder.Entity<Customer>()
                .HasOne(a => a.AddressDetails);   

            modelBuilder.Entity<AccountHolder>()
                .HasOne(a => a.CustomerDetails) 
                .WithOne()
                .HasForeignKey<Customer>(c => c.AccountHolderId);


            // Transactions 

            modelBuilder.Entity<Transaction>()
                .HasKey(a => a.TransactionId);

        }


    }
}
