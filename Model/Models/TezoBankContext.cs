using Microsoft.EntityFrameworkCore;

namespace Models.Models;

public partial class TezoBankContext : DbContext
{
    public TezoBankContext()
    {
    }

    public TezoBankContext(DbContextOptions<TezoBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountDetail> AccountDetails { get; set; }

    public virtual DbSet<AccountHolder> AccountHolders { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<ContactDetail> ContactDetails { get; set; }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=TezoBank; Username=postgres;Password=895185");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountHolder>(entity =>
        {
            entity.HasIndex(e => e.AccountDetailsId, "IX_AccountHolders_AccountDetailsId");

            entity.HasIndex(e => e.ContactDetailsId, "IX_AccountHolders_ContactDetailsId");

            entity.HasIndex(e => e.PersonalDetailsId, "IX_AccountHolders_PersonalDetailsId");

            entity.HasOne(d => d.AccountDetails).WithMany(p => p.AccountHolders).HasForeignKey(d => d.AccountDetailsId);

            entity.HasOne(d => d.ContactDetails).WithMany(p => p.AccountHolders).HasForeignKey(d => d.ContactDetailsId);

            entity.HasOne(d => d.PersonalDetails).WithMany(p => p.AccountHolders).HasForeignKey(d => d.PersonalDetailsId);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");
        });

        modelBuilder.Entity<ContactDetail>(entity =>
        {
            entity.HasIndex(e => e.AddressId, "IX_ContactDetails_AddressId");

            entity.HasOne(d => d.Address).WithMany(p => p.ContactDetails).HasForeignKey(d => d.AddressId);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasIndex(e => e.ReceiverAccountId, "IX_Transactions_ReceiverAccountId");

            entity.HasIndex(e => e.UserAccountId, "IX_Transactions_UserAccountId");

            entity.HasOne(d => d.ReceiverAccount).WithMany(p => p.TransactionReceiverAccounts).HasForeignKey(d => d.ReceiverAccountId);

            entity.HasOne(d => d.UserAccount).WithMany(p => p.TransactionUserAccounts).HasForeignKey(d => d.UserAccountId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
