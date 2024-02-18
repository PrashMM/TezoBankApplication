using Models;
using Models.Models;

namespace Services.Interfaces
{
    public interface ITransactionService
    {
        public bool CheckTransactionHistoryIsEmptyOrNot();
        public List<Transaction> CurrentHolderTransactionHistory(AccountHolder accountHolder);
        public void CreateTransactionHistory(int amount, AccountHolder holder, TransferType type, AccountHolder receieverAccount);
    }
}