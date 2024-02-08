

using Data;
using Models;
using Services.Interfaces;

namespace Services
{

    public class AccountDetailsService : IAccountDetailsService
    {
        private static TransactionService transactionService;
        private static JsonFileService jsonFileService;

        public AccountDetailsService()
        {
            transactionService = new TransactionService();
            jsonFileService = new JsonFileService();
        }
        public void AddHolderDetails(AccountHolder holder)
        {
            using (var context = new AccountHolderDbContext())
            {
                AccountData.AccountHoldersDetails.Add(holder);
                jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);

                holder.AccountHolderId = holder.CustomerDetails.AccountDetails.AccountNumber;
                holder.CustomerDetails.AccountHolderId = holder.CustomerDetails.AccountDetails.AccountNumber;
                holder.CustomerDetails.AccountDetails.AccountHolderId = holder.CustomerDetails.AccountDetails.AccountNumber;
                holder.CustomerDetails.CustomerId = holder.CustomerDetails.AccountDetails.AccountNumber;
                holder.CustomerDetails.AddressDetails.AddressId = holder.CustomerDetails.AccountDetails.AccountNumber;
                holder.CustomerDetails.AddressDetails.AccountHolderId = holder.CustomerDetails.AccountDetails.AccountNumber;

                context.accountHolder.Add(holder);
                context.SaveChanges();
            }
        }

        public void UpdateName(AccountHolder accountHolder, string newName)
        {
            using (var context = new AccountHolderDbContext())
            {
                //accountHolder.CustomerDetails.FullName = newName ?? "";
                //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);

                var accHolder = context.customers.FirstOrDefault(e => e.CustomerId == accountHolder.AccountHolderId);
                if(accHolder != null)
                {
                    accHolder.FullName = newName ?? "";
                    context.SaveChanges();
                }
            }
        }

        public void UpdateAddress(AccountHolder accountHolder, string newAddress)
        {
            using (var context = new AccountHolderDbContext())
            {
                //accountHolder.CustomerDetails.AddressDetails.Location = newAddress ?? "";
                //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);

                var accHolder = context.addresses.FirstOrDefault(e => e.AddressId == accountHolder.AccountHolderId);
                if (accHolder != null)
                {
                    accHolder.Location = newAddress ?? "";
                    context.SaveChanges();
                }
            }
        }

        public AccountHolder GetAccountHolderByAccNumber(string accountNum)
        {
            using (var context = new AccountHolderDbContext())
            {
                //  return AccountData.AccountHoldersDetails.Find(e => e.CustomerDetails.AccountDetails.AccountNumber.Equals(accountNum));
                //var accHolder =  context.accountHolder.Find(e => e.CustomerDetails.AccountDetails.AccountNumber.Equals(accountNum));
                //return accHolder;

                var accHolder = context.accountHolder.FirstOrDefault(e => e.CustomerDetails.AccountDetails.AccountNumber == accountNum);
                return accHolder;
            }
        }


        public void PerformDeposit(AccountHolder accountHolder, int amount)
        {
            using (var context = new AccountHolderDbContext())
            {
                //accountHolder.CustomerDetails.AccountDetails.Balance += amount;
                //transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Credit, null);
                //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
                //jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);

                var holderAccount = context.account.FirstOrDefault(e => e.AccountHolderId == accountHolder.AccountHolderId);
                if (holderAccount!= null)
                {                          
                    holderAccount.Balance += amount;
                    context.SaveChanges();
                    transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Credit, null);
                }            
            }
        }

        public void PerformWithdraw(AccountHolder accountHolder, int amount)
        {
            using (var context = new AccountHolderDbContext())
            {
                //accountHolder.CustomerDetails.AccountDetails.Balance -= amount;
                //transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Debit, null);
                //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
                //jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);

                var holderAccount = context.account.FirstOrDefault(e => e.AccountHolderId == accountHolder.AccountHolderId);
                if (holderAccount != null)
                {
                    holderAccount.Balance -= amount;
                    context.SaveChanges();
                    transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Debit, null);
                }
            }          
        }

        public bool MobileNumberExistsOrNot(string number)
        {
           // return AccountData.AccountHoldersDetails.Where(e => e.CustomerDetails.MobileNumber.Equals(number)).Any();
            using(var context = new AccountHolderDbContext())
            {
                return context.customers.Where(e => e.MobileNumber.Equals(number)).Any();
            }
        }

        public void PerformTransferAmount(AccountHolder userAccount, AccountHolder receiverAccount, int transferAmount)
        {
            //userAccount.CustomerDetails.AccountDetails.Balance -= transferAmount;
            //receiverAccount.CustomerDetails.AccountDetails.Balance += transferAmount;
            //transactionService.CreateTransactionHistory(transferAmount, userAccount, TransferType.Transfer, receiverAccount);
            //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            //jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);


            using(var context= new AccountHolderDbContext())
            {
                var userAcc =  context.account.FirstOrDefault(e => e.AccountHolderId == userAccount.AccountHolderId);
                var receiverAcc = context.account.FirstOrDefault(e => e.AccountHolderId == receiverAccount.AccountHolderId);
                userAcc.Balance -= transferAmount;
                receiverAcc.Balance += transferAmount;
                context.SaveChanges();
                transactionService.CreateTransactionHistory(transferAmount, userAccount, TransferType.Transfer, receiverAccount);

            }
        }

        public void UpdateLastModifiedTime(AccountHolder accountHolder)
        {
            using (var context = new AccountHolderDbContext())
            {
                accountHolder.LastModifiedOn = DateTime.UtcNow;
                var holder = context.accountHolder.FirstOrDefault(e => e.AccountHolderId == accountHolder.AccountHolderId);
                holder.LastModifiedOn = DateTime.UtcNow;
                context.SaveChanges();
            }            
        }
    }
}

