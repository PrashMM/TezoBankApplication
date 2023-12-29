using ATM_console_app.Data;
using ATM_console_app.Models;
using ATM_console_app.Services;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

class Program
{
    private static AccountDetailsService accountDetailsService;
    private static UserInputOutput userInputOutputService;
    private static List<AccountHolder> accountHolderDetailsList;


    public static void Main()
    {
       InitializeServices();
       WelcomeMenu();
    }

    private static void InitializeServices()
    {
        accountDetailsService = new AccountDetailsService();
        userInputOutputService = new UserInputOutput();
        accountHolderDetailsList = new List<AccountHolder>();
    }

    public static void WelcomeMenu()
    {
        Console.WriteLine(Constants.welcomeMessage);
        Console.WriteLine(Constants.chooseOperation);

        if (int.TryParse(Console.ReadLine(), out var userInput))
        {

            try
            {
                switch (GetMainMenuByInput(userInput))
                {
                    case MainMenu.OpenAccount:
                        Console.WriteLine(Constants.enterFollowingDetails);
                        Console.WriteLine(Constants.seperateLine);

                        Console.WriteLine(Constants.enterFullName);
                        var fullName = Console.ReadLine();
                        Console.WriteLine(Constants.enterMobileNumber);
                        var mobileNumber = Console.ReadLine();
                        Console.WriteLine(Constants.enterAddress);
                        var address = Console.ReadLine();
                        Console.WriteLine(Constants.enterAadharCardNumber);
                        var aadharNumber = Console.ReadLine();

                        Console.WriteLine(Constants.seperateLine);

                        var accountHolderDetails = new AccountHolder(fullName, mobileNumber, address, aadharNumber, "", initialAmount: 1000, balance: 1000);
                        var dataIsCorrect = userInputOutputService.IsAccountDetailsCorrect(accountHolderDetails);

                        if (dataIsCorrect)
                        {
                            accountDetailsService.AddHolderDetails(accountHolderDetails);
                      
                         accountHolderDetailsList.Where(e => e.AccountDetails.AccountNumber == accountHolderDetails.AccountDetails.AccountNumber);
                           if (accountHolderDetailsList != null)
                           {
                              accountHolderDetailsList.Add(accountHolderDetails);
                           }
                        
                            string JSONresult = JsonConvert.SerializeObject(accountHolderDetailsList);
                            string path = @"C:\json\account.json";

                            if (File.Exists(path))
                            {
                                File.Delete(path);
                                using (var tw = new StreamWriter(path, true))
                                {
                                    tw.WriteLine(JSONresult.ToString());
                                    tw.Close();
                                }
                            }
                            else if (!File.Exists(path))
                            {
                                using (var tw = new StreamWriter(path, true))
                                {
                                    tw.WriteLine(JSONresult.ToString());
                                    tw.Close();
                                }
                            }
                            AccountOperation();
                        }
                        break;

                    case MainMenu.Exit:
                        return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            return;
        }
        

    }

    private static void AccountOperation()
    {
        Console.WriteLine(Constants.seperateLine);
        Console.WriteLine(Constants.enterAccountNumber);
        var accountNumber = Console.ReadLine();
        var accountHolder = accountDetailsService.GetAccountHolderByAccNumber(accountNumber);

        while (true)
         {
            if (accountHolder != null)
            {
                Console.WriteLine(Constants.seperateLine);
                Console.WriteLine(Constants.accountOperations);
                var userInput = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (GetATMService(userInput))
                    {
                        case ATMOperation.CheckBalance:
                             Console.WriteLine(Constants.checkAccountBalance);
                             Console.WriteLine($"{Constants.yourBalanceIs}  {accountHolder.AccountDetails.Balance}");
                             break;

                        case ATMOperation.Deposit:
                             var amountToDeposit = accountDetailsService.GetValidAmount();
                             accountDetailsService.PerformDeposit(accountHolder, amountToDeposit);                            
                             break;

                        case ATMOperation.Withdraw:
                            var amountToWithdraw = accountDetailsService.ValidateWithdrawAmount(accountNumber);
                            accountDetailsService.PerformWithdraw(accountHolder, amountToWithdraw);
                            break;

                        case ATMOperation.EditAccountDetails:
                            Console.WriteLine(Constants.editAccountDetails);
                            Console.WriteLine(Constants.enterToUpdateDetails);
                            int.TryParse(Console.ReadLine(), out var updateInput);
                            switch (UpdateDetailsByInput(updateInput))
                            {
                                case UpdateDetails.UpdateName:
                                    Console.WriteLine(Constants.enterNameToUpdate);
                                    var oldName = accountHolder.CustomerDetails.FullName;
                                    accountDetailsService.UpdateName(accountHolder);
                                    Console.WriteLine($"Your name '{oldName}' is updated to {accountHolder.CustomerDetails.FullName} ");
                                    break;

                                case UpdateDetails.UpdateAddress:
                                    Console.WriteLine(Constants.enterAddressToUpdate);
                                    var oldAddress = accountHolder.AddressDetails.AddressName;
                                    accountDetailsService.UpdateAddress(accountHolder);
                                    Console.WriteLine($"Your oldAddress '{oldAddress}' is updated to {accountHolder.AddressDetails.AddressName}");
                                    break;
                            }
                            break;

                        case ATMOperation.TakeHelp:
                            userInputOutputService.HelpService();
                            break;

                        case ATMOperation.OpenAccount:
                            WelcomeMenu();
                            break;

                        case ATMOperation.Exit:
                            Console.WriteLine(Constants.thankYou);
                            return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else {
                
                Console.WriteLine(Constants.accountNotFound);
                break;
       }
            AccountOperation();


    }
        

       
 }


    public static MainMenu GetMainMenuByInput(int value)
    {
        switch (value)
        {
            case 1:
                return MainMenu.OpenAccount;
            case 2:
                return MainMenu.Exit;
            default:
                return default;
        }
    }


    public static ATMOperation GetATMService(int value)
    {
        switch (value)
        {
            case 1:
                return ATMOperation.CheckBalance;
            case 2:
                return ATMOperation.Deposit;
            case 3:
                return ATMOperation.Withdraw;
            case 4:
                return ATMOperation.EditAccountDetails;
            case 5:
                return ATMOperation.TakeHelp;
            case 6:
                return ATMOperation.OpenAccount;
            case 7:
                return ATMOperation.Exit;
            default:
                return default;
        }
    }


    public static UpdateDetails UpdateDetailsByInput(int value)
    {

        switch (value)
        {
            case 1:
                return UpdateDetails.UpdateName;
            case 2:
                return UpdateDetails.UpdateAddress;
          default:
                return default;

        }

    }
}
