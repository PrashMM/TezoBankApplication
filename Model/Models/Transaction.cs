
namespace Models.Models;

public class Transaction
{
    public string Id { get; set; } = null!;

    public DateTime Time { get; set; }

    public double Amount { get; set; }

    public string UserAccountId { get; set; } = null!;

    public string? ReceiverAccountId { get; set; }

    public int Type { get; set; }

    public virtual Customer? ReceiverAccount { get; set; }

    public virtual Customer UserAccount { get; set; } = null!;

    public Transaction()
    {

    }
    public Transaction(DateTime time, double amount, Customer userAccount, TransferType type, Customer receiverAccount = null)
    {
        int typeInt = type == TransferType.Credit ? 0 : type == TransferType.Debit ? 1 : 2;

        Time = time;
        Amount = amount;
        //UserAccount = userAccount;
        Type = typeInt;
        //ReceiverAccount = receiverAccount;
    }
}
