using ATM_console_app.Data;
using ATM_console_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Services
{
    
    class AccountDetailsService
    {

        AccountData accountData = new AccountData();
        public void AddHolderDetails(AccountHolder holder)
        {
             AccountData.AccountHoldersDetails.Add(holder);
        }

        public bool CheckAccountExistence(String accountNumber)
        {
            var holder =
            AccountData.AccountHoldersDetails.FirstOrDefault(holder => holder.AccountNum == accountNumber);
            return holder != null; 
        }

        public double checkBalance(AccountHolder holder)
        {
            return holder.InitialAmount;
        }

        public void creditAmount(AccountHolder holder, int creditAmount)
        {
            holder.InitialAmount += creditAmount;
            Console.WriteLine(Constants.yourBalanceIs + holder.InitialAmount);
            Console.WriteLine("You are good to go. Thank You :) ");
        }

        public void debitAmount(AccountHolder holder, int debitAmount)
        {
            if (holder.InitialAmount > debitAmount)
            {
                holder.InitialAmount -= debitAmount;
                Console.WriteLine(Constants.yourBalanceIs + holder.InitialAmount);
                Console.WriteLine("You are good to go. Thank You :) ");
            }
            else
            {
                Console.WriteLine("Insufficient balance :( ");
            }
        }

        public void updateName(AccountHolder accountHolder)
        {
            var oldName = accountHolder.FullName;
            var newName = Console.ReadLine();
            accountHolder.FullName = newName ?? "";
            Console.WriteLine($"Your name '{oldName}' is updated to " + accountHolder.FullName);
        }

        public void updateAddress(AccountHolder accountHolder)
        {
            var oldAddress = accountHolder.Address;
            var newAddress = Console.ReadLine();
            accountHolder.Address = newAddress ?? "";
            Console.WriteLine($"Your oldAddress '{oldAddress}' is updated to " + accountHolder.Address);
        }

        

    }
}
