using ATM_console_app.Data;
using ATM_console_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ATM_console_app.Services
{
     class AccountService
    {

        public bool CheckAccountExistence(string accountNumber)
        {
            return AccountData.AccountHoldersDetails.Any(holder => holder.AccountDetails.AccountNumber == accountNumber);
        }

    }
}
