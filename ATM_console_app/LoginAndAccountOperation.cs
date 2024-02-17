using Data;
using Models;
using Services;
using Services.Interfaces;

class LoginAndAccountOperation
{
    private static IAccountDetailsService accountDetailsService = new AccountDetailsService();
    private static ITransactionService transactionService = new TransactionService();
    private static UserInputOutput userInputOutputService = new UserInputOutput();

    //private static AccountDetailsService accountDetailsService;
    //private static UserInputOutput userInputOutputService;
    //private static TransactionService transactionService;
    //public LoginAndAccountOperation()
    //{
    //    accountDetailsService = new AccountDetailsService();
    //    userInputOutputService = new UserInputOutput();
    //    transactionService = new TransactionService();
    //}

    public static void AccountOperation()
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

                            using (var context = new TezoBankDbContext())
                            {
                                var holderAccount = context.AccountDetails.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);

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
                                        var newName = Console.ReadLine();

                                        if (!string.IsNullOrWhiteSpace(newName))
                                        {
                                            accountDetailsService.UpdateLastModifiedTime(accountHolder);
                                            accountDetailsService.UpdateName(accountHolder, newName);
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
                                        var newAddress = Console.ReadLine();


                                        if (!string.IsNullOrWhiteSpace(newAddress))
                                        {
                                            accountDetailsService.UpdateLastModifiedTime(accountHolder);
                                            accountDetailsService.UpdateAddress(accountHolder, newAddress);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine(Constants.enterValidAddress);
                                        }
                                    }
                                    break;

                                case UpdateDetails.UpdateAge:

                                    while (true)
                                    {
                                        Console.WriteLine(Constants.enterAgetoUpdate);
                                        if (int.TryParse(Console.ReadLine(), out var number) && 8 < number && 100 > number)
                                        {
                                            accountDetailsService.UpdateLastModifiedTime(accountHolder);
                                            accountDetailsService.UpdateAge(accountHolder, number);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine(Constants.enteredInvalidAge);
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
                                {
                                    Console.WriteLine(Constants.enterAmountToTransfer);
                                    using (var context = new TezoBankDbContext()) {
                                      var holder =  context.AccountDetails.FirstOrDefault(e => e.Id == accountHolder.Id);
                                        if (int.TryParse(Console.ReadLine(), out var transferAmount) && transferAmount > 0 && holder.Balance > transferAmount)
                                        {
                                            accountDetailsService.PerformTransferAmount(accountHolder, receiverAccount, transferAmount);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine(Constants.cannotTransferMorethanCurrentbalanace);
                                        }
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
                            RegisterNewHolder.OpenNewAccount();
                            break;

                        case ATMOperation.Login:
                            AccountOperation();
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
                return ATMOperation.Login;
            case 10:
                return ATMOperation.HoldersList;
            case 11:
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
            case 3:
                return UpdateDetails.UpdateAge;
            default:
                return default;
        }

    }

}