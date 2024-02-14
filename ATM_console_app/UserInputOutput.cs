using Data;
using Models;
using Models.Models;

public class UserInputOutput
{
    public bool IsAccountDetailsCorrect(Customer holder, string dataIsCorrect)
    {
        Console.WriteLine(Constants.seperateLine);
        return dataIsCorrect.ToLower().Equals("y");
    }

    public void ShowAccountDetails(Customer holder)
    {
        Console.WriteLine(Constants.checkAllDetails);
        Console.WriteLine($"*+*+* Account Number: {GenerateAccountNumber(holder)} \n*+*+* Name: {holder.FullName} \n*+*+* Mobile Number:{holder.MobileNumber} \n*+*+* Location: {holder.Address.Location} \n*+*+* Pincode: {holder.Address.Pincode} \n*+*+* Aadhar Number = {holder.AadharNumber} ");
        Console.WriteLine(Constants.ifCorrectPressYToProcced);
    }

    public string GenerateAccountNumber(Customer holder)
    {
        var uniqueValue = holder.MobileNumber.ToString();
        holder.AccountDetailsAccountNumberNavigation.AccountNumber = $"ACCX{holder.FullName[0]}{uniqueValue[0]}{uniqueValue[1]}";
        return holder.AccountDetailsAccountNumberNavigation.AccountNumber;
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

        //foreach (var accountHolder in AccountData.AccountHoldersDetails)
        //{
        //    Console.WriteLine(Constants.seperateLine);
        //    Console.WriteLine($"Account Number: {accountHolder.AccountDetails.AccountNumber}");
        //    Console.WriteLine($"Full Name: {accountHolder.CustomerDetails.FullName}");
        //    Console.WriteLine($"Mobile Number: {accountHolder.CustomerDetails.MobileNumber}");
        //    Console.WriteLine($"Balance: {accountHolder.AccountDetails.Balance}");
        //    Console.WriteLine($"Created on: {accountHolder.CreatedOn}");
        //    Console.WriteLine($"Last Modified on : {accountHolder.LastModifiedOn}");
        //    Console.WriteLine(Constants.seperateLine);
        //    Console.WriteLine();
        //}

        using (var context = new AccountHolder1Context())
        {
            foreach (var customer in context.Customers)
            {
                Console.WriteLine(Constants.seperateLine);
                Console.WriteLine($"Account Number: {customer.Id}");
                Console.WriteLine($"Full Name: {customer.FullName}");
                Console.WriteLine($"Mobile Number: {customer.MobileNumber}");
                Console.WriteLine($"Created on: {customer.CreatedOn}");
                Console.WriteLine($"Last Modified on : {customer.LastModifiedOn}");
                Console.WriteLine(Constants.seperateLine);
                Console.WriteLine();
            }

        }
    }

    public static void PrintAmount(Customer accountHolder)
    {
        // Console.WriteLine($"{Constants.yourBalanceIs} {accountHolder.CustomerDetails.AccountDetails.Balance}");
        //   Console.WriteLine(Constants.thankYou);

        using (var context = new AccountHolder1Context())
        {
            var holder = context.Accounts.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);
            Console.WriteLine($"{Constants.yourBalanceIs} {holder.Balance}");
            Console.WriteLine(Constants.thankYou);
        }
    }

    public static void DisplayTransationHistory(Transaction transaction)
    {
        switch (transaction.Type)
        {
            case 2: // TransferType.Transfer:
                //     Console.WriteLine($"At {transaction.Time}, {transaction.Amount} has been transferred from {transaction.UserAccount.CustomerDetails.AccountDetails.AccountNumber} to {transaction.ReceiverAccount.CustomerDetails.AccountDetails.AccountNumber}");
                Console.WriteLine($"At {transaction.Time}, {transaction.Amount} has been transferred from {transaction.UserAccountId} to {transaction.ReceiverAccountId}");

                break;

            case 0: // TransferType.Credit:
                //    Console.WriteLine($"At {transaction.Time}, {transaction.Amount} has been credited to {transaction.UserAccount.CustomerDetails.AccountDetails.AccountNumber}");
                Console.WriteLine($"At {transaction.Time}, {transaction.Amount} has been credited to {transaction.UserAccountId}");
                break;

            default:
                //  Console.WriteLine($"At {transaction.Time}, {transaction.Amount} has been debited from {transaction.UserAccount.CustomerDetails.AccountDetails.AccountNumber}");
                Console.WriteLine($"At {transaction.Time}, {transaction.Amount} has been debited from {transaction.ReceiverAccountId}");
                break;
        }
    }


}