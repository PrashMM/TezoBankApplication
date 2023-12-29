using ATM_console_app.Data;
using ATM_console_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void UpdateName(AccountHolder accountHolder)
        {
            var newName = Console.ReadLine();
            accountHolder.CustomerDetails.FullName = newName ?? "";
            UpdateJson(accountHolder);
        }

        public void UpdateAddress(AccountHolder accountHolder)
        {
            var newAddress = Console.ReadLine();
            accountHolder.AddressDetails.AddressName = newAddress ?? "";
            UpdateJson(accountHolder);
        }

        public AccountHolder GetAccountHolderByAccNumber(String accountNum) 
        {
            var accountHolder = AccountData.AccountHoldersDetails.Find(e => e.AccountDetails.AccountNumber.Equals(accountNum));
            return accountHolder;
        }


        public int GetValidAmount()
        {
            Console.WriteLine(Constants.enterAmountToCredit);
            if (int.TryParse(Console.ReadLine(), out var amount))
            {
                return amount;
            }
            else
            {
                 Console.WriteLine(Constants.enterValidAmount);
                 return 0;
            }
        }

        public int ValidateWithdrawAmount(string accountNum)
        {
            var accountHolder = GetAccountHolderByAccNumber(accountNum);
            Console.WriteLine(Constants.enterAmountToDebit);
            if (int.TryParse(Console.ReadLine(), out var amount))
            {
                return amount > 0 && accountHolder.AccountDetails.Balance > amount ? amount : 0;
            }
            else
            {
                Console.WriteLine(Constants.enterValidAmount);
                return 0;
            }
        }

        public void PerformDeposit(AccountHolder accountHolder, int amount)
        {
            DepositFunds(accountHolder, amount);
            Console.WriteLine($"{Constants.yourBalanceIs} {accountHolder.AccountDetails.Balance}");
            Console.WriteLine(Constants.thankYou);
            UpdateJson(accountHolder);
        }

        public void PerformWithdraw(AccountHolder accountHolder, int amount)
        {
            WithdrawFunds(accountHolder, amount);
            Console.WriteLine($"{Constants.yourBalanceIs} {accountHolder.AccountDetails.Balance}");
            Console.WriteLine(Constants.thankYou);
            UpdateJson(accountHolder);
        }

        public void UpdateJson(AccountHolder accountHolder)
        {
            
            string updatedJson = JsonConvert.SerializeObject(accountHolder);
            File.WriteAllText(@"C:\json\account.json", updatedJson);
            
        }
    }
}
