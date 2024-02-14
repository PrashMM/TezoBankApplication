
namespace Models.Models;

public class Account
{
    public string AccountNumber { get; set; } = null!;

    public double Balance { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public Account()
    {

    }
    public Account(string accountNum, double balance)
    {
        AccountNumber = accountNum;
        Balance = balance;
    }
}
