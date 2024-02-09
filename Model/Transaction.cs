
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


        [ForeignKey("Customer")]
        public string UserAccountId { get; set; }
        public virtual Customer UserAccount { get; set; }


        [ForeignKey("Customer")]
        public string? ReceiverAccountId { get; set; }
        public virtual Customer? ReceiverAccount { get; set; }

        public TransferType Type { get; set; }


        public Transaction()
        {
        }

        public Transaction(DateTime time, double amount, Customer userAccount, TransferType type, Customer receiverAccount = null)
        {
            Time = time;
            Amount = amount;
            //UserAccount = userAccount;
            Type = type;
            //ReceiverAccount = receiverAccount;
        }
    }
}
