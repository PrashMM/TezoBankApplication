using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Address
    {
        [Key]
        public string Id { get; set; }        
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
    }
}
