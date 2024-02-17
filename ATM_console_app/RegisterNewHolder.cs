using Models;
using Services;
using Services.Interfaces;

public class RegisterNewHolder
{
    //private static AccountDetailsService accountDetailsService;
    //private static UserInputOutput userInputOutputService;
    private static IAccountDetailsService accountDetailsService = new AccountDetailsService();
    private static UserInputOutput userInputOutputService = new UserInputOutput();
    //public RegisterNewHolder()
    //{
    //    accountDetailsService = new AccountDetailsService();
    //    userInputOutputService = new UserInputOutput();
    //}

    public static void OpenNewAccount()
    {

        Console.WriteLine(Constants.enterFollowingDetails);

        Console.WriteLine(Constants.seperateLine);

        // First Name
        string firstName;
        while (true)
        {
            Console.WriteLine(Constants.enterYourFirstName);
            firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length < 3)
            {
                Console.WriteLine(Constants.enterValidName);
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Last Name
        Console.WriteLine(Constants.enterYourLastName);
        var lastName = Console.ReadLine();

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Age
        int age;
        while (true)
        {
            Console.WriteLine(Constants.enterYourAge);
            if (int.TryParse(Console.ReadLine(), out var number) && 8 < number && 100 > number)
            {
                age = number;
                break;
            }
            else
            {
                Console.WriteLine(Constants.enteredInvalidAge);
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Gender
        Gender gender;
        while (true)
        {
            Console.WriteLine(Constants.chooseGender);

            if (int.TryParse(Console.ReadLine(), out int genderOption) && 1 <= genderOption && genderOption <= 3)
            {
                gender = SelectGender(genderOption);
                break;
            }
            else
            {
                Console.WriteLine(Constants.enteredInvalidOption);
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Mobile Number
        string mobileNumber;
        while (true)
        {
            Console.WriteLine(Constants.enterMobileNumber);
            mobileNumber = Console.ReadLine();
            if (accountDetailsService.MobileNumberExistsOrNot(mobileNumber) || (string.IsNullOrEmpty(mobileNumber) || mobileNumber.Length < 10 || mobileNumber.Length > 12))
            {
                Console.WriteLine(Constants.incorrectMobileNumber);
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Street Address
        string streetAddress;
        while (true)
        {
            Console.WriteLine(Constants.enterStreetAddress);
            var street = Console.ReadLine();
            if (string.IsNullOrEmpty(street) || street.Length < 2)
            {
                Console.WriteLine(Constants.invalidStreetAddress);
            }
            else
            {
                streetAddress = street;
                break;
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // City
        string city;
        while (true)
        {
            Console.WriteLine(Constants.enterYourCiy);
            var cityName = Console.ReadLine();
            if (string.IsNullOrEmpty(cityName) || cityName.Length < 3)
            {
                Console.WriteLine(Constants.enterValidCityName);
            }
            else
            {
                city = cityName;
                break;
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // State
        string state;
        while (true)
        {
            Console.WriteLine(Constants.enterState);
            var stateName = Console.ReadLine();
            if (string.IsNullOrEmpty(stateName) || stateName.Length < 3)
            {
                Console.WriteLine(Constants.invalidState);
            }
            else
            {
                state = stateName;
                break;
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Pin Code
        int pinCode;
        while (true)
        {
            Console.WriteLine(Constants.enterPostalCode);

            if (int.TryParse(Console.ReadLine(), out int postalCode) && postalCode.ToString().Length == 6)
            {
                pinCode = postalCode;
                break;
            }
            else
            {
                Console.WriteLine(Constants.invalidPostalCode);
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Aadhar Number
        int aadharNumber;
        while (true)
        {
            Console.WriteLine(Constants.enterYourAadharNumber);

            if (int.TryParse(Console.ReadLine(), out int aadharNum) && aadharNum.ToString().Length == 8)
            {
                aadharNumber = aadharNum;
                break;
            }
            else
            {
                Console.WriteLine(Constants.invalidAAdharNumber);
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Pan Card
        string panCard;
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
                panCard = panCardNumber;
                break;
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Email Address
        string email;
        while (true)
        {
            Console.WriteLine(Constants.enterEmailAddress);
            string emailAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(emailAddress) ? emailAddress == "" : UserInputOutput.IsValidEmail(emailAddress))
            {
                email = emailAddress;
                break;
            }
            else
            {
                Console.WriteLine(Constants.invalidEmail);
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Occupation
        Console.WriteLine(Constants.enterOccupation);
        var occupation = Console.ReadLine();

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Initial Amount
        double initialAmount;
        double balance;
        while (true)
        {
            Console.WriteLine(Constants.enterInitialAmount);
            if (int.TryParse(Console.ReadLine(), out var amount) && amount < 0)
            {
                Console.WriteLine(Constants.invalidAmount);
            }
            else
            {
                initialAmount = amount;
                balance = amount;
                break;
            }
        }

        Console.WriteLine("-----------***----------------***--------------------***---------");

        // Account Type
        AccountType accountType;
        while (true)
        {

            Console.WriteLine(Constants.chooseAccoutType);
            if (int.TryParse(Console.ReadLine(), out var type) && 1 <= type && type <= 3)
            {
                accountType = SelectAccountType(type);
                break;
            }
            else
            {
                Console.WriteLine(Constants.enteredInvalidOption);
            }
        }


        Console.WriteLine("-----------***----------------***--------------------***---------");


        var newAccountHolder = new AccountHolder(firstName, lastName ?? "", age, gender, aadharNumber, panCard, occupation ?? "", mobileNumber, email, streetAddress, city, state, pinCode, "", initialAmount, balance, accountType);

        userInputOutputService.ShowAccountDetails(newAccountHolder);

        var dataIsCorrect = Console.ReadLine();

        if (userInputOutputService.IsAccountDetailsCorrect(newAccountHolder, dataIsCorrect))
        {
            accountDetailsService.AddHolderDetails(newAccountHolder);
            LoginAndAccountOperation.AccountOperation();
        }
        else
        {
            // break; 
            return;
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

