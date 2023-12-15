using ATM_console_app.Models;
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
            return (dataIsCorrect == "Y" || dataIsCorrect == "y");
        }

        public void ShowAccountDetails(AccountHolder holder)
        {
            Console.WriteLine(Constants.checkAllDetails);
            Console.WriteLine($"*+*+* Account Number: {GenerateAccountNumber(holder)} \n*+*+* Name: {holder.CustomerDetails.FullName} \n*+*+* Mobile Number:{holder.CustomerDetails.MobileNumber} \n*+*+* Address: {holder.CustomerDetails.Address} \n*+*+* Aadhar Number = {holder.CustomerDetails.AadharNumber} ");
            Console.WriteLine(Constants.ifCorrectPressYToProcced);
        }

   
        public string GenerateAccountNumber(AccountHolder holder)
        {
            if (!string.IsNullOrEmpty(holder.CustomerDetails.FullName))
           {
            holder.AccountDetails.AccountNumber = $"ATM0{holder.CustomerDetails.FullName[5]}{holder.CustomerDetails.MobileNumber}";
            return holder.AccountDetails.AccountNumber;
           }
             else
          {
            Console.WriteLine(Constants.UnableToCreateAccountNumber);
            return null;
          }
        }




    public void updateName(AccountHolder accountHolder)
    {
        var newName = Console.ReadLine();
        accountHolder.CustomerDetails.FullName = newName ?? "";
    }

    public void updateAddress(AccountHolder accountHolder)
    {
        var newAddress = Console.ReadLine();
        accountHolder.CustomerDetails.Address = newAddress ?? "";
    }

    public void HelpService()
    {
        Console.WriteLine(Constants.writeEmailandQuery);
        Console.ReadLine();
        Console.WriteLine(Constants.teamWillReachOutToYou);
    }
}

