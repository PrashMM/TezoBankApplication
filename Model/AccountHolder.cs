using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    public class AccountHolder
    {
        [Key]
        public string AccountHolderId { get; set; }   // Primary Key
        public Customer CustomerDetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }

        public ICollection<Customer> CustomerDetailss { get; set; } = new List<Customer>(); // store collection of customers @Required

        public AccountHolder()
        {
        }

        public AccountHolder(string fullName, string mobileNumber, string addressName, string pincode, string aadharNumber, string accountNumber, double initialAmount, double balance)
        {

            CustomerDetails = new Customer
            {
                CustomerId = accountNumber,
                FullName = fullName,
                MobileNumber = mobileNumber,
                AadharNumber = aadharNumber,
                InitialAmount = initialAmount,

                AccountDetails = new Account
                {
                    AccountNumber = accountNumber,
                    Balance = balance
                },

                AddressDetails = new Address
                {
                    AddressId = accountNumber,
                    Location = addressName,
                    Pincode = pincode
                }            
        };

            CreatedOn = DateTime.UtcNow;
            LastModifiedOn = DateTime.UtcNow;
        }
    }
}

