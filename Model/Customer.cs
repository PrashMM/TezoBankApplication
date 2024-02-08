using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }  // Primary key
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string AadharNumber { get; set; }

        public Address AddressDetails { get; set; }
        public Account AccountDetails { get; set; }

        public double InitialAmount { get; set; }

        public string AccountHolderId { get; set; }

    }

}
