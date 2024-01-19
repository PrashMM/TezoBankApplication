namespace Models
{
    public static class Constants
    {
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string filePath = Path.Combine(folderPath, "AtmAccHolder1.json");
        public static string filePathForTransaction = Path.Combine(folderPath, "AtmTransaction1.json");
        public const string welcomeMessage = "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*\nHello Sir/Madam, Welcome to ATM Bank\n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*";
        public const string seperateLine = "--------------------------------------------------";
        public const string chooseOperation = "Choose Any Below Options to Proceed\n Press 1 to Open your account\n Press 2 to Login to your account \n Press 3 to Exit";
        public const string enterFollowingDetails = "Please enter the following details to open your account";
        public const string enterFullName = "*-* Enter your Full Name *-*";
        public const string enterMobileNumber = "*-* Enter your Mobile Number *-*";
        public const string enterLocation = "*-* Enter your Location *-*";
        public const string enterPincode = "*-* Enter Pincode *-*";
        public const string enterAadharCardNumber = "*-* Enter your Aadhar Card Number *-*";
        public const string enterAccountNumber = "*-* Enter the Account Number *-*";
        public const string accountOperations = "--> Press 1 to Check Balance,\n--> Press 2 to Credit amount to your account,\n--> Press 3 to Debit amount from your account,\n--> Press 4 to Edit account details,\n--> Press 5 to Transfer Amount\n--> Press 6 to Transaction History\n--> Press 7 to Help Service. \n--> Press 8 to To Create another account \n--> Press 9 to Display all Account holders details \n--> Press 10 to Exit";
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
        public const string enterToUpdateDetails = "** Press 1 to Update Name,\n** Press 2 to Update Address";
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
        public const string incorrectMobileNumber = "The provided mobile number already exists or is not valid. Please enter a different mobile number.";
        public const string amountIs0orLess = "The amount you entered is either 0 or less. Please enter a valid amount.";
        public const string cannotWithdrawMorethanCurrentbalanace = "Sorry,you entered 0 or amount entered is more than your current balance";
        public const string cannotTransferMorethanCurrentbalanace = "Sorry, you cannot transfer more than your current balance";
        public const string enterValidName = "Please enter valid name";
        public const string accNotFoundOrAccNumisSame = "Account not found or you are attempting to transfer the amount within the same account.";
        public const string enterValidAddress = "Please enter valid Address";
    }
}
