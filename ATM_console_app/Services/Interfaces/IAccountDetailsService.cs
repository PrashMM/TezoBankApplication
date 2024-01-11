using ATM_console_app.Models;

namespace ATM_console_app.Services.Interfaces
{
    public interface IAccountDetailsService
    {
        public void AddHolderDetails(AccountHolder holder);
        public AccountHolder UpdateName(AccountHolder accountHolder, string newName);
        public AccountHolder UpdateAddress(AccountHolder accountHolder, string newAddress);
        public AccountHolder GetAccountHolderByAccNumber(String accountNum);
        public AccountHolder PerformDeposit(AccountHolder accountHolder, int amount);
        public AccountHolder PerformWithdraw(AccountHolder accountHolder, int amount);
        public bool MobileNumberExistsOrNot(string number);

    }
}
