using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Account
    {
        [Key]
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public string AccountHolderId { get; set; }
    }
}
