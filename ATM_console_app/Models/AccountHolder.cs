using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    class Customer
    {
        private string name;

        public string FullName
        {
            get { return name; }
            set { name = "Mr/Mrs. " + value; }
        }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string AadharNumber { get; set; }
    }

    class Account
    {
        public string AccountNumber { get; set; }
        public double InitialAmount { get; set; }
        public double Balance { get; set; }
    }

    class AccountHolder
    {
        public Customer CustomerDetails { get; set; }
        public Account AccountDetails { get; set; }

        public AccountHolder(string fullName, string mobileNumber, string address, string aadharNumber, string accountNumber, double initialAmount, double balance)
        {
            CustomerDetails = new Customer
            {
                FullName = fullName,
                MobileNumber = mobileNumber,
                Address = address,
                AadharNumber = aadharNumber
            };

            AccountDetails = new Account
            {
                AccountNumber = accountNumber,
                InitialAmount = initialAmount,
                Balance = balance
            };
        }
    }
}

