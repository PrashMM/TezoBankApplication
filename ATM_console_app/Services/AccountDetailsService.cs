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


        //private AccountData accountData;

        AccountData accountData = new AccountData();
        public void AddHolderDetails(AccountHolder holder)
        {
            
            AccountData.AccountHoldersDetails.Add(holder);
          //  accountData.AccountHoldersDetails.Add(holder);
        }

        public bool CheckAccountExistence(String accountNumber)
        {
            
            var holder =
            AccountData.AccountHoldersDetails.FirstOrDefault(holder => holder.AccountNum == accountNumber);
            return holder != null; 
        }
        
    }
}
