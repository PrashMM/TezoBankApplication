using Models;
using Services;
using Services.Interfaces;

public class RegisterNewHolder
{
    private static IAccountDetailsService accountDetailsService = new AccountDetailsService();
    private static UserInputOutput userInputOutputService = new UserInputOutput();

    public static void OpenNewAccount()
    {

        Console.WriteLine(Constants.enterFollowingDetails);

        Console.WriteLine(Constants.seperateLine);

        string firstName = EnterRequiredDetails("First");

        Console.WriteLine(Constants.seperatedivider);

        string lastName = EnterLastName();

        Console.WriteLine(Constants.seperatedivider);

        int age = EnterAge();

        Console.WriteLine(Constants.seperatedivider);

        Gender gender = SelectGenderFromOptions();

        Console.WriteLine(Constants.seperatedivider);

        string mobileNumber = EnterMobileNumber();

        Console.WriteLine(Constants.seperatedivider);

        string streetAddress = EnterRequiredDetails("Street");

        Console.WriteLine(Constants.seperatedivider);

        string city = EnterRequiredDetails("City"); ;

        Console.WriteLine(Constants.seperatedivider);

        string state = EnterRequiredDetails("State");

        Console.WriteLine(Constants.seperatedivider);

        int pinCode = EnterRequiredData("Postal code", 6);

        Console.WriteLine(Constants.seperatedivider);

        int aadharNumber = EnterRequiredData("Aadhar", 8);

        Console.WriteLine(Constants.seperatedivider);

        string panCard = EnterPancard();

        Console.WriteLine(Constants.seperatedivider);

        string email = EnterEmail();

        Console.WriteLine(Constants.seperatedivider);

        string occupation = EnterOccupation();

        Console.WriteLine(Constants.seperatedivider);

        double initialAmount = AddInitialAmount();
        double balance = initialAmount;

        Console.WriteLine(Constants.seperatedivider);

        AccountType accountType = ChooseAccountType();

        Console.WriteLine(Constants.seperatedivider);


        var newHolderDetails = new AccountHolder(firstName, lastName ?? "", age, gender, aadharNumber, panCard, occupation ?? "", mobileNumber, email, streetAddress, city, state, pinCode, "", initialAmount, balance, accountType);

        userInputOutputService.ShowAccountDetails(newHolderDetails);

        var IsDetailsCorrect = Console.ReadLine();

        if (userInputOutputService.IsAccountDetailsCorrect(newHolderDetails, IsDetailsCorrect))
        {
            accountDetailsService.AddHolderDetails(newHolderDetails);
            LoginAndAccountOperation.AccountOperation();
        }
        else
        {
            // break; 
            return;
        }


    }

    static string EnterRequiredDetails(string field)
    {
        while (true)
        {
            Console.WriteLine($"--> Please Enter your {field} name");
            var value = Console.ReadLine();
            if (string.IsNullOrEmpty(value) || value.Length < 3)
            {
                Console.WriteLine($"Uh ho!.Sorry Please enter valid {field} Name\n");
            }
            else
            {
                return value;
            }
        }
    }
    static string EnterLastName()
    {
        Console.WriteLine(Constants.enterYourLastName);
        return Console.ReadLine();
    }

    static int EnterAge()
    {
        while (true)
        {
            Console.WriteLine(Constants.enterYourAge);
            if (int.TryParse(Console.ReadLine(), out var number) && 8 < number && 100 > number)
            {
                return number;
            }
            else
            {
                Console.WriteLine(Constants.enteredInvalidAge);
            }
        }
    }

    static Gender SelectGenderFromOptions()
    {
        while (true)
        {
            Console.WriteLine(Constants.chooseGender);

            if (int.TryParse(Console.ReadLine(), out int genderOption) && 1 <= genderOption && genderOption <= 3)
            {
                return SelectGender(genderOption);
            }
            else
            {
                Console.WriteLine(Constants.enteredInvalidOption);
            }
        }
    }

    static string EnterMobileNumber()
    {
        while (true)
        {
            Console.WriteLine(Constants.enterMobileNumber);
            string mobileNumber = Console.ReadLine();
            if (accountDetailsService.MobileNumberExistsOrNot(mobileNumber) || (string.IsNullOrEmpty(mobileNumber) || mobileNumber.Length < 10 || mobileNumber.Length > 12))
            {
                Console.WriteLine(Constants.incorrectMobileNumber);
            }
            else
            {
                return mobileNumber;
            }
        }
    }

    static int EnterRequiredData(string field, int value)
    {
        while (true)
        {
            Console.WriteLine($"--> Please Enter Your {field} Number");

            if (int.TryParse(Console.ReadLine(), out int number) && number.ToString().Length == value)
            {
                return number;
            }
            else
            {
                Console.WriteLine($"Uh ho!. Please enter {value} digit valid {field} number \n");
            }
        }
    }

    static string EnterPancard()
    {
        while (true)
        {
            Console.WriteLine(Constants.enterPanCardNumber);
            var panCardNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(panCardNumber) || panCardNumber.Length < 6)
            {
                Console.WriteLine(Constants.invalidPanCardNumber);
            }
            else
            {
                return panCardNumber;
            }
        }
    }

    static string EnterEmail()
    {
        while (true)
        {
            Console.WriteLine(Constants.enterEmailAddress);
            string emailAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(emailAddress) ? emailAddress == "" : UserInputOutput.IsValidEmail(emailAddress))
            {
                return emailAddress;
            }
            else
            {
                Console.WriteLine(Constants.invalidEmail);
            }
        }
    }

    static string EnterOccupation()
    {
        Console.WriteLine(Constants.enterOccupation);
        return Console.ReadLine();
    }

    static double AddInitialAmount()
    {
        while (true)
        {
            Console.WriteLine(Constants.enterInitialAmount);
            if (int.TryParse(Console.ReadLine(), out var amount) && amount < 0)
            {
                Console.WriteLine(Constants.invalidAmount);
            }
            else
            {
                return amount;
            }
        }
    }

    static AccountType ChooseAccountType()
    {
        while (true)
        {

            Console.WriteLine(Constants.chooseAccoutType);
            if (int.TryParse(Console.ReadLine(), out var type) && 1 <= type && type <= 3)
            {
                return SelectAccountType(type);
            }
            else
            {
                Console.WriteLine(Constants.enteredInvalidOption);
            }
        }
    }

    public static Gender SelectGender(int gender)
    {

        switch (gender)
        {
            case 1:
                return Gender.Male;
            case 2:
                return Gender.Female;
            case 3:
                return Gender.Others;
            default:
                return default;
        }

    }

    public static AccountType SelectAccountType(int type)
    {
        switch (type)
        {
            case 1:
                return AccountType.SavingsAccount;
            case 2:
                return AccountType.SalaryAccount;
            case 3:
                return AccountType.Others;
            default:
                return default;
        }

    }

}

