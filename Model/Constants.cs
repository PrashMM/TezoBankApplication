namespace Models
{
    public static class Constants
    {
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string filePath = Path.Combine(folderPath, "AtmAccHolder1.json");
        public static string filePathForTransaction = Path.Combine(folderPath, "AtmTransaction1.json");
        public const string welcomeMessage = "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-\n *  *  * Hello Sir/Madam, Welcome to Tezo Bank *  *  *\n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-";
        public const string seperateLine = "--------------------------------------------------\n--------------------------------------------------";
        public const string seperatedivider = "================================================================";
        public const string chooseOperation = "Choose Any Below Options to Proceed\n Type 1 to Open your account\n Type 2 to Login to your account \n Type 3 to Exit";
        public const string enterFollowingDetails = "Please enter the following details to open your account";
        public const string enterAccountNumbertoLogin = "*-* Enter the Account Number to Login *-*";
        public const string accountOperations = "--> Press 1 to Check Balance,\n--> Press 2 to Credit amount to your account,\n--> Press 3 to Debit amount from your account,\n--> Press 4 to Edit account details,\n--> Press 5 to Transfer Amount\n--> Press 6 to Transaction History\n--> Press 7 to Help Service. \n--> Press 8 to To Create new account \n--> Press 9 to Login to Existing account \n--> Press 10 to Display all Account holders details \n--> Press 11 to Exit";
        public const string checkAllDetails = "Here are the Details you entered. Please check all the Details correct or Not ";
        public const string ifCorrectPressYToProcced = "<-> <-> if everything is correct, Type 'Y' to proceed <-> <->";
        public const string checkAccountBalance = " Check Your Account Balance Here";
        public const string yourBalanceIs = "Your balance is";
        public const string enterAmountToCredit = "Enter the Amount You want to Credit";
        public const string enterAmountToDebit = "Enter the Amount You want to Debit";
        public const string editAccountDetails = "Edit account Details";
        public const string writeEmailandQuery = "Please write your Query here";
        public const string teamWillReachOutToYou = "Thank you, We have your email already. So Our team will look into this matter and reach out to you shortly.";
        public const string accountNotFound = "Uh ho! Account Not Found\n";
        public const string enterToUpdateDetails = "** Press 1 to Update First Name,\n** Press 2 to Update Address.\n** Press 3 to Update Age";
        public const string enterNameToUpdate = "Enter name to update";
        public const string enterAddressToUpdate = "Enter Address to update";
        public const string thankYou = "You are good to go. Thank You for choosing Tezo Bank :)\n ";
        public const string enterAccountNumtoTransferAmount = "Enter the account number in which you want to transfer your amount";
        public const string enterAmountToTransfer = "Enter the amount you want to transfer";
        public const string transactionHistory = "* * Transaction History: * *";
        public const string noTransactionsDone = "Uh ho!. Sorry, So far No transactions made in this account\n";
        public const string amountIs0orLess = "Uh ho. The amount you entered is either 0 or less. Please enter a valid amount.\n";
        public const string cannotWithdrawMorethanCurrentbalanace = "Uh ho!. Sorry, you entered 0 or amount entered is more than your current balance\n";
        public const string cannotTransferMorethanCurrentbalanace = "Uh ho1. Sorry, you cannot transfer more than your current balance\n";
        public const string accNotFoundOrAccNumisSame = "Uh ho!. Account not found or you are attempting to transfer the amount within the same account.\n";
        public const string enterValidAddress = "Uh ho! Please enter valid Address\n";

        public const string enterYourFirstName = "--> Please Enter Your First Name";
        public const string enterValidName = "Uh ho! Please enter valid name\n";
        public const string enterYourLastName = "--> Please Enter Your Last Name (Optional)";
        public const string enterYourAge = "--> Please Enter Your Age";
        public const string enteredInvalidAge = "Uh ho! Sorry, You may be entered age, Which is invalid or less than 8. Please enter valid age.\n";
        public const string chooseGender = "-->  Please Choose Your Gender From Below Options\n Type 1 for Male\n Type 2 for Female\n Type 3 for Others";
        public const string enteredInvalidOption = "Uh ho! Sorry Please Choose valid option from above.\n";
        public const string enterMobileNumber = "--> Please Enter your Mobile Number";
        public const string incorrectMobileNumber = "Uh ho! The provided mobile number already exists or entered digits are less than 10. Please enter a valid mobile number.\n";
        public const string enterStreetAddress = "--> Please Enter Your Street Address";
        public const string invalidStreetAddress = "Uh ho!.Sorry, Please enter valid Street Address\n";
        public const string enterYourCiy = "-->  Please Enter Your City Name";
        public const string enterValidCityName = "Uh ho!, Sorry Please enter valid city name\n";
        public const string enterState = "-->  Please Enter Your State Name";
        public const string invalidState = "Uh ho!. Sorry Please enter valid State Name\n";
        public const string enterPostalCode = "--> Please Enter Your Postal Code Number";
        public const string invalidPostalCode = "Uh ho!. Sorry you entered invalid postal number. Please enter valid 6 digit Postal Code. * Ex: 560060 for Bangalore\n";
        public const string enterYourAadharNumber = "--> Please Enter Your Aadhar Number";
        public const string invalidAAdharNumber = "Uh ho!, Please enter valid 8 digit Aadhar Number. * Ex: 12345678\n";
        public const string enterPanCardNumber = "--> Please Enter Your Pan Card number";
        public const string invalidPanCardNumber = "Uh ho!, Please enter valid Pan Card Number. * Ex: ABCD1234K\n";
        public const string enterEmailAddress = "--> Please Enter Your Email Address (Optional)";
        public const string invalidEmail = "Uh ho!, You entered invalid email Address. Please enter valid one. * Ex: abc@123.com\n";
        public const string enterOccupation = "--> Enter Your Occupation (Optional)";
        public const string enterInitialAmount = "--> Please Enter Your Initial Amount";
        public const string invalidAmount = "Uh ho!. Please enter valid amount\n";
        public const string chooseAccoutType = "--> Choose the AccountType you want to open \n Type 1 for Savings Account\n Type 2 for Salary Account\n Type 3 for Others";
        public const string enterAgetoUpdate = "Enter Your Age to Update";
        public const string nameUpdated = "Your Name is Updated. Thank you";
        public const string addressUpdated = "Your Address is Updated. Thank you";
        public const string ageUpdated = "Your Age is Updated. Thank you";
    }
}
