using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    class AccountHolder
    {
        public AccountHolder(string fullName,int mobileNum, string? address, int aadharNum, string? accountNum )
        {
            
            FullName = fullName;
            MobileNum = mobileNum;
            Address = address;
            AadharNum = aadharNum;
            AccountNum = accountNum;
        }

        
        public string? FullName { get; set; }
        public int MobileNum { get; set; }
        public string? Address { get; set; }
        public int AadharNum { get; set; }
        public string? AccountNum { get; set; }
    }
}

