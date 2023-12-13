using ATM_console_app.Data;
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
                        {
                            accountDetailsService.AddHolderDetails(accountHolderDetails);
                            Console.WriteLine(Constants.seperateLine);
                            Console.WriteLine(Constants.enterAccountNum);
                            var accountNum = Console.ReadLine();
                            var isAccountExist = accountService.CheckAccountExist(accountNum);
                            if (isAccountExist)
                            {
                                AccountOperation(accountHolderDetails, accountNum);
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

    private void AccountOperation(AccountHolder holder,string accountNum)
    {
        
       
        
        
            Console.WriteLine(Constants.seperateLine);
            Console.WriteLine(Constants.accountOperations);
            var userInput = Convert.ToInt32(Console.ReadLine());

        while (true)
        {
            try
                {
                    switch (GetATMService(userInput))
                    {
                     case  ATMOperation.CheckBalance:
                           Console.WriteLine("Check Your balance.");
                           var balance = accountDetailsService.checkBalance(holder);

                    var aHolder = AccountData.AccountHoldersDetails.Find(e => e.AccountNum.Equals(accountNum));

                   
                    if (aHolder != null)
                    {
         
                        Console.WriteLine("Updated balance: " + aHolder.InitialAmount);
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    Console.WriteLine(balance); ;
                           break;

                    case ATMOperation.ToCreditAmount:
                            Console.WriteLine(Constants.enterAmountToCredit);
                            var creditAmount = int.Parse(Console.ReadLine());
                       // var amount = holder.InitialAmount + creditAmount;


                    //AccountData.AccountHoldersDetails.ForEach(e => e.AccountNum.Equals(accountNum));
                    //{
                    //    AccountData.AccountHoldersDetails.ForEach(e => e.InitialAmount = e.InitialAmount + creditAmount);
                    //}

                    var accountHolder = AccountData.AccountHoldersDetails.Find(e => e.AccountNum.Equals(accountNum));

                    if (accountHolder != null)
                    {
                        accountHolder.InitialAmount += creditAmount;
                        Console.WriteLine("Updated balance: " + accountHolder.InitialAmount);
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }

               
                        break;

                        case ATMOperation.DebitAmount:
                            Console.WriteLine(Constants.enterAmountToDebit);
                            var debitAmount = int.Parse(Console.ReadLine());
                    var accHolder = AccountData.AccountHoldersDetails.Find(e => e.AccountNum.Equals(accountNum));

                  
                    if (accHolder != null)
                    {
                        accHolder.InitialAmount -= debitAmount;
                        Console.WriteLine("Updated balance: " + accHolder.InitialAmount);
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
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
            return ATMOperation.CheckBalance;
        else if (value == 2)
            return ATMOperation.ToCreditAmount;
        else if (value == 3)
            return ATMOperation.DebitAmount;
        else if (value == 4)
            return ATMOperation.EditAccountDetails;
        else if (value == 5)
            return ATMOperation.TakeHelp;
        else
            return default;
    }
}
