using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    public class Constants
    {
        public static string welcomeMessage = "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*\nHello Sir/Madam, Welcome to ATM Bank\n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*";
        public static String seperateLine = "--------------------------------------------------";
        public static String chooseOperation = "Choose Any Below Options to Proceed\n Press 1 to Open your account\n Press 2 to Exit";
        public static String enterFollowingDetails = "Please enter the following details to open your account";
        public static String enterFullName = "Enter your Full Name";
        public static String enterMobileNum = "Enter your Mobile Number";
        public static String enterAddress = "Enter your Permanent Address";
        public static String enterAadharCardNum = "Enter your Aadhar Card Number";
        public static String enterAccountNum = "Enter the Account Number";
        public static String accountOperations = "Press 1 to Credit amount to your account,\nPress 2 to Debit amount from your account\nPress 3 to Edit account details\nPress 4 to Help \nPress 5 to Exit";
        public static String checkAllDetails = "Here are the Details you entered. Please check all the Details correct or Not ";
        public static String ifCorrectPressYToProcced = "if everything is correct, Type 'Y' to proceed";
        public static String enterAmountToCredit= "Enter the Amount You want to Credit";
        public static String enterAmountToDebit = "Enter the Amount You want to Debit";
        public static String editAccountDetails = "Edit account Details";
        public static String getHelp = "Get Help Service";
        public static String writeEmailandQuery = "Please write your e-mail id and Query";
        public static String teamWillReachOutToYou = "Thank you, Our team will look into this matter and reach out to you shortly.";
    }
}
