using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TezoBankApplication.Models
{
    public class ContactDetails
    {
        [Key]
        public string Id { get; set; }


        public string MobileNumber { get; set; }
        public string Email { get; set; }


        [ForeignKey("Address")]
        public string AddressId { get; set; }
        public virtual Address Address { get; set; }
    }

}
