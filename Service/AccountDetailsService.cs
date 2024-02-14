

using Data;
using Models;
using Models.Models;
using Services.Interfaces;
﻿
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
        public void AddHolderDetails(TezoBank holder)
        {
            using (var context = new AccountHolder1Context())
            {
                AccountData.AccountHoldersDetails.Add(holder.Customer);
                jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);

                holder.Id = holder.Customer.AccountDetailsAccountNumberNavigation.AccountNumber;
                holder.Customer.AccountNumber = holder.Customer.AccountDetailsAccountNumberNavigation.AccountNumber;
                holder.Customer.Id = holder.Customer.AccountDetailsAccountNumberNavigation.AccountNumber;
                holder.Customer.AddressId = holder.Customer.AccountDetailsAccountNumberNavigation.AccountNumber;
                holder.Customer.Address.Id = holder.Customer.AccountDetailsAccountNumberNavigation.AccountNumber;

                context.TezoBanks.Add(holder);
                context.SaveChanges();
            }
        }

        public void UpdateName(Customer accountHolder, string newName)
        {
            using (var context = new AccountHolder1Context())
            {
                //accountHolder.CustomerDetails.FullName = newName ?? "";
                //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);

                var accHolder = context.Customers.FirstOrDefault(c => c.Id == accountHolder.Id);
                if (accHolder != null)
                {
                    accHolder.FullName = newName ?? "";
                    context.SaveChanges();
                }
            }
        }

        public void UpdateAddress(Customer accountHolder, string newAddress)
        {
            using (var context = new AccountHolder1Context())
            {
                //accountHolder.CustomerDetails.AddressDetails.Location = newAddress ?? "";
                //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);

                var accHolder = context.Addresses.FirstOrDefault(a => a.Id == accountHolder.Id);
                if (accHolder != null)
                {
                    accHolder.Location = newAddress ?? "";
                    context.SaveChanges();
                }
            }
        }

        public Customer GetAccountHolderByAccNumber(string accountNum)
        {
            using (var context = new AccountHolder1Context())
            {
                //  return AccountData.AccountHoldersDetails.Find(e => e.CustomerDetails.AccountDetails.AccountNumber.Equals(accountNum));
                //var accHolder =  context.accountHolder.Find(e => e.CustomerDetails.AccountDetails.AccountNumber.Equals(accountNum));
                //return accHolder;

                var accHolder = context.Customers.FirstOrDefault(e => e.AccountDetailsAccountNumberNavigation.AccountNumber == accountNum);
                return accHolder;
            }
        }


        public void PerformDeposit(Customer accountHolder, int amount)
        {
            using (var context = new AccountHolder1Context())
            {
                //accountHolder.CustomerDetails.AccountDetails.Balance += amount;
                //transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Credit, null);
                //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
                //jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);

                var holderAccount = context.Accounts.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);
                if (holderAccount != null)
                {
                    holderAccount.Balance += amount;
                    context.SaveChanges();
                    transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Credit, null);
                }
            }
        }

        public void PerformWithdraw(Customer accountHolder, int amount)
        {
            using (var context = new AccountHolder1Context())
            {
                //accountHolder.CustomerDetails.AccountDetails.Balance -= amount;
                //transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Debit, null);
                //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
                //jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);

                var holderAccount = context.Accounts.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);
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
            using (var context = new AccountHolder1Context())
            {
                return context.Customers.Where(e => e.MobileNumber.Equals(number)).Any();
            }
        }

        public void PerformTransferAmount(Customer userAccount, Customer receiverAccount, int transferAmount)
        {
            //userAccount.CustomerDetails.AccountDetails.Balance -= transferAmount;
            //receiverAccount.CustomerDetails.AccountDetails.Balance += transferAmount;
            //transactionService.CreateTransactionHistory(transferAmount, userAccount, TransferType.Transfer, receiverAccount);
            //jsonFileService.UpdateData(AccountData.AccountHoldersDetails, Constants.filePath);
            //jsonFileService.UpdateData(AccountData.Transactions, Constants.filePathForTransaction);


            using (var context = new AccountHolder1Context())
            {
                var userAcc = context.Accounts.FirstOrDefault(e => e.AccountNumber == userAccount.Id);
                var receiverAcc = context.Accounts.FirstOrDefault(e => e.AccountNumber == receiverAccount.Id);
                userAcc.Balance -= transferAmount;
                receiverAcc.Balance += transferAmount;
                context.SaveChanges();
                transactionService.CreateTransactionHistory(transferAmount, userAccount, TransferType.Transfer, receiverAccount);

            }
        }

        public void UpdateLastModifiedTime(Customer accountHolder)
        {
            using (var context = new AccountHolder1Context())
            {
                accountHolder.LastModifiedOn = DateTime.UtcNow;
                var holder = context.Customers.FirstOrDefault(e => e.Id == accountHolder.Id);
                holder.LastModifiedOn = DateTime.UtcNow;
                context.SaveChanges();
            }
        }
    }
}
