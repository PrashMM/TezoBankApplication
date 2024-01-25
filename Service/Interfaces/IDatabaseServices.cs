using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDatabaseServices
    {
        public void CreateTable();
        public void AddHoldersInsideTable(AccountHolder holder);
        public void UpdateHolderName(AccountHolder accountHolder, string newName);
        public void UpdateHolderAddress(AccountHolder accountHolder, string newAddress);
        public void UpdateDepositAmount(AccountHolder accountHolder, int amount);
        public void UpdateWithdrawAmount(AccountHolder accountHolder, int amount);
        public void UpdateTransferAmount(AccountHolder accountHolder, AccountHolder receiverAccount, int transferAmount);
        public void UpdateLastModificationTime(AccountHolder accountHolder);
    }
}
