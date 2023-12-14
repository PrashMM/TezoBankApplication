using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    public enum MainMenu
    {
        OpenAccount = 1,
        Exit,
    }

    public enum ATMOperation
    {
        CheckBalance,
        Deposit,
        Withdraw,
        EditAccountDetails,
        TakeHelp,
        OpenAccount,
        Exit
    }

    public enum UpdateDetails
    {
        UpdateName,
        UpdateAddress
    }
}
