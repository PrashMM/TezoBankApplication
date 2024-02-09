using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TezoBank
    {
        [Key]
        public string Id { get; set; }                          // Primary Key

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }                  // Foreign Key ("Table_Name")
        public virtual Customer CustomerDetails { get; set; }   // Use "virtual" for Non-Column
       

        public TezoBank()
        {
        }


        public TezoBank(string id, Customer customer)
        {
            Id = id;
            CustomerDetails = customer;
        }
    }
}

