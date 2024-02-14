
namespace Models.Models;

public class Customer
{

    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string AadharNumber { get; set; } = null!;

    public string AddressId { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string? AccountDetailsAccountNumber { get; set; }

    public double InitialAmount { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime LastModifiedOn { get; set; }

    public virtual Account? AccountDetailsAccountNumberNavigation { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<TezoBank> TezoBanks { get; set; } = new List<TezoBank>();

    public virtual ICollection<Transaction> TransactionReceiverAccounts { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionUserAccounts { get; set; } = new List<Transaction>();

    public Customer()
    {

    }
    public Customer(string fullName, string mobileNumber, string addressName, string pincode, string aadharNumber, string accountNumber, double balance, double initialAmount)
    {
        Id = accountNumber;
        FullName = fullName;
        MobileNumber = mobileNumber;
        AadharNumber = aadharNumber;
        InitialAmount = initialAmount;
        CreatedOn = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;

        AccountDetailsAccountNumberNavigation = new Account(accountNumber, balance)
        {
            AccountNumber = accountNumber,
            Balance = balance
        };

        Address = new Address(addressName, pincode)
        {
            Id = accountNumber,
            Location = addressName,
            Pincode = pincode
        };
    }
}
