

using Data;
using Models;
using Services.Interfaces;

namespace Services
{

    public class AccountDetailsService : IAccountDetailsService
    {
        private static TransactionService transactionService;
        private static JsonFileService jsonFileService;
        private static DatabaseService databaseService;

        public AccountDetailsService()
        {
            transactionService = new TransactionService();
            jsonFileService = new JsonFileService();
            databaseService = new DatabaseService();
        }
        public void AddHolderDetails(AccountHolder holder)
        {
            AccountData.AccountHoldersDetails.Add(holder);
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            databaseService.AddHoldersInsideTable(holder);
        }        

        public void UpdateName(AccountHolder accountHolder, string newName)
        {
            accountHolder.CustomerDetails.FullName = newName ?? "";
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            databaseService.UpdateHolderName(accountHolder, newName);
        }

        public void UpdateAddress(AccountHolder accountHolder, string newAddress)
        {
            accountHolder.CustomerDetails.AddressDetails.Location = newAddress ?? "";
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            databaseService.UpdateHolderAddress(accountHolder, newAddress);
        } 

        public AccountHolder GetAccountHolderByAccNumber(string accountNum)
        {
            return AccountData.AccountHoldersDetails.Find(e => e.AccountDetails.AccountNumber.Equals(accountNum));
        }


        public void PerformDeposit(AccountHolder accountHolder, int amount)
        {
            accountHolder.AccountDetails.Balance += amount;
            transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Credit, null);
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);
            databaseService.UpdateDepositAmount(accountHolder, amount);
        }

        public void PerformWithdraw(AccountHolder accountHolder, int amount)
        {
            accountHolder.AccountDetails.Balance -= amount;
            transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Debit, null);
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);
            databaseService.UpdateWithdrawAmount(accountHolder, amount);      
        }

        public bool MobileNumberExistsOrNot(string number)
        {
            return AccountData.AccountHoldersDetails.Where(e => e.CustomerDetails.MobileNumber.Equals(number)).Any();
        }

        public void PerformTransferAmount(AccountHolder accountHolder, AccountHolder receiverAccount, int transferAmount)
        {
            accountHolder.AccountDetails.Balance -= transferAmount;
            receiverAccount.AccountDetails.Balance += transferAmount;
            transactionService.CreateTransactionHistory(transferAmount, accountHolder, TransferType.Transfer, receiverAccount);
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);
            databaseService.UpdateTransferAmount(accountHolder, receiverAccount, transferAmount);
        }

        public void UpdateLastModifiedTime(AccountHolder accountHolder)
        {
            accountHolder.LastModifiedOn = DateTime.UtcNow;
            databaseService.UpdateLastModificationTime(accountHolder);
        }
    }
}
