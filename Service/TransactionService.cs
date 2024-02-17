
using Data;
using Models;
using Services.Interfaces;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        public bool CheckTransactionHistoryIsEmptyOrNot()
        {
            using (var context = new TezoBankDbContext())
            {
                return context.Transactions.Count() != 0 && context.Transactions != null;
            }
        }

        public List<Transaction> CurrentHolderTransactionHistory(AccountHolder accountHolder)
        {
            using (var context = new TezoBankDbContext())
            {
                return context.Transactions.Where(e => e.UserAccountId.Equals(accountHolder.Id)).ToList();
            }
        }


        public void CreateTransactionHistory(int amount, AccountHolder userAccount, TransferType type, AccountHolder receieverAccount)
        {
            var transaction = new Transaction(DateTime.UtcNow, amount, userAccount, type, receieverAccount);
            try
            {
                using (var context = new TezoBankDbContext())
                {
                    transaction.Id = Guid.NewGuid().ToString();
                    transaction.UserAccountId = userAccount.Id;
                    transaction.ReceiverAccountId = (receieverAccount == null) ? userAccount.Id : receieverAccount.Id;

                    context.Transactions.Add(transaction);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

        }

    }
}
