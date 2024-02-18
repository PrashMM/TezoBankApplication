
using Models;
using Models.Models;
using Services.Interfaces;

namespace Services
{

    public class AccountDetailsService : IAccountDetailsService
    {
        private static TransactionService transactionService;

        public AccountDetailsService()
        {
            transactionService = new TransactionService();
        }

        public void AddHolderDetails(AccountHolder holder)
        {
            try
            {
                using (var context = new TezoBankContext())
                {
                    context.AccountHolders.Add(holder);

                    holder.Id = holder.AccountDetails.AccountNumber;

                    holder.PersonalDetailsId = holder.AccountDetails.AccountNumber;
                    holder.PersonalDetails.Id = holder.AccountDetails.AccountNumber;

                    holder.ContactDetailsId = holder.AccountDetails.AccountNumber;
                    holder.ContactDetails.Id = holder.AccountDetails.AccountNumber;
                    holder.ContactDetails.AddressId = holder.AccountDetails.AccountNumber;
                    holder.ContactDetails.Address.Id = holder.AccountDetails.AccountNumber;

                    holder.AccountDetailsId = holder.AccountDetails.AccountNumber;
                    holder.AccountDetails.Id = holder.AccountDetails.AccountNumber;

                    context.AccountHolders.Add(holder);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
        }

        public void UpdateName(AccountHolder accountHolder, string newName)
        {
            using (var context = new TezoBankContext())
            {
                var accHolder = context.PersonalDetails.FirstOrDefault(c => c.Id == accountHolder.Id);
                if (accHolder != null)
                {
                    accHolder.FirstName = newName ?? "";
                    context.SaveChanges();
                }
            }
        }

        public void UpdateAddress(AccountHolder accountHolder, string newCity)
        {
            using (var context = new TezoBankContext())
            {
                var accHolder = context.Addresses.FirstOrDefault(a => a.Id == accountHolder.Id);
                if (accHolder != null)
                {
                    accHolder.City = newCity ?? "";
                    context.SaveChanges();
                }
            }
        }

        public void UpdateAge(AccountHolder accountHolder, int newAge)
        {
            using (var context = new TezoBankContext())
            {
                var accHolder = context.PersonalDetails.FirstOrDefault(a => a.Id == accountHolder.Id);
                if (accHolder != null)
                {
                    accHolder.Age = newAge;
                    context.SaveChanges();
                }
            }
        }

        public AccountHolder GetAccountHolderByAccNumber(string accountNum)
        {
            using (var context = new TezoBankContext())
            {
                var accHolder = context.AccountHolders.FirstOrDefault(e => e.Id == accountNum);
                return accHolder;
            }
        }

        public void PerformDeposit(AccountHolder accountHolder, int amount)
        {
            using (var context = new TezoBankContext())
            {
                var holderAccount = context.AccountDetails.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);
                if (holderAccount != null)
                {
                    holderAccount.Balance += amount;
                    context.SaveChanges();
                    transactionService.CreateTransactionHistory(amount, accountHolder, TransferType.Credit, null);
                }
            }
        }

        public void PerformWithdraw(AccountHolder accountHolder, int amount)
        {
            using (var context = new TezoBankContext())
            {
                var holderAccount = context.AccountDetails.FirstOrDefault(e => e.AccountNumber == accountHolder.Id);
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
            using (var context = new TezoBankContext())
            {
                return context.ContactDetails.Where(e => e.MobileNumber.Equals(number)).Any();
            }
        }

        public void PerformTransferAmount(AccountHolder userAccount, AccountHolder receiverAccount, int transferAmount)
        {
            using (var context = new TezoBankContext())
            {
                var userAcc = context.AccountDetails.FirstOrDefault(e => e.AccountNumber == userAccount.Id);
                var receiverAcc = context.AccountDetails.FirstOrDefault(e => e.AccountNumber == receiverAccount.Id);
                userAcc.Balance -= transferAmount;
                receiverAcc.Balance += transferAmount;
                context.SaveChanges();
                transactionService.CreateTransactionHistory(transferAmount, userAccount, TransferType.Transfer, receiverAccount);

            }
        }

        public void UpdateLastModifiedTime(AccountHolder accountHolder)
        {
            using (var context = new TezoBankContext())
            {
                var holder = context.AccountHolders.FirstOrDefault(e => e.Id == accountHolder.Id);
                holder.LastModifiedOn = DateTime.UtcNow;
                context.SaveChanges();
            }
        }
    }
}