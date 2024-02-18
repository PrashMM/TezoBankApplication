namespace Models.Models;

public partial class Address
{
    public string Id { get; set; } = null!;

    public string StreetAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int PostalCode { get; set; }

    public virtual ICollection<ContactDetail> ContactDetails { get; set; } = new List<ContactDetail>();
}
