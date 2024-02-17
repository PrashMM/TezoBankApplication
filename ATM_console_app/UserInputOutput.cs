using Data;
using Models;
using System.Text.RegularExpressions;

public class UserInputOutput
{
    public void ShowAccountDetails(AccountHolder holder)
    {
        Console.WriteLine(Constants.checkAllDetails);
        Console.WriteLine($"*+*+* Account Number: {GenerateAccountNumber(holder)} \n*+*+* Name: {holder.PersonalDetails.FirstName} {holder.PersonalDetails.LastName} \n*+*+* Gender:{holder.PersonalDetails.Gender} \n*+*+* Age:{holder.PersonalDetails.Age} \n*+*+* Mobile Number:{holder.ContactDetails.MobileNumber} \n*+*+* Location: {holder.ContactDetails.Address.City} {holder.ContactDetails.Address.PostalCode} \n*+*+* Initial Amount: {holder.AccountDetails.InitialAmount} \n*+*+* Aadhar Number = {holder.PersonalDetails.AadharNumber} \n*+*+* Created On:{holder.CreatedOn}");
        Console.WriteLine(Constants.ifCorrectPressYToProcced);
    }

    public string GenerateAccountNumber(AccountHolder holder)
    {
        var uniqueValue = holder.ContactDetails.MobileNumber.ToString();
        holder.AccountDetails.AccountNumber = $"ACCX{holder.PersonalDetails.FirstName[0]}{holder.ContactDetails.Address.City[0]}{uniqueValue[0]}{uniqueValue[4]}";
        return holder.AccountDetails.AccountNumber;
    }
    public bool IsAccountDetailsCorrect(AccountHolder holder, string dataIsCorrect)
    {
        Console.WriteLine(Constants.seperateLine);
        return dataIsCorrect.ToLower().Equals("y");
    }

    public void HelpService()
    {
        Console.WriteLine(Constants.writeEmailandQuery);
        Console.ReadLine();
        Console.WriteLine(Constants.teamWillReachOutToYou);
    }

    public void DisplayAllAccountHolders()
    {
        Console.WriteLine("Account Holders : ");

        using (var context = new TezoBankDbContext())
        {
            foreach (var customer in context.PersonalDetails)
            {
                Console.WriteLine(Constants.seperateLine);
                Console.WriteLine($"Account Number: {customer.Id}");
                Console.WriteLine($"Full Name: {customer.FirstName}{customer.LastName}");
                Console.WriteLine($"Age: {customer.Age}");
                Console.WriteLine(Constants.seperateLine);
                Console.WriteLine();
            }

        }
    }

    public static void PrintAmount(AccountHolder accountHolder)
    {
        using (var context = new TezoBankDbContext())
        {
            var holder = context.AccountDetails.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);
            Console.WriteLine($"*** {Constants.yourBalanceIs} {holder.Balance} Rs/-");
            Console.WriteLine(Constants.thankYou);
        }
    }

    public static void DisplayTransationHistory(Transaction transaction)
    {
        switch (transaction.Type)
        {
            case TransferType.Transfer:
                Console.WriteLine($"On {transaction.Time}, {transaction.Amount} has been transferred from {transaction.UserAccountId} to {transaction.ReceiverAccountId}");

                break;

            case TransferType.Credit:
                Console.WriteLine($"On {transaction.Time}, {transaction.Amount} has been credited to {transaction.UserAccountId}");
                break;

            default:
                Console.WriteLine($"On {transaction.Time}, {transaction.Amount} has been debited from {transaction.ReceiverAccountId}");
                break;
        }
    }

    public static bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }

}

