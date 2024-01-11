﻿using ATM_console_app.Data;
using ATM_console_app.Models;
using ATM_console_app.Services.Interfaces;

namespace ATM_console_app.Services
{
    public class TransactionService : ITransactionService
    {
        private static JsonFileService jsonFileService;

        public TransactionService()
        {
            jsonFileService = new JsonFileService();
        }
        public bool CheckTransactionHistoryIsEmptyOrNot()
        {
           return AccountData.Transactions != null && AccountData.Transactions.Count != 0;
        }

        public void AddToTransactionHistory(Transaction newTransaction)
        {
            AccountData.Transactions.Add(newTransaction);
        }

        public List<Transaction> CurrentHolderTransactionHistory(AccountHolder accountHolder)
        {
            return AccountData.Transactions.Where(e => e.UserAccount.AccountDetails.AccountNumber.Equals(accountHolder.AccountDetails.AccountNumber)).ToList();
        }

        public void CreateTransactionHistory(int amount, AccountHolder holder, TransferType type,AccountHolder receieverAccount )
        {
            var transaction  = new Transaction(DateTime.UtcNow, amount, holder, type, receieverAccount);
            AddToTransactionHistory(transaction);
            jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);
        }

    }
}
