using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_console_app.Models
{
    public class CustomerModel
    {
        private string Name;

        public required string FullName
        {
            get { return Name; }
            set { Name = $"Mr/Mrs {value}"; }
        }
        public string MobileNumber { get; set; }
        public string AadharNumber { get; set; }
    }

}
