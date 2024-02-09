using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }                       // Primary key
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string AadharNumber { get; set; }


        [ForeignKey("Address")]  
        public string AddressId { get; set; } 
        public virtual Address AddressDetails { get; set; } 


        [ForeignKey("Account")]
        public string AccountNumber { get; set; }
        public virtual Account AccountDetails { get; set; }


        public double InitialAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }


        public Customer()
        {
        }

        public Customer(string fullName, string mobileNumber, string addressName, string pincode, string aadharNumber, string accountNumber, double initialAmount, double balance)
        {
            Id = accountNumber;
            FullName = fullName;
            MobileNumber = mobileNumber;
            AadharNumber = aadharNumber;
            InitialAmount = initialAmount;
            CreatedOn = DateTime.UtcNow;
            LastModifiedOn = DateTime.UtcNow;

            AccountDetails = new Account
            {
                AccountNumber = accountNumber,
                Balance = balance
            };

                AddressDetails = new Address
                {
                    Id = accountNumber,
                    Location = addressName,
                    Pincode = pincode
                };
        }

    }

}
