namespace ATM_console_app.Models
{

    public class AccountHolder
    {
        public Customer CustomerDetails { get; set; }
        public Account AccountDetails { get; set; }

        public AccountHolder( string fullName, string mobileNumber, string addressName, string pincode, string aadharNumber, string accountNumber, double initialAmount, double balance)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException(Constants.UnableToCreateAccountNumber, nameof(fullName));
            }

            CustomerDetails = new Customer
            {
                FullName = fullName,
                MobileNumber = mobileNumber,
                AadharNumber = aadharNumber,
                InitialAmount = initialAmount,
                AddressDetails = new Address{
                    Location = addressName,
                    Pincode = pincode
                }
                  
            };

            AccountDetails = new Account
            {
                AccountNumber = accountNumber,
                Balance = balance
            };
        }
    }
}

