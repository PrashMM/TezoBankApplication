
using Models;
using Models.Models;

namespace Services.Interfaces
{
    public interface IAccountDetailsService
    {
        public void AddHolderDetails(AccountHolder holder);
        public void UpdateName(AccountHolder accountHolder, string newName);
        public void UpdateAddress(AccountHolder accountHolder, string newAddress);
        public void UpdateAge(AccountHolder accountHolder, int newAge);
        public AccountHolder GetAccountHolderByAccNumber(string accountNum);
        public void PerformDeposit(AccountHolder accountHolder, int amount);
        public void PerformWithdraw(AccountHolder accountHolder, int amount);
        public bool MobileNumberExistsOrNot(string number);
        public void PerformTransferAmount(AccountHolder accountHolder, AccountHolder receiverAccount, int transferAmount);
        public void UpdateLastModifiedTime(AccountHolder accountHolder);

    }
}