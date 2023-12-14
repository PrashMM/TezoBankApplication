using ATM_console_app.Data;
using ATM_console_app.Models;
using ATM_console_app.Services;
using System;
using System.ComponentModel.Design;

class Program
{
    private static AccountService accountService;
    private static AccountDetailsService accountDetailsService;
    private static UserInputOutput userInputOutputService;

    public static void Main()
    {
        InitializeServices();
        WelcomeMenu();
    }

    private static void InitializeServices()
    {
        accountService = new AccountService();
        accountDetailsService = new AccountDetailsService();
        userInputOutputService = new UserInputOutput();
    }

    public static void WelcomeMenu()
    {
        Console.WriteLine(Constants.welcomeMessage);
        Console.WriteLine(Constants.chooseOperation);
         
        int.TryParse(Console.ReadLine(), out var userInput);
        
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

                        var accountHolderDetails = new AccountHolder(fullName, mobileNumber, address, aadharNumber, "", initialAmount:1000,balance:1000 );
                        var dataIsCorrect = userInputOutputService.IsAccountDetailsCorrect(accountHolderDetails);

                           if (dataIsCorrect)
                            accountDetailsService.AddHolderDetails(accountHolderDetails);
                            AccountOperation();

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

    private static void AccountOperation()
    {
        Console.WriteLine(Constants.seperateLine);
        Console.WriteLine(Constants.enterAccountNumber);
        var accountNumber = Console.ReadLine();

        var isAccountExist = accountService.CheckAccountExistence(accountNumber);
        if (isAccountExist)
        {
            Console.WriteLine(Constants.seperateLine);
            Console.WriteLine(Constants.accountOperations);
        }
        else
        {
            Console.WriteLine(Constants.accountNotFound);
            return;
        }
            var userInput = Convert.ToInt32(Console.ReadLine());
            var accountHolder = AccountData.AccountHoldersDetails.Find(e => e.AccountDetails.AccountNumber.Equals(accountNumber));
        
        
       
      while (true)
         {
            if (accountHolder != null)
            {
                try
                {
                    switch (GetATMService(userInput))
                    {
                        case ATMOperation.CheckBalance:
                             Console.WriteLine(Constants.checkAccountBalance);
                             Console.WriteLine(Constants.yourBalanceIs + accountHolder.AccountDetails.Balance);
                             break;

                        case ATMOperation.Deposit:
                            Console.WriteLine(Constants.enterAmountToCredit);

                            if (int.TryParse(Console.ReadLine(), out var creditAmount) && creditAmount >= 0)
                            {
                                accountDetailsService.CreditAccount(accountHolder, creditAmount);
                                Console.WriteLine(Constants.yourBalanceIs + accountHolder.AccountDetails.Balance);
                                Console.WriteLine(Constants.thankYou);
                            }
                            else
                            {
                                Console.WriteLine("Please enter valid amount ");
                            }
                            
                            break;

                        case ATMOperation.Withdraw:
                            Console.WriteLine(Constants.enterAmountToDebit);

                            int.TryParse(Console.ReadLine(), out var debitAmount);
                            if (accountHolder.AccountDetails.Balance > debitAmount && debitAmount >= 0)
                            {
                                accountDetailsService.debitAmount(accountHolder, debitAmount);
                                Console.WriteLine(Constants.yourBalanceIs + accountHolder.AccountDetails.Balance);
                                Console.WriteLine(Constants.thankYou);
                            }
                            else
                            {
                                Console.WriteLine(Constants.insufficientBalance);
                            }

                            break;

                        case ATMOperation.EditAccountDetails:
                            Console.WriteLine(Constants.editAccountDetails);
                            Console.WriteLine(Constants.enterToUpdateDetails);
                            int.TryParse(Console.ReadLine(), out var updateInput);
                            switch(UpdateDetailsByInput(updateInput))
                            {
                                case UpdateDetails.UpdateName:
                                    Console.WriteLine(Constants.enterNameToUpdate);
                                    userInputOutputService.updateName(accountHolder);
                                    break;

                                case UpdateDetails.UpdateAddress:
                                    Console.WriteLine(Constants.enterAddressToUpdate);
                                    userInputOutputService.updateAddress(accountHolder);
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
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else {
                
                Console.WriteLine(Constants.accountNotFound);
       }
                AccountOperation();


     }

        
       
        }

    public static MainMenu GetMainMenuByInput(int value)
    {
        if (value == 1)
            return MainMenu.OpenAccount;
        else if (value == 2)
            return MainMenu.Exit;
        else
            return default;
    }

    public static ATMOperation GetATMService(int value)
    {
        if (value == 1)
            return ATMOperation.CheckBalance;
        else if (value == 2)
            return ATMOperation.Deposit;
        else if (value == 3)
            return ATMOperation.Withdraw;
        else if (value == 4)
            return ATMOperation.EditAccountDetails;
        else if (value == 5)
            return ATMOperation.TakeHelp;
        else if (value == 6)
            return ATMOperation.OpenAccount;
        else if (value == 7)
            return ATMOperation.Exit;
        else
            return default;
    }

    public static UpdateDetails UpdateDetailsByInput(int value)
    {
        if (value == 1)
            return UpdateDetails.UpdateName;
        else if (value == 2)
            return UpdateDetails.UpdateAddress;
        else
            return default;
    }
}
