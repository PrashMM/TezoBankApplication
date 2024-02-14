
using Data;
using Models;
using Services.Interfaces;

using Models.Models;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private static JsonFileService jsonFileService;

        public TransactionService()
        {
            jsonFileService = new JsonFileService();
        }
        public bool CheckTransactionHistoryIsEmptyOrNot()
        {
            return AccountData.Transactions != null && AccountData.Transactions.Count != 0;
        }

        public void AddToTransactionHistory(Transaction newTransaction)
        {
            // AccountData.Transactions.Add(newTransaction);
        }

        public List<Transaction> CurrentHolderTransactionHistory(Customer accountHolder)
        {
            //return AccountData.Transactions.Where(e => e.UserAccount.CustomerDetails.AccountDetails.AccountNumber.Equals(accountHolder.CustomerDetails.AccountDetails.AccountNumber)).ToList();
            using (var context = new AccountHolder1Context())
            {
                return context.Transactions.Where(e => e.UserAccountId.Equals(accountHolder.Id)).ToList();
            }
        }


        public void CreateTransactionHistory(int amount, Customer userAccount, TransferType type, Customer receieverAccount)
        {
            var transaction = new Transaction(DateTime.UtcNow, amount, userAccount, type, receieverAccount);
            //AddToTransactionHistory(transaction);
            //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            //jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);
            try
            {
                using (var context = new AccountHolder1Context())
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