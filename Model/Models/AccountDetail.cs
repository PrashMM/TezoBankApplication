namespace Models.Models;

public partial class AccountDetail
{
    public string Id { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public double Balance { get; set; }

    public double InitialAmount { get; set; }

    public int AccountType { get; set; }

    public virtual ICollection<AccountHolder> AccountHolders { get; set; } = new List<AccountHolder>();
}
