namespace Models
{
    public enum MainMenu
    {
        OpenAccount = 1,
        Login,
        Exit,
    }

    public enum ATMOperation
    {
        CheckBalance,
        Deposit,
        Withdraw,
        EditAccountDetails,
        TransferAmount,
        TransactionHistory,
        TakeHelp,
        OpenAccount,
        Login,
        HoldersList,
        Exit
    }

    public enum UpdateDetails
    {
        UpdateName,
        UpdateAddress,
        UpdateAge
    }

    public enum TransferType
    {
        Credit,
        Debit,
        Transfer
    }

    public enum Gender
    {
        Male = 1,
        Female,
        Others
    }

    public enum AccountType
    {
        SavingsAccount = 1,
        SalaryAccount,
        Others
    }
}