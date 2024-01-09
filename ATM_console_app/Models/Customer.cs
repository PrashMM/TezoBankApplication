namespace ATM_console_app.Models
{
    public class Customer
    {

        private string name;

        public string FullName
        {
            get { return name; }
            set { name = $"Mr/Mrs {value}"; }
        }
        public string MobileNumber { get; set; }
        public string AadharNumber { get; set; }
        public Address AddressDetails { get; set; }
        public double InitialAmount { get; set; }

    }

}
