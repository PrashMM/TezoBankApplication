namespace Models
{
    public class Transaction
    {    
        public DateTime Time { get; set; }
        public double Amount { get; set; }
        public int UserAccountId { get; set; } // Foreign key--->    UserAccount
        public int? ReceiverAccountId { get; set; } // foreign key--->  ReceiverAccount
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
