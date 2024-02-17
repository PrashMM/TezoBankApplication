
using Microsoft.EntityFrameworkCore;
using Models;
using TezoBankApplication.Models;

namespace Data
{
    public class TezoBankDbContext : DbContext
    {
        public DbSet<AccountHolder> AccountHolders { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseNpgsql(@"Host=localhost; Database = TezoBank; TrustServerCertificate=True; Port = 5432; Username = postgres; Password=895185;");
        }
    }
}
