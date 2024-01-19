namespace ATM_console_app.Models
{
    public class Customer
    {

        public string FullName{ get; set; }
        public string MobileNumber { get; set; }
        public string AadharNumber { get; set; }
        public Address AddressDetails { get; set; }
        public double InitialAmount { get; set; }
     
    }

}
