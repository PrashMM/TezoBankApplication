﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Address
    {
        [Key]
        public string AddressId { get; set; } // Primary Key
        public string Location { get; set; }
        public string Pincode { get; set; }
        public string AccountHolderId { get; set; }
    }
}
