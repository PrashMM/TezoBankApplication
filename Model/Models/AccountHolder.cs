namespace Models.Models;

public partial class AccountHolder
{
    public string Id { get; set; } = null!;

    public string PersonalDetailsId { get; set; } = null!;

    public string ContactDetailsId { get; set; } = null!;

    public string AccountDetailsId { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime LastModifiedOn { get; set; }

    public virtual AccountDetail AccountDetails { get; set; } = null!;

    public virtual ContactDetail ContactDetails { get; set; } = null!;

    public virtual PersonalDetail PersonalDetails { get; set; } = null!;

    public virtual ICollection<Transaction> TransactionReceiverAccounts { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionUserAccounts { get; set; } = new List<Transaction>();

    public AccountHolder()
    {
    }

    public AccountHolder(string firstName, string lastName, int age, Gender gender, int aadharNumber, string panNumber, string occupation, string mobileNumber, string email, string streetAddress, string city, string state, int postalCode, string accountNumber, double initialAmount, double balance, AccountType accountType)
    {
        var genderr = gender == Gender.Male ? 1 : gender == Gender.Female ? 2 : 3;
        var accountTypes = accountType == AccountType.SavingsAccount ? 1 : accountType == AccountType.SalaryAccount ? 2 : 3;

        Id = accountNumber;

        PersonalDetails = new PersonalDetail
        {
            Id = accountNumber,
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Gender = genderr,
            AadharNumber = aadharNumber,
            PanCardNumber = panNumber,
            Occupation = occupation

        };

        ContactDetails = new ContactDetail
        {
            Id = accountNumber,
            MobileNumber = mobileNumber,
            Email = email,
            Address = new Address
            {
                Id = accountNumber,
                StreetAddress = streetAddress,
                City = city,
                State = state,
                PostalCode = postalCode
            }
        };

        AccountDetails = new AccountDetail
        {
            Id = accountNumber,
            AccountNumber = accountNumber,
            InitialAmount = initialAmount,
            Balance = balance,
            AccountType = accountTypes,
        };


        CreatedOn = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;
    }
}
