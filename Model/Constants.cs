namespace Models
{
    public static class Constants
    {
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string filePath = Path.Combine(folderPath, "AtmAccHolder1.json");
        public static string filePathForTransaction = Path.Combine(folderPath, "AtmTransaction1.json");
        public const string welcomeMessage = "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*\n      Hello @Sir/Madam!, Welcome to Tezo Bank :)    \n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*";
        public const string seperateLine = "-----*------*-------*----------*--------*-------*-------";
        public const string chooseOperation = "Choose Any Below Options to Proceed\n Press 1 to Open your account\n Press 2 to Login to your account \n Press 3 to Exit";
        public const string enterFollowingDetails = "Please enter the following details to open your account";
        public const string enterFullName = "*-* Enter your Full Name *-*";
        public const string enterMobileNumber = "*-* Enter your Mobile Number *-*";
        public const string enterLocation = "*-* Enter your Location *-*";
        public const string enterPincode = "*-* Enter Pincode *-*";
        public const string enterAadharCardNumber = "*-* Enter your Aadhar Card Number *-*";
        public const string enterAccountNumber = "*-* Enter the Account Number *-*";
        public const string accountOperations = "--> Press 1 to Check Balance,\n--> Press 2 to Credit amount to your account,\n--> Press 3 to Debit amount from your account,\n--> Press 4 to Edit account details,\n--> Press 5 to Transfer Amount\n--> Press 6 to Transaction History\n--> Press 7 to Help Service. \n--> Press 8 to To Create new account \n--> Press 9 to Login to Existing account \n--> Press 10 to Display all Account holders details \n--> Press 11 to Exit";
        public const string checkAllDetails = "Here are the Details you entered. Please check all the Details correct or Not ";
        public const string ifCorrectPressYToProcced = "<-> <-> if everything is correct, Type 'Y' to proceed <-> <->";
        public const string checkAccountBalance = "Check Your Account Balance Here";
        public const string yourBalanceIs = "Your balance is ";
        public const string enterAmountToCredit = "Enter the Amount You want to Credit";
        public const string enterAmountToDebit = "Enter the Amount You want to Debit";
        public const string editAccountDetails = "Edit account Details";
        public const string getHelp = "Get Help Service";
        public const string writeEmailandQuery = "Please write your e-mail id and Query";
        public const string teamWillReachOutToYou = "Thank you, Our team will look into this matter and reach out to you shortly.";
        public const string accountNotFound = "Account Not Found";
        public const string enterToUpdateDetails = "** Press 1 to Update First Name,\n** Press 2 to Update Address.\n** Press 3 to Update Age";
        public const string enterNameToUpdate = "Enter name to update";
        public const string enterAddressToUpdate = "Enter Address to update";
        public const string thankYou = "You are good to go. Thank You :) ";
        public const string insufficientBalance = "Insufficient Balance";
        public const string enterValidAmount = "Please enter valid amount";
        public const string UnableToCreateAccountNumber = "Warning: FullName is empty or null. Unable to create AccountNumber.";
        public const string enterAccountNumtoTransferAmount = "Enter the account number in which you want to transfer your amount";
        public const string enterAmountToTransfer = "Enter the amount you want to transfer";
        public const string transactionHistory = "Transaction History:";
        public const string noTransactionsDone = "Sorry, So far No transactions made in this account";
        public const string incorrectMobileNumber = "The provided mobile number already exists or entered digits are less than 10. Please enter a valid mobile number.";
        public const string amountIs0orLess = "The amount you entered is either 0 or less. Please enter a valid amount.";
        public const string cannotWithdrawMorethanCurrentbalanace = "Sorry,you entered 0 or amount entered is more than your current balance";
        public const string cannotTransferMorethanCurrentbalanace = "Sorry, you cannot transfer more than your current balance";
        public const string enterValidName = "Please enter valid name";
        public const string accNotFoundOrAccNumisSame = "Account not found or you are attempting to transfer the amount within the same account.";
        public const string enterValidAddress = "Please enter valid Address";

        public const string enterYourFirstName = "--> Please Enter Your First Name";
        public const string enterYourLastName = "--> Please Enter Your Last Name (Optional)";
        public const string enterYourAge = "--> Please Enter Your Age";
        public const string enteredInvalidAge = "Sorry, You may be entered age which is invalid or less than 8";
        public const string chooseGender = "-->  Please Choose Your Gender From Below Options\n Type 1 for Male\n Type 2 for Female\n Type 3 for Others";
        public const string enteredInvalidOption = "Please Choose valid option from above";
        public const string enterStreetAddress= "--> Please Enter Your Street Address";
        public const string invalidStreetAddress = "Please enter valid Street Address";
        public const string enterYourCiy = "-->  Please Enter Your City";
        public const string enterValidCityName = "Please enter valid City name";
        public const string enterState = "-->  Please Enter Your State";
        public const string invalidState = "Please enter valid State Name";
        public const string enterPostalCode = "-->  Enter Your Pin Code Number";
        public const string invalidPostalCode = "Please enter valid 6 digit Postal Code. * Ex: 560060 for Bangalore";
        public const string enterYourAadharNumber = "--> Please Enter Your Aadhar Number";
        public const string invalidAAdharNumber = "Please enter valid 8 digit Aadhar Number. * Ex: 12345678";
        public const string enterPanCardNumber = "--> Please Enter Your Pan Card number";
        public const string invalidPanCardNumber = "Please enter valid Pan Card Number. * Ex: ABCD1234K";
        public const string enterEmailAddress= "--> Please Enter Your Email Address";
        public const string invalidEmail = "Please enter valid email. * Ex: abc@123.com";
        public const string enterOccupation = "--> Enter Your Occupation (Optional)";
        public const string enterInitialAmount = "--> Please Enter Your Initial Amount";
        public const string invalidAmount = "Please enter valid amount";
        public const string chooseAccoutType = "--> Choose AccountType\n Type 1 for Savings Account\n Type 2 for Salary Account\n Type 3 for Others";
        public const string enterAgetoUpdate = "Enter Your Age to Update";


    }
}
