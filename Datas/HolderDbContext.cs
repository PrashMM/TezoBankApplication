
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AccountHolderDbContext : DbContext
    {
        public DbSet<TezoBank> tezoBank { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Account> account { get; set; }
        public DbSet<Transaction> transaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sql-dev; Database = accountHolder1; Trusted_Connection=True; MultipleActiveResultSets=true;  TrustServerCertificate = true; Encrypt = false");
        }
    }
}
