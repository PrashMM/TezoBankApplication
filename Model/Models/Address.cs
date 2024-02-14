
namespace Models.Models;

public partial class Address
{
    public string Id { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Pincode { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public Address()
    {

    }
    public Address(String address, string pincode)
    {
        Location = address;
        Pincode = pincode;
    }
}
