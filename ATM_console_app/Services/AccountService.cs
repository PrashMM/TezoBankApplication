using ATM_console_app.Data;
using ATM_console_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ATM_console_app.Services
{
     class AccountService
    {
        //AccountDetailsService accountDetailsService;
        //AccountDetailsService accountDetailsService = new AccountDetailsService();

        private AccountDetailsService accountDetailsService = new AccountDetailsService();

        //rogram program = new Program();
        //AccountService externalAccountService = program.accountService;
        public bool IsAccountDetailsCorrect(AccountHolder holder)
        {
            
            ShowAccountDetails(holder);
            var dataIsCorrect = Console.ReadLine();
            return (dataIsCorrect == "Y" || dataIsCorrect == "y");
            

        }
        
        public void ShowAccountDetails(AccountHolder holder)
        {
            Console.WriteLine(Constants.checkAllDetails);
            Console.WriteLine($"* Account Number: {CreateAccountNumber(holder)}\n* Name: {holder.FullName}\n* Mobile Number:{holder.MobileNum}\n* Address: {holder.Address}\n* Aadhar Number = {holder.AadharNum} ");
            Console.WriteLine(Constants.ifCorrectPressYToProcced);
        }

        public String CreateAccountNumber(AccountHolder holder)
        {
          holder.AccountNum = $"ATM0{holder.FullName[0] }{holder.MobileNum}";
          return holder.AccountNum;
        }

        public bool CheckAccountExist(string accountNum)
        {
            
            return accountDetailsService.CheckAccountExistence(accountNum);
        }

        public void HelpService()
        {
            Console.WriteLine(Constants.writeEmailandQuery);
            Console.ReadLine();
            Console.WriteLine(Constants.teamWillReachOutToYou);
        } 
    }
}
