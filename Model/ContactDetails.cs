using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
