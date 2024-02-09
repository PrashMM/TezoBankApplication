using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Account
    {
        [Key]
        public string AccountNumber { get; set; }             // Primary Key
        public double Balance { get; set; }
    }
}
