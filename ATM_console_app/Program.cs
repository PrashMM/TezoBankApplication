
using Data;
using Models;
using Services;

class Program
{
    public static void Main()
    {
        WelcomeMenu();
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
                    switch (MainMenuByInput(userInput))
                    {
                        case MainMenu.OpenAccount:
                            RegisterNewHolder.OpenNewAccount();
                            break;

                        case MainMenu.Login:
                            LoginAndAccountOperation.AccountOperation();
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

    //public static void OpenNewAccount()
    //{

    //    Console.WriteLine(Constants.enterFollowingDetails);

    //    Console.WriteLine(Constants.seperateLine);

    //    // First Name
    //    string firstName;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterYourFirstName);
    //        firstName = Console.ReadLine();

    //        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length < 3)
    //        {
    //            Console.WriteLine(Constants.enterValidName);
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Last Name
    //    Console.WriteLine(Constants.enterYourLastName);
    //    var lastName = Console.ReadLine();

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Age
    //    int age;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterYourAge);
    //        if (int.TryParse(Console.ReadLine(), out var number) && 8 < number && 100 > number)
    //        {
    //            age = number;
    //            break;
    //        }
    //        else
    //        {
    //            Console.WriteLine(Constants.enteredInvalidAge);
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Gender
    //    Gender gender;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.chooseGender);

    //        if (int.TryParse(Console.ReadLine(), out int genderOption) && 1 <= genderOption && genderOption <= 3)
    //        {
    //            gender = SelectGender(genderOption);
    //            break;
    //        }
    //        else
    //        {
    //            Console.WriteLine(Constants.enteredInvalidOption);
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Mobile Number
    //    string mobileNumber;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterMobileNumber);
    //        mobileNumber = Console.ReadLine();
    //        if (accountDetailsService.MobileNumberExistsOrNot(mobileNumber) || (string.IsNullOrEmpty(mobileNumber) || mobileNumber.Length < 10 || mobileNumber.Length > 12))
    //        {
    //            Console.WriteLine(Constants.incorrectMobileNumber);
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Street Address
    //    string streetAddress;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterStreetAddress);
    //        var street = Console.ReadLine();
    //        if (string.IsNullOrEmpty(street) || street.Length < 2)
    //        {
    //            Console.WriteLine(Constants.invalidStreetAddress);
    //        }
    //        else
    //        {
    //            streetAddress = street;
    //            break;
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // City
    //    string city;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterYourCiy);
    //        var cityName = Console.ReadLine();
    //        if (string.IsNullOrEmpty(cityName) || cityName.Length < 3)
    //        {
    //            Console.WriteLine(Constants.enterValidCityName);
    //        }
    //        else
    //        {
    //            city = cityName;
    //            break;
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // State
    //    string state;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterState);
    //        var stateName = Console.ReadLine();
    //        if (string.IsNullOrEmpty(stateName) || stateName.Length < 3)
    //        {
    //            Console.WriteLine(Constants.invalidState);
    //        }
    //        else
    //        {
    //            state = stateName;
    //            break;
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Pin Code
    //    int pinCode;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterPostalCode);

    //        if (int.TryParse(Console.ReadLine(), out int postalCode) && postalCode.ToString().Length == 6)
    //        {
    //            pinCode = postalCode;
    //            break;
    //        }
    //        else
    //        {
    //            Console.WriteLine(Constants.invalidPostalCode);
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Aadhar Number
    //    int aadharNumber;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterYourAadharNumber);

    //        if (int.TryParse(Console.ReadLine(), out int aadharNum) && aadharNum.ToString().Length == 8)
    //        {
    //            aadharNumber = aadharNum;
    //            break;
    //        }
    //        else
    //        {
    //            Console.WriteLine(Constants.invalidAAdharNumber);
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Pan Card
    //    string panCard;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterPanCardNumber);
    //        var panCardNumber = Console.ReadLine();
    //        if (string.IsNullOrEmpty(panCardNumber) || panCardNumber.Length < 6)
    //        {
    //            Console.WriteLine(Constants.invalidPanCardNumber);
    //        }
    //        else
    //        {
    //            panCard = panCardNumber;
    //            break;
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Email Address
    //    string email;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterEmailAddress);
    //        string emailAddress = Console.ReadLine();
    //        if (string.IsNullOrWhiteSpace(emailAddress) ? emailAddress == "" : UserInputOutput.IsValidEmail(emailAddress))
    //        {
    //            email = emailAddress;
    //            break;
    //        }
    //        else
    //        {
    //            Console.WriteLine(Constants.invalidEmail);
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Occupation
    //    Console.WriteLine(Constants.enterOccupation);
    //    var occupation = Console.ReadLine();

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Initial Amount
    //    double initialAmount;
    //    double balance;
    //    while (true)
    //    {
    //        Console.WriteLine(Constants.enterInitialAmount);
    //        if (int.TryParse(Console.ReadLine(), out var amount) && amount < 0)
    //        {
    //            Console.WriteLine(Constants.invalidAmount);
    //        }
    //        else
    //        {
    //            initialAmount = amount;
    //            balance = amount;
    //            break;
    //        }
    //    }

    //    Console.WriteLine("-----------***----------------***--------------------***---------");

    //    // Account Type
    //    AccountType accountType;
    //    while (true)
    //    {

    //        Console.WriteLine(Constants.chooseAccoutType);
    //        if (int.TryParse(Console.ReadLine(), out var type) && 1 <= type && type <= 3)
    //        {
    //            accountType = SelectAccountType(type);
    //            break;
    //        }
    //        else
    //        {
    //            Console.WriteLine(Constants.enteredInvalidOption);
    //        }
    //    }


    //    Console.WriteLine("-----------***----------------***--------------------***---------");


    //    var newAccountHolder = new AccountHolder(firstName, lastName ?? "", age, gender, aadharNumber, panCard, occupation ?? "", mobileNumber, email, streetAddress, city, state, pinCode, "", initialAmount, balance, accountType);

    //    userInputOutputService.ShowAccountDetails(newAccountHolder);

    //    var dataIsCorrect = Console.ReadLine();

    //    if (userInputOutputService.IsAccountDetailsCorrect(newAccountHolder, dataIsCorrect))
    //    {
    //        accountDetailsService.AddHolderDetails(newAccountHolder);
    //        AccountOperation();
    //    }
    //    else
    //    {
    //        // break; 
    //        return;
    //    }


    //}

    //public static void AccountOperation()
    //{
    //    Console.WriteLine(Constants.seperateLine);
    //    Console.WriteLine(Constants.enterAccountNumber);
    //    var accountNumber = Console.ReadLine();
    //    var accountHolder = accountDetailsService.GetAccountHolderByAccNumber(accountNumber);

    //    while (true)
    //    {
    //        if (accountHolder != null)
    //        {
    //            Console.WriteLine(Constants.seperateLine);
    //            Console.WriteLine(Constants.accountOperations);
    //            int.TryParse(Console.ReadLine(), out var userInput);
    //            try
    //            {
    //                switch (GetATMService(userInput))
    //                {
    //                    case ATMOperation.CheckBalance:
    //                        Console.WriteLine(Constants.checkAccountBalance);
    //                        UserInputOutput.PrintAmount(accountHolder);
    //                        break;

    //                    case ATMOperation.Deposit:

    //                        Console.WriteLine(Constants.enterAmountToCredit);
    //                        if (int.TryParse(Console.ReadLine(), out var amountToDeposit) && amountToDeposit > 0)
    //                        {
    //                            accountDetailsService.UpdateLastModifiedTime(accountHolder);
    //                            accountDetailsService.PerformDeposit(accountHolder, amountToDeposit);
    //                            UserInputOutput.PrintAmount(accountHolder);
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine(Constants.amountIs0orLess);
    //                        }

    //                        break;

    //                    case ATMOperation.Withdraw:
    //                        Console.WriteLine(Constants.enterAmountToDebit);

    //                        using (var context = new TezoBankDbContext())
    //                        {
    //                            var holderAccount = context.AccountDetails.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);

    //                            if (int.TryParse(Console.ReadLine(), out var amountToWithdraw) && amountToWithdraw > 0 && holderAccount.Balance > amountToWithdraw)
    //                            {
    //                                accountDetailsService.UpdateLastModifiedTime(accountHolder);
    //                                accountDetailsService.PerformWithdraw(accountHolder, amountToWithdraw);
    //                                UserInputOutput.PrintAmount(accountHolder);
    //                            }
    //                            else
    //                            {
    //                                Console.WriteLine(Constants.cannotWithdrawMorethanCurrentbalanace);
    //                            }
    //                        }
    //                        break;

    //                    case ATMOperation.EditAccountDetails:
    //                        Console.WriteLine(Constants.editAccountDetails);
    //                        Console.WriteLine(Constants.enterToUpdateDetails);
    //                        int.TryParse(Console.ReadLine(), out var updateInput);
    //                        switch (UpdateDetailsByInput(updateInput))
    //                        {
    //                            case UpdateDetails.UpdateName:

    //                                while (true)
    //                                {
    //                                    Console.WriteLine(Constants.enterNameToUpdate);
    //                                    var newName = Console.ReadLine();

    //                                    if (!string.IsNullOrWhiteSpace(newName))
    //                                    {
    //                                        accountDetailsService.UpdateLastModifiedTime(accountHolder);
    //                                        accountDetailsService.UpdateName(accountHolder, newName);
    //                                        break;
    //                                    }
    //                                    else
    //                                    {
    //                                        Console.WriteLine(Constants.enterValidName);
    //                                    }
    //                                }
    //                                break;

    //                            case UpdateDetails.UpdateAddress:

    //                                while (true)
    //                                {
    //                                    Console.WriteLine(Constants.enterAddressToUpdate);
    //                                    var newAddress = Console.ReadLine();


    //                                    if (!string.IsNullOrWhiteSpace(newAddress))
    //                                    {
    //                                        accountDetailsService.UpdateLastModifiedTime(accountHolder);
    //                                        accountDetailsService.UpdateAddress(accountHolder, newAddress);
    //                                        break;
    //                                    }
    //                                    else
    //                                    {
    //                                        Console.WriteLine(Constants.enterValidAddress);
    //                                    }
    //                                }
    //                                break;

    //                            case UpdateDetails.UpdateAge:

    //                                while (true)
    //                                {
    //                                    Console.WriteLine(Constants.enterAgetoUpdate);
    //                                    if (int.TryParse(Console.ReadLine(), out var number) && 8 < number && 100 > number)
    //                                    {
    //                                        accountDetailsService.UpdateLastModifiedTime(accountHolder);
    //                                        accountDetailsService.UpdateAge(accountHolder, number);
    //                                        break;
    //                                    }
    //                                    else
    //                                    {
    //                                        Console.WriteLine(Constants.enteredInvalidAge);
    //                                    }
    //                                }
    //                                break;
    //                        }
    //                        break;

    //                    case ATMOperation.TransferAmount:
    //                        while (true)
    //                        {
    //                            Console.WriteLine(Constants.enterAccountNumtoTransferAmount);
    //                            var receiverAccountNumber = Console.ReadLine();
    //                            var receiverAccount = accountDetailsService.GetAccountHolderByAccNumber(receiverAccountNumber);
    //                            if (receiverAccount != null && receiverAccount.Id != accountHolder.Id)
    //                            {
    //                                Console.WriteLine(Constants.enterAmountToTransfer);
    //                                if (int.TryParse(Console.ReadLine(), out var transferAmount) && transferAmount > 0)
    //                                {
    //                                    accountDetailsService.PerformTransferAmount(accountHolder, receiverAccount, transferAmount);
    //                                    break;
    //                                }
    //                                else
    //                                {
    //                                    Console.WriteLine(Constants.cannotTransferMorethanCurrentbalanace);
    //                                }
    //                            }
    //                            else
    //                            {
    //                                Console.WriteLine(Constants.accNotFoundOrAccNumisSame);
    //                                break;
    //                            }
    //                        }
    //                        break;

    //                    case ATMOperation.TransactionHistory:
    //                        Console.WriteLine(Constants.transactionHistory);

    //                        if (transactionService.CheckTransactionHistoryIsEmptyOrNot())
    //                        {
    //                            var accountHolderTransactions = transactionService.CurrentHolderTransactionHistory(accountHolder);

    //                            foreach (var transaction in accountHolderTransactions)
    //                            {
    //                                UserInputOutput.DisplayTransationHistory(transaction);
    //                            }
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine(Constants.noTransactionsDone);
    //                        }
    //                        break;

    //                    case ATMOperation.TakeHelp:
    //                        userInputOutputService.HelpService();
    //                        break;

    //                    case ATMOperation.OpenAccount:
    //                        RegisterNewHolder.OpenNewAccount();
    //                        break;

    //                    case ATMOperation.Login:
    //                        AccountOperation();
    //                        break;

    //                    case ATMOperation.HoldersList:
    //                        userInputOutputService.DisplayAllAccountHolders();
    //                        break;

    //                    case ATMOperation.Exit:
    //                        Console.WriteLine(Constants.thankYou);
    //                        return;
    //                }
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine(e.Message);
    //            }
    //        }
    //        else
    //        {

    //            Console.WriteLine(Constants.accountNotFound);
    //            break;
    //        }

    //    }
    //}
    //public static ATMOperation GetATMService(int value)
    //{
    //    switch (value)
    //    {
    //        case 1:
    //            return ATMOperation.CheckBalance;
    //        case 2:
    //            return ATMOperation.Deposit;
    //        case 3:
    //            return ATMOperation.Withdraw;
    //        case 4:
    //            return ATMOperation.EditAccountDetails;
    //        case 5:
    //            return ATMOperation.TransferAmount;
    //        case 6:
    //            return ATMOperation.TransactionHistory;
    //        case 7:
    //            return ATMOperation.TakeHelp;
    //        case 8:
    //            return ATMOperation.OpenAccount;
    //        case 9:
    //            return ATMOperation.Login;
    //        case 10:
    //            return ATMOperation.HoldersList;
    //        case 11:
    //            return ATMOperation.Exit;
    //        default:
    //            return default;
    //    }
    //}


    //public static UpdateDetails UpdateDetailsByInput(int value)
    //{

    //    switch (value)
    //    {
    //        case 1:
    //            return UpdateDetails.UpdateName;
    //        case 2:
    //            return UpdateDetails.UpdateAddress;
    //        case 3:
    //            return UpdateDetails.UpdateAge;
    //        default:
    //            return default;
    //    }

    //}


    //public static Gender SelectGender(int gender)
    //{

    //    switch (gender)
    //    {
    //        case 1:
    //            return Gender.Male;
    //        case 2:
    //            return Gender.Female;
    //        case 3:
    //            return Gender.Others;
    //        default:
    //            return default;
    //    }

    //}

    //public static AccountType SelectAccountType(int type)
    //{
    //    switch (type)
    //    {
    //        case 1:
    //            return AccountType.SavingsAccount;
    //        case 2:
    //            return AccountType.SalaryAccount;
    //        case 3:
    //            return AccountType.Others;
    //        default:
    //            return default;
    //    }

    //}

    public static MainMenu MainMenuByInput(int value)
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
}

