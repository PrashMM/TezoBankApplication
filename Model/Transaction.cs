
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }
        public DateTime Time { get; set; }
        public double Amount { get; set; }

        public string UserAccountId { get; set; }

       // public AccountHolder UserAccount { get; set; }
        public string? ReceiverAccountId { get; set; }
       //public AccountHolder? ReceiverAccount { get; set; }
        public TransferType Type { get; set; }


        public Transaction()
        {
        }

        public Transaction(DateTime time, double amount, AccountHolder userAccount, TransferType type, AccountHolder receiverAccount = null)
        {
            Time = time;
            Amount = amount;
           // UserAccount = userAccount;
            Type = type;
           // ReceiverAccount = receiverAccount;
        }
    }
}
