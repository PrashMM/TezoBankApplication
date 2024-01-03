namespace ATM_console_app.Models
{
    public enum MainMenu
    {
        OpenAccount = 1,
        Exit,
    }

    public enum ATMOperation
    {
        CheckBalance,
        Deposit,
        Withdraw,
        EditAccountDetails,
        TakeHelp,
        OpenAccount,
        HoldersList,
        Exit
    }

    public enum UpdateDetails
    {
        UpdateName,
        UpdateAddress
    }
}
