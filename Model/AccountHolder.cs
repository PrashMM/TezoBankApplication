namespace Models
{

    public class AccountHolder
    {
        public Customer CustomerDetails { get; set; }
        public Account AccountDetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }


        public AccountHolder(string fullName, string mobileNumber, string addressName, string pincode, string aadharNumber, string accountNumber, double initialAmount, double balance)
        {

            CustomerDetails = new Customer
            {
                FullName = fullName,
                MobileNumber = mobileNumber,
                AadharNumber = aadharNumber,
                InitialAmount = initialAmount,
                AddressDetails = new Address
                {
                    Location = addressName,
                    Pincode = pincode
                }

            };

            AccountDetails = new Account
            {
                AccountNumber = accountNumber,
                Balance = balance
            };

            CreatedOn = DateTime.UtcNow;
            LastModifiedOn = DateTime.UtcNow;
        }
    }
}

