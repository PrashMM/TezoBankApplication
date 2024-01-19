namespace Models
{
    public class Transaction
    {
        public DateTime Time { get; set; }
        public double Amount { get; set; }
        public AccountHolder UserAccount { get; set; }
        public AccountHolder ReceiverAccount { get; set; }
        public TransferType Type { get; set; }

        public Transaction(DateTime time, double amount, AccountHolder userAccount, TransferType type, AccountHolder receiverAccount = null)
        {
            Time = time;
            Amount = amount;
            UserAccount = userAccount;
            Type = type;
            ReceiverAccount = receiverAccount;
        }
    }
}
