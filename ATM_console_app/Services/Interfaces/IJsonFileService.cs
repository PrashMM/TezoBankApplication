

using ATM_console_app.Models;

namespace ATM_console_app.Services.Interfaces
{
    public interface IJsonFileService 
    {
        public void CheckForAccountHolderFile();
        public void CheckForTransactionFile();
        public List<AccountHolder> ReadHolderDetails();
        public void UpdateHolderDetails(List<AccountHolder> accountHolder);
        public List<Transaction> ReadTransactions();
        public void UpdateTransactionsData(List<Transaction> transactions);
    }
}
