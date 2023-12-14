using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    public static class Constants
    {
        public const string welcomeMessage = "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*\nHello Sir/Madam, Welcome to ATM Bank\n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*";
        public const string seperateLine = "--------------------------------------------------";
        public const string chooseOperation = "Choose Any Below Options to Proceed\n Press 1 to Open your account\n Press 2 to Exit";
        public const string enterFollowingDetails = "Please enter the following details to open your account";
        public const string enterFullName = "*-* Enter your Full Name *-*";
        public const string enterMobileNumber = "*-* Enter your Mobile Number *-*";
        public const string enterAddress = "*-* Enter your Permanent Address *-*";
        public const string enterAadharCardNumber = "*-* Enter your Aadhar Card Number *-*";
        public const string enterAccountNumber = "*-* Enter the Account Number *-*";
        public const string accountOperations = "--> Press 1 to Check Balance,\n--> Press 2 to Credit amount to your account,\n--> Press 3 to Debit amount from your account\n--> Press 4 to Edit account details\n--> Press 5 to Help \n--> Press 6 to To Create another account \n--> Press 7 to Exit";
        public const string checkAllDetails = "Here are the Details you entered. Please check all the Details correct or Not ";
        public const string ifCorrectPressYToProcced = "<-> <-> if everything is correct, Type 'Y' to proceed <-> <->";
        public const string checkAccountBalance = "Check Your Account Balance Here";
        public const string yourBalanceIs = "Your balance is ";
        public const string enterAmountToCredit= "Enter the Amount You want to Credit";
        public const string enterAmountToDebit = "Enter the Amount You want to Debit";
        public const string editAccountDetails = "Edit account Details";
        public const string getHelp = "Get Help Service";
        public const string writeEmailandQuery = "Please write your e-mail id and Query";
        public const string teamWillReachOutToYou = "Thank you, Our team will look into this matter and reach out to you shortly.";
        public const string accountNotFound = "Account Not Found";
        public const string enterToUpdateDetails= "** Press 1 to Update Name,\n** Press 2 to Update Address";
        public const string enterNameToUpdate = "Enter name to update";
        public const string enterAddressToUpdate = "Enter Address to update";
        public const string thankYou = "You are good to go. Thank You :) ";
        public const string insufficientBalance = "Insufficient Balance";
    }
}
