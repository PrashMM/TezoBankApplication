using ATM_console_app.Data;
using ATM_console_app.Models;
using Newtonsoft.Json;

namespace ATM_console_app.Services
{

    class AccountDetailsService
    {
        public void AddHolderDetails(AccountHolder holder)
        {
            AccountData.AccountHoldersDetails.Add(holder);     
        }

        public void DepositFunds(AccountHolder holder, double creditAmount)
        {
            holder.AccountDetails.Balance += creditAmount;
        }


        public void WithdrawFunds(AccountHolder holder, int debitAmount)
        {
             holder.AccountDetails.Balance -= debitAmount;
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
           
            DepositFunds(accountHolder, amount);
            Console.WriteLine($"{Constants.yourBalanceIs} {accountHolder.AccountDetails.Balance}");
            Console.WriteLine(Constants.thankYou);
            return accountHolder;
        }

        public AccountHolder PerformWithdraw(AccountHolder accountHolder, int amount)
        {
            WithdrawFunds(accountHolder, amount);
            Console.WriteLine($"{Constants.yourBalanceIs} {accountHolder.AccountDetails.Balance}");
            Console.WriteLine(Constants.thankYou);
            return accountHolder;
        }

        public void DisplayAllAccountHolders()
        {
            Console.WriteLine("Account Holders : ");
            foreach (var accountHolder in AccountData.AccountHoldersDetails)
            {
                Console.WriteLine(Constants.seperateLine);
                Console.WriteLine($"Account Number: {accountHolder.AccountDetails.AccountNumber}");
                Console.WriteLine($"Full Name: {accountHolder.CustomerDetails.FullName}");
                Console.WriteLine($"Mobile Number: {accountHolder.CustomerDetails.MobileNumber}");
                Console.WriteLine($"Balance: {accountHolder.AccountDetails.Balance}");
                Console.WriteLine(Constants.seperateLine);
                Console.WriteLine();
            }
        }
    }
}
