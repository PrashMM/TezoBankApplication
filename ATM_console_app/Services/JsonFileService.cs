using ATM_console_app.Models;
using ATM_console_app.Services.Interfaces;
using Newtonsoft.Json;

namespace ATM_console_app.Services
{
    public class JsonFileService : IJsonFileService
    {
        public void UpdateJson(List<AccountHolder> accountHolderList)
        {
            string updatedJson = JsonConvert.SerializeObject(accountHolderList);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, "account.json");

            File.WriteAllText(filePath, updatedJson);
        }


        public void CreateJSONDocument(List<AccountHolder> accountHolderDetailsList)
        {
            string JSONresult = JsonConvert.SerializeObject(accountHolderDetailsList);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, "account.json");
            File.WriteAllText(filePath, JSONresult);
        }

        public void TransactionHistory(List<Transaction> transactionList)
        {
            string JSONresult = JsonConvert.SerializeObject(transactionList);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, "transaction.json");
            File.WriteAllText(filePath, JSONresult);
        }

        public void UpdateTransactionFile(List<Transaction> transaction)
        {
            string updatedJson = JsonConvert.SerializeObject(transaction);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(folderPath, "transaction.json");

            File.WriteAllText(filePath, updatedJson);
        }
    }
}
