using ATM_console_app.Models;

namespace ATM_console_app.Data
{
    public class AccountData
    {
       public static List<AccountHolder> AccountHoldersDetails { get; set; } = new List<AccountHolder>();

        public static List<Transaction> TransactionList { get; set; } = new List<Transaction>();
    }
}
