namespace Models
{
    public class Transaction
    {    
        public DateTime Time { get; set; }
        public double Amount { get; set; }
        public string UserAccountId { get; set; } // foreign key 
        public string? ReceiverAccountId { get; set; } // foreign key 
        public TransferType Type { get; set; }

       
        public virtual AccountHolder UserAccount { get; set; }
        public virtual AccountHolder ReceiverAccount { get; set; }


        public Transaction( DateTime time, double amount, AccountHolder userAccount, TransferType type, AccountHolder receiverAccount = null)
        {
            Time = time;
            Amount = amount;
            UserAccount = userAccount;
            Type = type;
            ReceiverAccount = receiverAccount;
        }
    }
}
