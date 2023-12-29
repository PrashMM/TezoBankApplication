using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{

    public class AccountHolder
    {
        public CustomerModel CustomerDetails { get; set; }
        public AccountModel AccountDetails { get; set; }
        public AddressModel AddressDetails { get; set; }

        public AccountHolder( string fullName, string mobileNumber, string addressName, string aadharNumber, string accountNumber, double initialAmount, double balance)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be null or empty.", nameof(fullName));
            }

            CustomerDetails = new CustomerModel
            {
                FullName = fullName,
                MobileNumber = mobileNumber,
                AadharNumber = aadharNumber
            };

            AccountDetails = new AccountModel
            {
                AccountNumber = accountNumber,
                InitialAmount = initialAmount,
                Balance = balance
            };

            AddressDetails = new AddressModel
            {
                AddressName = addressName
            };
        }

        public static void SaveToFile(List<AccountHolder> accountHolders, string filePath)
        {
            string json = JsonConvert.SerializeObject(accountHolders, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<AccountHolder> LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<AccountHolder>>(json);
            }

            return new List<AccountHolder>();
        }
    }
}

