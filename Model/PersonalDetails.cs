using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class PersonalDetails
    {
        [Key]
        public string Id { get; set; }                       

        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int AadharNumber { get; set; }
        public string PanCardNumber { get; set; }
        public string Occupation { get; set; }  
     
    }
}
