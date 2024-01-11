using ATM_console_app.Data;
using ATM_console_app.Models;
using ATM_console_app.Services.Interfaces;

namespace ATM_console_app.Services
{

    class AccountDetailsService : IAccountDetailsService
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
            return AccountData.AccountHoldersDetails.Find(e => e.AccountDetails.AccountNumber.Equals(accountNum));
        }


        public AccountHolder PerformDeposit(AccountHolder accountHolder, int amount)
        {
            accountHolder.AccountDetails.Balance += amount;
            return accountHolder;
        }

        public AccountHolder PerformWithdraw(AccountHolder accountHolder, int amount)
        {
            accountHolder.AccountDetails.Balance -= amount;
            return accountHolder;
        }

        public bool MobileNumberExistsOrNot(string number)
        {
            return AccountData.AccountHoldersDetails.Where(e => e.CustomerDetails.MobileNumber == number).Any();
        }
    }
}

