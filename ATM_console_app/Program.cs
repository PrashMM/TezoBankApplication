﻿

using Data;
using Models;
using Models.Models;
using Services;

class Program
{
    private static AccountDetailsService accountDetailsService;
    private static UserInputOutput userInputOutputService;
    private static TransactionService transactionService;
    private static JsonFileService jsonFileService;


    public static void Main()
    {
        InitializeServices();
        WelcomeMenu();
    }

    private static void InitializeServices()
    {
        accountDetailsService = new AccountDetailsService();
        userInputOutputService = new UserInputOutput();
        transactionService = new TransactionService();
        jsonFileService = new JsonFileService();

        //jsonFileService.CheckAndUpdateFile(AccountData.AccountHoldersDetails, Constants.filePath);
        //jsonFileService.CheckAndUpdateFile(AccountData.Transactions, Constants.filePathForTransaction);
    }

    public static void WelcomeMenu()
    {
        Console.WriteLine(Constants.welcomeMessage);
        Console.WriteLine(Constants.chooseOperation);

        while (true)
        {

            if (int.TryParse(Console.ReadLine(), out var userInput))
            {

                try
                {
                    switch (GetMainMenuByInput(userInput))
                    {
                        case MainMenu.OpenAccount:
                            OpenAccount();
                            break;

                        case MainMenu.Login:
                            AccountOperation();
                            break;

                        case MainMenu.Exit:
                            return;

                        default:
                            break;
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
    }


    private static void OpenAccount()
    {
        Console.WriteLine(Constants.enterFollowingDetails);
        Console.WriteLine(Constants.seperateLine);

        string fullName;
        while (true)
        {
            Console.WriteLine(Constants.enterFullName);
            fullName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine(Constants.enterValidName);
            }
            else
            {
                break;
            }
        }

        string mobileNumber;
        while (true)
        {
            Console.WriteLine(Constants.enterMobileNumber);
            mobileNumber = Console.ReadLine();

            if (accountDetailsService.MobileNumberExistsOrNot(mobileNumber) || string.IsNullOrWhiteSpace(mobileNumber))
            {
                Console.WriteLine(Constants.incorrectMobileNumber);
            }
            else
            {
                break;
            }
        }
        Console.WriteLine(Constants.enterLocation);
        var address = Console.ReadLine();
        Console.WriteLine(Constants.enterPincode);
        var pinCode = Console.ReadLine();
        Console.WriteLine(Constants.enterAadharCardNumber);
        var aadharNumber = Console.ReadLine();

        Console.WriteLine(Constants.seperateLine);

        var accountHolderDetails = new Customer(fullName, mobileNumber, address, pinCode, aadharNumber, "", balance: 1000, initialAmount: 1000);

        userInputOutputService.ShowAccountDetails(accountHolderDetails);
        var dataIsCorrect = Console.ReadLine();
        if (userInputOutputService.IsAccountDetailsCorrect(accountHolderDetails, dataIsCorrect))
        {
            var tezoData = new TezoBank(accountHolderDetails.AccountNumber, accountHolderDetails);
            accountDetailsService.AddHolderDetails(tezoData);
            AccountOperation();
        }
        else
        {
            // break; 
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
                int.TryParse(Console.ReadLine(), out var userInput);
                try
                {
                    switch (GetATMService(userInput))
                    {
                        case ATMOperation.CheckBalance:
                            Console.WriteLine(Constants.checkAccountBalance);
                            UserInputOutput.PrintAmount(accountHolder);
                            break;

                        case ATMOperation.Deposit:

                            Console.WriteLine(Constants.enterAmountToCredit);
                            if (int.TryParse(Console.ReadLine(), out var amountToDeposit) && amountToDeposit > 0)
                            {
                                accountDetailsService.UpdateLastModifiedTime(accountHolder);
                                accountDetailsService.PerformDeposit(accountHolder, amountToDeposit);
                                UserInputOutput.PrintAmount(accountHolder);
                            }
                            else
                            {
                                Console.WriteLine(Constants.amountIs0orLess);
                            }

                            break;

                        case ATMOperation.Withdraw:


                            Console.WriteLine(Constants.enterAmountToDebit);

                            using (var context = new AccountHolder1Context())
                            {
                                var holderAccount = context.Accounts.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);
                                // if (int.TryParse(Console.ReadLine(), out var amountToWithdraw) && amountToWithdraw > 0 && accountHolder.CustomerDetails.AccountDetails.Balance > amountToWithdraw)
                                if (int.TryParse(Console.ReadLine(), out var amountToWithdraw) && amountToWithdraw > 0 && holderAccount.Balance > amountToWithdraw)
                                {
                                    accountDetailsService.UpdateLastModifiedTime(accountHolder);
                                    accountDetailsService.PerformWithdraw(accountHolder, amountToWithdraw);
                                    UserInputOutput.PrintAmount(accountHolder);
                                }
                                else
                                {
                                    Console.WriteLine(Constants.cannotWithdrawMorethanCurrentbalanace);
                                }
                            }
                            break;

                        case ATMOperation.EditAccountDetails:
                            Console.WriteLine(Constants.editAccountDetails);
                            Console.WriteLine(Constants.enterToUpdateDetails);
                            int.TryParse(Console.ReadLine(), out var updateInput);
                            switch (UpdateDetailsByInput(updateInput))
                            {
                                case UpdateDetails.UpdateName:

                                    while (true)
                                    {
                                        Console.WriteLine(Constants.enterNameToUpdate);
                                        // var oldName = accountHolder.CustomerDetails.FullName;                                      
                                        var newName = Console.ReadLine();

                                        if (!string.IsNullOrWhiteSpace(newName))
                                        {
                                            accountDetailsService.UpdateLastModifiedTime(accountHolder);
                                            accountDetailsService.UpdateName(accountHolder, newName);
                                            // Console.WriteLine($"Your name '{oldName}' is updated to {accountHolder.CustomerDetails.FullName} ");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine(Constants.enterValidName);
                                        }
                                    }
                                    break;

                                case UpdateDetails.UpdateAddress:

                                    while (true)
                                    {
                                        Console.WriteLine(Constants.enterAddressToUpdate);
                                        // var oldAddress = accountHolder.CustomerDetails.AddressDetails.Location;
                                        var newAddress = Console.ReadLine();


                                        if (!string.IsNullOrWhiteSpace(newAddress))
                                        {
                                            accountDetailsService.UpdateLastModifiedTime(accountHolder);
                                            accountDetailsService.UpdateAddress(accountHolder, newAddress);
                                            // Console.WriteLine($"Your oldAddress '{oldAddress}' is updated to {accountHolder.CustomerDetails.AddressDetails.Location}");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine(Constants.enterValidAddress);
                                        }
                                    }
                                    break;
                            }
                            break;

                        case ATMOperation.TransferAmount:
                            while (true)
                            {
                                Console.WriteLine(Constants.enterAccountNumtoTransferAmount);
                                var receiverAccountNumber = Console.ReadLine();
                                var receiverAccount = accountDetailsService.GetAccountHolderByAccNumber(receiverAccountNumber);
                                if (receiverAccount != null && receiverAccount.Id != accountHolder.Id)
                                // if (receiverAccount != null && receiverAccount.CustomerDetails.AccountDetails.AccountNumber.ToString() != accountHolder.CustomerDetails.AccountDetails.AccountNumber.ToString())
                                {
                                    Console.WriteLine(Constants.enterAmountToTransfer);
                                    if (int.TryParse(Console.ReadLine(), out var transferAmount) && transferAmount > 0)
                                    // if (int.TryParse(Console.ReadLine(), out var transferAmount) && transferAmount > 0 && accountHolder.CustomerDetails.AccountDetails.Balance > transferAmount)
                                    {
                                        accountDetailsService.PerformTransferAmount(accountHolder, receiverAccount, transferAmount);
                                        // Console.WriteLine($"Amount {transferAmount} has been successfully sent to {receiverAccount.CustomerDetails.AccountDetails.AccountNumber}. So your current balance is {accountHolder.CustomerDetails.AccountDetails.Balance}");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(Constants.cannotTransferMorethanCurrentbalanace);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Constants.accNotFoundOrAccNumisSame);
                                    break;
                                }
                            }
                            break;

                        case ATMOperation.TransactionHistory:
                            Console.WriteLine(Constants.transactionHistory);

                            if (transactionService.CheckTransactionHistoryIsEmptyOrNot())
                            {
                                var accountHolderTransactions = transactionService.CurrentHolderTransactionHistory(accountHolder);

                                foreach (var transaction in accountHolderTransactions)
                                {
                                    UserInputOutput.DisplayTransationHistory(transaction);
                                }
                            }
                            else
                            {
                                Console.WriteLine(Constants.noTransactionsDone);
                            }
                            break;

                        case ATMOperation.TakeHelp:
                            userInputOutputService.HelpService();
                            break;

                        case ATMOperation.OpenAccount:
                            WelcomeMenu();
                            break;

                        case ATMOperation.HoldersList:
                            userInputOutputService.DisplayAllAccountHolders();
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
            else
            {

                Console.WriteLine(Constants.accountNotFound);
                break;
            }

        }


    }


    public static MainMenu GetMainMenuByInput(int value)
    {
        switch (value)
        {
            case 1:
                return MainMenu.OpenAccount;
            case 2:
                return MainMenu.Login;
            case 3:
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
                return ATMOperation.TransferAmount;
            case 6:
                return ATMOperation.TransactionHistory;
            case 7:
                return ATMOperation.TakeHelp;
            case 8:
                return ATMOperation.OpenAccount;
            case 9:
                return ATMOperation.HoldersList;
            case 10:
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