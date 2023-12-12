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

        public int checkBalance(AccountHolder holder)
        {
            return holder.InitialAmount;
        }

        public void creditAmount(AccountHolder holder, int amount)
        {
         AccountHolder Accholder = new   AccountHolder(holder.FullName, holder.MobileNum, holder.Address, holder.AadharNum, holder.AccountNum, amount);
            AccountData.AccountHoldersDetails.Add(Accholder);
            
           // AccountData.AccountHoldersDetails.Where(holder => holder.InitialAmount == holder.InitialAmount + amount);
           
        }

    }
}
