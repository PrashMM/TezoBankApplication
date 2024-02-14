
using Models.Models;

namespace Data
{
    public class AccountData
    {
        public static List<Customer> AccountHoldersDetails { get; set; } = new List<Customer>();

        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
