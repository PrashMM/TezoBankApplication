﻿using Models;

namespace Services.Interfaces
{
    public interface ITransactionService
    {
        public bool CheckTransactionHistoryIsEmptyOrNot();
        public void AddToTransactionHistory(Transaction newTransaction);
        public List<Transaction> CurrentHolderTransactionHistory(AccountHolder accountHolder);
        public void CreateTransactionHistory(int amount, AccountHolder holder, TransferType type, AccountHolder receieverAccount);
    }
}
