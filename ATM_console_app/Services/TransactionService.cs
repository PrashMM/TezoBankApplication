using ATM_console_app.Data;
using ATM_console_app.Models;
using ATM_console_app.Services.Interfaces;

namespace ATM_console_app.Services
{
    public class TransactionService : ITransactionService
    {
        public bool CheckTransactionHistoryIsEmptyOrNot()
        {
           return AccountData.Transactions.Count != 0;
        }

        public void AddToTransactionHistory(Transaction newTransaction)
        {
            AccountData.Transactions.Add(newTransaction);
        }

        public List<Transaction> CurrentHolderTransactionHistory(AccountHolder accountHolder)
        {
            return AccountData.Transactions.Where(e => e.UserAccount == accountHolder).ToList();
        }

    }
}
