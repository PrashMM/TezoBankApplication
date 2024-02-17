
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Transaction
    {
        [Key]
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public double Amount { get; set; }


        [ForeignKey("AccountHolders")]
        public string UserAccountId { get; set; }
        public virtual AccountHolder UserAccount { get; set; }


        [ForeignKey("AccountHolders")]
        public string? ReceiverAccountId { get; set; }
        public virtual AccountHolder? ReceiverAccount { get; set; }

        public TransferType Type { get; set; }
        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Transaction()
        {
        }

        public Transaction(DateTime time, double amount, AccountHolder userAccount, TransferType type, AccountHolder receiverAccount = null)
        {
            Time = time;
            Amount = amount;
            //UserAccount = userAccount;
            Type = type;
            //ReceiverAccount = receiverAccount;
        }
    }
}
