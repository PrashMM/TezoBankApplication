using ATM_console_app.Models;
using ATM_console_app.Services;
using System;

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

        while (true)
        {
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

                        var accountHolderDetails = new AccountHolder(fullName, mobileNum, address, aadharNum, "");
                        var dataIsCorrect = accountService.IsAccountDetailsCorrect(accountHolderDetails);

                        if (dataIsCorrect)
                        {
                            accountDetailsService.AddHolderDetails(accountHolderDetails);
                            Console.WriteLine(Constants.seperateLine);
                            Console.WriteLine(Constants.enterAccountNum);
                            var accountNum = Console.ReadLine();
                            var isAccountExist = accountService.CheckAccountExist(accountNum);
                            if (isAccountExist)
                            {


                                AccountOperation(accountHolderDetails.AccountNum);
                            }
                        }
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
    }

    private void AccountOperation(string accountNumber)
    {
        
        //Console.WriteLine(Constants.seperateLine);
        //Console.WriteLine(Constants.enterAccountNum);
        //var accountNum = Console.ReadLine();
        //var isAccountExist = accountService.CheckAccountExist(accountNum);

        
        
            Console.WriteLine(Constants.seperateLine);
            Console.WriteLine(Constants.accountOperations);
            var userInput = Convert.ToInt32(Console.ReadLine());

            while (true)
        {
                try
                {
                    switch (GetATMService(userInput))
                    {
                        case ATMOperation.ToCreditAmount:
                            Console.WriteLine(Constants.enterAmountToCredit);
                            var creditAmount = Console.ReadLine();
                        
                            break;

                        case ATMOperation.DebitAmount:
                            Console.WriteLine(Constants.enterAmountToDebit);
                            var debitAmount = Console.ReadLine();
                           
                            break;

                        case ATMOperation.EditAccountDetails:
                            Console.WriteLine(Constants.editAccountDetails);
                       
                            break;

                        case ATMOperation.TakeHelp:
                            accountService.HelpService();
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
            return ATMOperation.ToCreditAmount;
        else if (value == 2)
            return ATMOperation.DebitAmount;
        else if (value == 3)
            return ATMOperation.EditAccountDetails;
        else if (value == 4)
            return ATMOperation.TakeHelp;
        else
            return ATMOperation.Exit;
    }
}
