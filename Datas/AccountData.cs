
using Models;

namespace Data
{
    public class AccountData
    {
        public static List<AccountHolder> AccountHoldersDetails { get; set; } = new List<AccountHolder>();

        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
