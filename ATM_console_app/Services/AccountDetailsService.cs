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

    }
}
