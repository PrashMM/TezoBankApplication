using ATM_console_app.Data;
using ATM_console_app.Models;
using ATM_console_app.Services.Interfaces;
using Newtonsoft.Json;

namespace ATM_console_app.Services
{
    public class JsonFileService  : IJsonFileService
    {
        public void CheckForAccountHolderFile()
        {
            if (!File.Exists(Constants.filePath))
            {
                UpdateHolderDetails(AccountData.AccountHoldersDetails);
            }
            else
            {
                List<AccountHolder> existingData = ReadHolderDetails();
                UpdateHolderDetails(existingData);
                AccountData.AccountHoldersDetails.AddRange(existingData);
            }
        }

        public void CheckForTransactionFile()
        {
            if (!File.Exists(Constants.filePathForTransaction))
            {
                UpdateTransactionsData(AccountData.Transactions);
            }
            else
            {
                List<Transaction> existingData = ReadTransactions();
                UpdateTransactionsData(existingData);
                AccountData.Transactions.AddRange(existingData);
            }
        }

        public List<AccountHolder> ReadHolderDetails()
        {
            string existingJson = File.ReadAllText(Constants.filePath);
            if (string.IsNullOrEmpty(existingJson)) return new List<AccountHolder>();
            return JsonConvert.DeserializeObject<List<AccountHolder>>(existingJson);
        }

        public void UpdateHolderDetails(List<AccountHolder> accountHolder)    
        {
            string serializedData = JsonConvert.SerializeObject(accountHolder, Formatting.Indented);
            File.WriteAllText(Constants.filePath, serializedData);
        }

        public List<Transaction> ReadTransactions()
        {
            string existingData = File.ReadAllText(Constants.filePathForTransaction);
            if (string.IsNullOrEmpty(existingData)) return new List<Transaction>();
            return JsonConvert.DeserializeObject<List<Transaction>>(existingData);
        }

        public void UpdateTransactionsData(List<Transaction> transactions)    
        {
            string serializedData = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(Constants.filePathForTransaction, serializedData);
        }


    }
}
