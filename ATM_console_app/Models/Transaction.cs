using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    public class Transaction
    {
        public DateTime TransactionTime { get; set; }
        public double TransactionAmount { get; set; }
        public AccountHolder UserAccount { get; set; }
        public AccountHolder ReceiverAccount { get; set; }
        public TransferType Type { get; set; }

        public Transaction(DateTime transactionTime, double transactionAmount, AccountHolder userAccount, TransferType type, AccountHolder receiverAccount = null)
        {
            TransactionTime = transactionTime;
            TransactionAmount = transactionAmount;
            UserAccount = userAccount;
            Type = type;
            ReceiverAccount = receiverAccount;
        }
    }
}
