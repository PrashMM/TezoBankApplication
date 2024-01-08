using ATM_console_app.Data;
using ATM_console_app.Models;

namespace ATM_console_app.Services
{

    class AccountDetailsService
    {
           
        public void AddHolderDetails(AccountHolder holder)
        {
            AccountData.AccountHoldersDetails.Add(holder);     
        }

        public AccountHolder UpdateName(AccountHolder accountHolder, string newName)
        {
            accountHolder.CustomerDetails.FullName = newName ?? "";
            return accountHolder;
        }

        public AccountHolder UpdateAddress(AccountHolder accountHolder, string newAddress)
        {
            accountHolder.CustomerDetails.AddressDetails.Location = newAddress ?? "";
            return accountHolder;
        }

        public AccountHolder GetAccountHolderByAccNumber(String accountNum) 
        {
            var accountHolder = AccountData.AccountHoldersDetails.Find(e => e.AccountDetails.AccountNumber.Equals(accountNum));
            return accountHolder;
        }


        public AccountHolder PerformDeposit(AccountHolder accountHolder, int amount)
        {
            accountHolder.AccountDetails.Balance += amount;
            UserInputOutput.printAmount(accountHolder);
            return accountHolder;
        }

        public AccountHolder PerformWithdraw(AccountHolder accountHolder, int amount)
        {
            accountHolder.AccountDetails.Balance -= amount;
            UserInputOutput.printAmount(accountHolder);
            return accountHolder;
        }

    }
}
