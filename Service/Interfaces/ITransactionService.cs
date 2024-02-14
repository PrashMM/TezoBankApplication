using Models;
using Models.Models;

namespace Services.Interfaces
{
    public interface ITransactionService
    {
        public bool CheckTransactionHistoryIsEmptyOrNot();
        public void AddToTransactionHistory(Transaction newTransaction);
        public List<Transaction> CurrentHolderTransactionHistory(Customer accountHolder);
        public void CreateTransactionHistory(int amount, Customer holder, TransferType type, Customer receieverAccount);
    }
}
