using ATM_console_app.Models;
using ATM_console_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 class UserInputOutput
    {
        public bool IsAccountDetailsCorrect(AccountHolder holder)
        {
            ShowAccountDetails(holder);
            var dataIsCorrect = Console.ReadLine();
            Console.WriteLine(Constants.seperateLine);
            return dataIsCorrect.ToLower().Equals("y");
        }

        public void ShowAccountDetails(AccountHolder holder)
        {
            Console.WriteLine(Constants.checkAllDetails);
            Console.WriteLine($"*+*+* Account Number: {GenerateAccountNumber(holder)} \n*+*+* Name: {holder.CustomerDetails.FullName} \n*+*+* Mobile Number:{holder.CustomerDetails.MobileNumber} \n*+*+* Address: {holder.CustomerDetails.Address} \n*+*+* Aadhar Number = {holder.CustomerDetails.AadharNumber} ");
            Console.WriteLine(Constants.ifCorrectPressYToProcced);
        }

   
        public string GenerateAccountNumber(AccountHolder holder)
        {
            holder.AccountDetails.AccountNumber = $"ATM0{holder.CustomerDetails.FullName[7]}{holder.CustomerDetails.MobileNumber}";
            return holder.AccountDetails.AccountNumber;
        }




    
    public void HelpService()
    {
        Console.WriteLine(Constants.writeEmailandQuery);
        Console.ReadLine();
        Console.WriteLine(Constants.teamWillReachOutToYou);
    }

    
}

