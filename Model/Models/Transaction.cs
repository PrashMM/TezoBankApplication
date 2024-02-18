namespace Models.Models;

public partial class Transaction
{
    public string Id { get; set; } = null!;

    public DateTime Time { get; set; }

    public double Amount { get; set; }

    public string UserAccountId { get; set; } = null!;

    public string? ReceiverAccountId { get; set; }

    public int Type { get; set; }

    public virtual AccountHolder? ReceiverAccount { get; set; }

    public virtual AccountHolder UserAccount { get; set; } = null!;

    public Transaction()
    {
    }

    public Transaction(DateTime time, double amount, AccountHolder userAccount, TransferType type, AccountHolder receiverAccount = null)
    {
        var types = type == TransferType.Credit ? 1 : type == TransferType.Debit ? 2 : 3;

        Time = time;
        Amount = amount;
        //UserAccount = userAccount;
        Type = types;
        //ReceiverAccount = receiverAccount;
    }
}
