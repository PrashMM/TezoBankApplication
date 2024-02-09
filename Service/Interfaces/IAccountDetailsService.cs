
using Models;

namespace Services.Interfaces
{
    public interface IAccountDetailsService
    {
        public void AddHolderDetails(TezoBank holder);
        public void UpdateName(Customer accountHolder, string newName);
        public void UpdateAddress(Customer accountHolder, string newAddress);
        public Customer GetAccountHolderByAccNumber(string accountNum);
        public void PerformDeposit(Customer accountHolder, int amount);
        public void PerformWithdraw(Customer accountHolder, int amount);
        public bool MobileNumberExistsOrNot(string number);
        public void PerformTransferAmount(Customer accountHolder, Customer receiverAccount, int transferAmount);
        public void UpdateLastModifiedTime(Customer accountHolder);

    }
}
