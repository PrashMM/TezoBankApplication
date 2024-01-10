using ATM_console_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Services.Interfaces
{
    public interface IJsonFileService 
    {
        public void UpdateJson(List<AccountHolder> accountHolderList);
        public void CreateJSONDocument(List<AccountHolder> accountHolderDetailsList);
        public void TransactionHistory(List<Transaction> transactionList);
        public void UpdateTransactionFile(List<Transaction> transaction);
    }
}
