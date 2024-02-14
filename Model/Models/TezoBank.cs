
namespace Models.Models;

public class TezoBank
{
    public string Id { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public TezoBank()
    {

    }
    public TezoBank(string id, Customer customer)
    {
        Id = id;
        CustomerId = customer.Id;
        Customer = customer;
    }
}
