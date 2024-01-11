using ATM_console_app.Data;
using ATM_console_app.Models;
using ATM_console_app.Services.Interfaces;

namespace ATM_console_app.Services
{

    class AccountDetailsService : IAccountDetailsService
    {
        private static TransactionService transactionService;
        private static JsonFileService jsonFileService;

        public AccountDetailsService()
        {
            transactionService = new TransactionService();
            jsonFileService = new JsonFileService();
        }
        public void AddHolderDetails(AccountHolder holder)
        {
            AccountData.AccountHoldersDetails.Add(holder);
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
        }

        public void UpdateName(AccountHolder accountHolder, string newName)
        {
            accountHolder.CustomerDetails.FullName = newName ?? "";
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
        }

        public void UpdateAddress(AccountHolder accountHolder, string newAddress)
        {
            accountHolder.CustomerDetails.AddressDetails.Location = newAddress ?? "";
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
        }

        public AccountHolder GetAccountHolderByAccNumber(String accountNum) 
        {
            return AccountData.AccountHoldersDetails.Find(e => e.AccountDetails.AccountNumber.Equals(accountNum));
        }


        public void PerformDeposit(AccountHolder accountHolder, int amount)
        {
            accountHolder.AccountDetails.Balance += amount;
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);
        }

        public void PerformWithdraw(AccountHolder accountHolder, int amount)
        {
            accountHolder.AccountDetails.Balance -= amount;
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);
        }

        public bool MobileNumberExistsOrNot(string number)
        {
            return AccountData.AccountHoldersDetails.Where(e => e.CustomerDetails.MobileNumber.Equals(number)).Any();
        }

        public void PerformTransferAmount(AccountHolder accountHolder, AccountHolder receiverAccount,int transferAmount)
        {   
                PerformWithdraw(accountHolder, transferAmount);
                PerformDeposit(receiverAccount, transferAmount);            
        }

        public void UpdateLastModifiedTime(AccountHolder accountHolder)
        {
            accountHolder.LastModifiedOn = DateTime.UtcNow;
        }
    }
}

