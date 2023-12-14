using ATM_console_app.Data;
using ATM_console_app.Models;
using ATM_console_app.Services;
using System;
using System.ComponentModel.Design;

class Program
{
    private AccountService accountService;
    private AccountDetailsService accountDetailsService;

    public Program()
    {
        this.accountService = new AccountService();
        this.accountDetailsService = new AccountDetailsService();
    }

    public static void Main()
    {
        Program program = new Program();
        program.WelcomeMenu();
    }

    private void WelcomeMenu()
    {
        Console.WriteLine(Constants.welcomeMessage);
        Console.WriteLine(Constants.chooseOperation);

        var userInput = Convert.ToInt32(Console.ReadLine());

          try
            {
                switch (GetMainMenuByInput(userInput))
                {
                    case MainMenu.ToOpenAccount:
                        Console.WriteLine(Constants.enterFollowingDetails);
                        Console.WriteLine(Constants.seperateLine);
                        Console.WriteLine(Constants.enterFullName);
                        var fullName = Console.ReadLine();
                        Console.WriteLine(Constants.enterMobileNum);
                        var mobileNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Constants.enterAddress);
                        var address = Console.ReadLine();
                        Console.WriteLine(Constants.enterAadharCardNum);
                        var aadharNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Constants.seperateLine);

                        var accountHolderDetails = new AccountHolder(fullName, mobileNum, address, aadharNum, "", initialAmount:1000);
                        var dataIsCorrect = accountService.IsAccountDetailsCorrect(accountHolderDetails);

                        if (dataIsCorrect)
                            accountDetailsService.AddHolderDetails(accountHolderDetails);
                            AccountOperation();

                        break;

                    case MainMenu.ToExit:
                         return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        

    }

    private void AccountOperation()
    {
        Console.WriteLine(Constants.seperateLine);
        Console.WriteLine(Constants.enterAccountNum);
        var accountNum = Console.ReadLine();

        var isAccountExist = accountService.CheckAccountExist(accountNum);
        if (isAccountExist)
        {
            Console.WriteLine(Constants.seperateLine);
            Console.WriteLine(Constants.accountOperations);
        }
        else
        {
            Console.WriteLine(Constants.accountNotFound);
        }
            var userInput = Convert.ToInt32(Console.ReadLine());
            var accountHolder = AccountData.AccountHoldersDetails.Find(e => e.AccountNum.Equals(accountNum));
        
        
       
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
                             Console.WriteLine(Constants.yourBalanceIs + accountHolder.InitialAmount);
                             break;

                        case ATMOperation.ToCreditAmount:
                            Console.WriteLine(Constants.enterAmountToCredit);
                            var creditAmount = int.Parse(Console.ReadLine());
                            accountDetailsService.creditAmount(accountHolder, creditAmount);
                            break;

                        case ATMOperation.DebitAmount:
                            Console.WriteLine(Constants.enterAmountToDebit);
                            var debitAmount = int.Parse(Console.ReadLine());
                            accountDetailsService.debitAmount(accountHolder, debitAmount);
                            break;

                        case ATMOperation.EditAccountDetails:
                            Console.WriteLine(Constants.editAccountDetails);
                            Console.WriteLine(Constants.enterToUpdateDetails);
                            var updateInput = int.Parse(Console.ReadLine());
                            switch(UpdateDetailsByInput(updateInput))
                            {
                                case UpdateDetails.ToUpdateName:
                                    Console.WriteLine(Constants.enterNameToUpdate);
                                    accountDetailsService.updateName(accountHolder);
                                    
                                    break;
                                case UpdateDetails.ToUpdateAddress:
                                    Console.WriteLine(Constants.enterAddressToUpdate);
                                    accountDetailsService.updateAddress(accountHolder);
                                    break;
                            }
                            break;

                        case ATMOperation.TakeHelp:
                            accountService.HelpService();
                            break;

                        case ATMOperation.ToOpenAccount:
                            WelcomeMenu();
                            break;

                        case ATMOperation.Exit:
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
       }
                AccountOperation();


     }

        
       
        }

    public static MainMenu GetMainMenuByInput(int value)
    {
        if (value == 1)
            return MainMenu.ToOpenAccount;
        else if (value == 2)
            return MainMenu.ToExit;
        else
            return default;
    }

    public static ATMOperation GetATMService(int value)
    {
        if (value == 1)
            return ATMOperation.CheckBalance;
        else if (value == 2)
            return ATMOperation.ToCreditAmount;
        else if (value == 3)
            return ATMOperation.DebitAmount;
        else if (value == 4)
            return ATMOperation.EditAccountDetails;
        else if (value == 5)
            return ATMOperation.TakeHelp;
        else if (value == 6)
            return ATMOperation.ToOpenAccount;
        else
            return default;
    }

    public static UpdateDetails UpdateDetailsByInput(int value)
    {
        if (value == 1)
            return UpdateDetails.ToUpdateName;
        else if (value == 2)
            return UpdateDetails.ToUpdateAddress;
        else
            return default;
    }
}
