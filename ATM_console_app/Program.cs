using ATM_console_app.Models;
using ATM_console_app.Services;

class Program
{
    private static AccountDetailsService accountDetailsService;
    private static UserInputOutput userInputOutputService;
    private static List<AccountHolder> accountHolderDetailsList;
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
        accountHolderDetailsList = new List<AccountHolder>();
        jsonFileService = new JsonFileService();
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
                        Console.WriteLine(Constants.enterLocation);
                        var address = Console.ReadLine();
                        Console.WriteLine(Constants.enterPincode);
                        var pinCode = Console.ReadLine();
                        Console.WriteLine(Constants.enterAadharCardNumber);
                        var aadharNumber = Console.ReadLine();

                        Console.WriteLine(Constants.seperateLine);

                        var accountHolderDetails = new AccountHolder(fullName, mobileNumber, address, pinCode, aadharNumber, "", initialAmount: 1000, balance: 1000);
                        var dataIsCorrect = userInputOutputService.IsAccountDetailsCorrect(accountHolderDetails);

                        if (dataIsCorrect)
                        {
                            accountDetailsService.AddHolderDetails(accountHolderDetails);
                      
                         accountHolderDetailsList.Where(e => e.AccountDetails.AccountNumber == accountHolderDetails.AccountDetails.AccountNumber);
                           if (accountHolderDetailsList != null)
                           {
                              accountHolderDetailsList.Add(accountHolderDetails);
                           }
                            jsonFileService.CreateJSONDocument(accountHolderDetailsList);

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
                             UserInputOutput.printAmount(accountHolder);
                             break;

                        case ATMOperation.Deposit:

                            accountHolderDetailsList.Remove(accountHolder);

                            var amountToDeposit = userInputOutputService.GetValidAmount();
                            var holderAfterDeposit =   accountDetailsService.PerformDeposit(accountHolder, amountToDeposit);

                            accountHolderDetailsList.Add(holderAfterDeposit);
                            jsonFileService.UpdateJson(accountHolderDetailsList);
                            accountHolder.LastModifiedOn = DateTime.UtcNow;
                            break;

                        case ATMOperation.Withdraw:

                            accountHolderDetailsList.Remove(accountHolder);

                            var amountToWithdraw = userInputOutputService.ValidateWithdrawAmount(accountNumber);
                            var holderAfterWithdraw=  accountDetailsService.PerformWithdraw(accountHolder, amountToWithdraw);

                            accountHolderDetailsList.Add(holderAfterWithdraw);
                            jsonFileService.UpdateJson(accountHolderDetailsList);
                            accountHolder.LastModifiedOn = DateTime.UtcNow;
                            break;

                        case ATMOperation.EditAccountDetails:
                            Console.WriteLine(Constants.editAccountDetails);
                            Console.WriteLine(Constants.enterToUpdateDetails);
                            int.TryParse(Console.ReadLine(), out var updateInput);
                            switch (UpdateDetailsByInput(updateInput))
                            {
                                case UpdateDetails.UpdateName:
                                    accountHolderDetailsList.Remove(accountHolder);

                                    Console.WriteLine(Constants.enterNameToUpdate);
                                    var oldName = accountHolder.CustomerDetails.FullName;
                                    var newName = Console.ReadLine();
                                    var holderAfterUpdateName =  accountDetailsService.UpdateName(accountHolder,newName);

                                    accountHolderDetailsList.Add(holderAfterUpdateName);
                                    jsonFileService.UpdateJson(accountHolderDetailsList);

                                    Console.WriteLine($"Your name '{oldName}' is updated to {accountHolder.CustomerDetails.FullName} ");
                                    accountHolder.LastModifiedOn = DateTime.UtcNow;
                                    break;

                                case UpdateDetails.UpdateAddress:
                                    accountHolderDetailsList.Remove(accountHolder);

                                    Console.WriteLine(Constants.enterAddressToUpdate);
                                    var oldAddress = accountHolder.CustomerDetails.AddressDetails.Location;
                                    var newAddress = Console.ReadLine();
                                    var holderAfterUpdateAddress =  accountDetailsService.UpdateAddress(accountHolder, newAddress);

                                    accountHolderDetailsList.Add(holderAfterUpdateAddress);
                                    jsonFileService.UpdateJson(accountHolderDetailsList);

                                    Console.WriteLine($"Your oldAddress '{oldAddress}' is updated to {accountHolder.CustomerDetails.AddressDetails.Location}");
                                    accountHolder.LastModifiedOn = DateTime.UtcNow;
                                    break;
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
                return ATMOperation.HoldersList;
            case 8:
                return ATMOperation.HoldersList;
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
