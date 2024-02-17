using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AccountDetails
    {
        [Key]
        public string Id { get; set; }

        public string AccountNumber { get; set; }             
        public double Balance { get; set; }
        public double InitialAmount { get; set; }
        public AccountType AccountType { get; set; }
    }
}
