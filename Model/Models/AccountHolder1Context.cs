
using Microsoft.EntityFrameworkCore;

namespace Models.Models;

public partial class AccountHolder1Context : DbContext
{
    public AccountHolder1Context()
    {
    }

    public AccountHolder1Context(DbContextOptions<AccountHolder1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<TezoBank> TezoBanks { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql-dev; Database = accountHolder1; Trusted_Connection=True; MultipleActiveResultSets=true;  TrustServerCertificate = true; Encrypt = false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountNumber);

            entity.ToTable("account");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("addresses");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customers");

            entity.HasIndex(e => e.AccountDetailsAccountNumber, "IX_customers_AccountDetailsAccountNumber");

            entity.HasIndex(e => e.AddressId, "IX_customers_AddressId");

            entity.HasOne(d => d.AccountDetailsAccountNumberNavigation).WithMany(p => p.Customers).HasForeignKey(d => d.AccountDetailsAccountNumber);

            entity.HasOne(d => d.Address).WithMany(p => p.Customers).HasForeignKey(d => d.AddressId);
        });

        modelBuilder.Entity<TezoBank>(entity =>
        {
            entity.ToTable("tezoBank");

            entity.HasIndex(e => e.CustomerId, "IX_tezoBank_CustomerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.TezoBanks).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("transaction");

            entity.HasIndex(e => e.ReceiverAccountId, "IX_transaction_ReceiverAccountId");

            entity.HasIndex(e => e.UserAccountId, "IX_transaction_UserAccountId");

            entity.HasOne(d => d.ReceiverAccount).WithMany(p => p.TransactionReceiverAccounts).HasForeignKey(d => d.ReceiverAccountId);

            entity.HasOne(d => d.UserAccount).WithMany(p => p.TransactionUserAccounts).HasForeignKey(d => d.UserAccountId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
