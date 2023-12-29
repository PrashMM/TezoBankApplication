using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    public class AccountModel
    {
        public string AccountNumber { get; set; }
        public double InitialAmount { get; set; }
        public double Balance { get; set; }
    }
}
