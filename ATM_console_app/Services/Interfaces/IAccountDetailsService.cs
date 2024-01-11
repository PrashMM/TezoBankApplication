using ATM_console_app.Models;

namespace ATM_console_app.Services.Interfaces
{
    public interface IAccountDetailsService
    {
        public void AddHolderDetails(AccountHolder holder);
        public void UpdateName(AccountHolder accountHolder, string newName);
        public void UpdateAddress(AccountHolder accountHolder, string newAddress);
        public AccountHolder GetAccountHolderByAccNumber(String accountNum);
        public void PerformDeposit(AccountHolder accountHolder, int amount);
        public void PerformWithdraw(AccountHolder accountHolder, int amount);
        public bool MobileNumberExistsOrNot(string number);
        public void PerformTransferAmount(AccountHolder accountHolder, AccountHolder receiverAccount, int transferAmount);
        public void UpdateLastModifiedTime(AccountHolder accountHolder);

    }
}
