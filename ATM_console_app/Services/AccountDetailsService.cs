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

        //AccountData accountData = new AccountData();
        public void AddHolderDetails(AccountHolder holder)
        {
            AccountData.AccountHoldersDetails.Add(holder);
        }

        //public bool CheckAccountExistence(string accountNumber)
        //{
        //    var holder =
        //    AccountData.AccountHoldersDetails.FirstOrDefault(holder => holder.AccountNumber == accountNumber);
        //    return holder != null; 
        //}
       

        //public double checkBalance(AccountHolder holder)
        //{
        //    return holder.InitialAmount;
        //}

        //public void creditAmount(AccountHolder holder, int creditAmount)
        //{

        //    holder.AccountDetails.Balance += creditAmount;
        //    Console.WriteLine(Constants.yourBalanceIs + holder.AccountDetails.Balance);
        //    Console.WriteLine("You are good to go. Thank You :) ");
        //}

        public void CreditAccount(AccountHolder holder, double creditAmount)
        {
            holder.AccountDetails.Balance += creditAmount;
        }


        public void debitAmount(AccountHolder holder, int debitAmount)
        {
             holder.AccountDetails.Balance -= debitAmount;
        }

       

        

    }
}
