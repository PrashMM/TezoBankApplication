using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TezoBankApplication.Models;

namespace Models
{
    public class AccountHolder
    {
        [Key]
        public string Id { get; set; }  // Primary key


        [ForeignKey("PersonalDetails")]
        public string PersonalDetailsId { get; set; }
        public virtual PersonalDetails PersonalDetails{ get; set; }


        [ForeignKey("ContactDetails")]  
        public string ContactDetailsId { get; set; } 
        public virtual ContactDetails ContactDetails { get; set; } 


        [ForeignKey("AccountDetails")]
        public string AccountDetailsId { get; set; }
        public virtual AccountDetails AccountDetails { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }


        public AccountHolder()
        {
        }

        public AccountHolder(string firstName, string lastName, int age, Gender gender,int aadharNumber, string panNumber, string occupation, string mobileNumber, string email, string streetAddress, string city, string state, int postalCode, string accountNumber,double initialAmount,double balance, AccountType accountType)
        {
            Id = accountNumber;

            PersonalDetails = new PersonalDetails
            {
                Id = accountNumber,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender,
                AadharNumber = aadharNumber,
                PanCardNumber = panNumber,
                Occupation = occupation

            };

            ContactDetails = new ContactDetails
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
                  
            AccountDetails = new AccountDetails
            {
                 Id = accountNumber,
                 AccountNumber = accountNumber,
                 InitialAmount = initialAmount,
                 Balance = balance,
                 AccountType = accountType,              
            };
                

            CreatedOn = DateTime.UtcNow;
            LastModifiedOn = DateTime.UtcNow;
        }

    }

}
