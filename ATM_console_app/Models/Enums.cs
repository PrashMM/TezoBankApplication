using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    public enum MainMenu
    {
        ToOpenAccount = 1,
        ToExit,
    }

    public enum ATMOperation
    {
        CheckBalance,
        ToCreditAmount,
        DebitAmount,
        EditAccountDetails,
        TakeHelp,
        Exit
    }
}
