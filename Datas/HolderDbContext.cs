
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
           optionsBuilder.UseNpgsql(@"Host=localhost; Database = accountHolder; TrustServerCertificate=True; Port = 5432; Username = postgres; Password=895185;");
        }
    }
}
