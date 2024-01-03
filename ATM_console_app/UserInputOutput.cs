using ATM_console_app.Models;
using ATM_console_app.Services;

class UserInputOutput
    {
    public AccountDetailsService accountDetailsService;

    public UserInputOutput()
    {
        accountDetailsService = new AccountDetailsService();
    }
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
            Console.WriteLine($"*+*+* Account Number: {GenerateAccountNumber(holder)} \n*+*+* Name: {holder.CustomerDetails.FullName} \n*+*+* Mobile Number:{holder.CustomerDetails.MobileNumber} \n*+*+* Location: {holder.CustomerDetails.AddressDetails.Location} \n*+*+* Pincode: {holder.CustomerDetails.AddressDetails.Pincode} \n*+*+* Aadhar Number = {holder.CustomerDetails.AadharNumber} ");
            Console.WriteLine(Constants.ifCorrectPressYToProcced);
        }

   
        public string GenerateAccountNumber(AccountHolder holder)
        {
            var uniqueValue = holder.CustomerDetails.MobileNumber.ToString();
            holder.AccountDetails.AccountNumber = $"ACCX{holder.CustomerDetails.FullName[7]}{uniqueValue[0]}{uniqueValue[1]}";
            return holder.AccountDetails.AccountNumber;
        }


    public int GetValidAmount()
    {
        Console.WriteLine(Constants.enterAmountToCredit);
        if (int.TryParse(Console.ReadLine(), out var amount) && amount > 0)
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
        var accountHolder = accountDetailsService.GetAccountHolderByAccNumber(accountNum);
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

    public void HelpService()
    {
        Console.WriteLine(Constants.writeEmailandQuery);
        Console.ReadLine();
        Console.WriteLine(Constants.teamWillReachOutToYou);
    }

    
}

