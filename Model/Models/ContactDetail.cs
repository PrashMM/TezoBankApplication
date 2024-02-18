namespace Models.Models;

public partial class ContactDetail
{
    public string Id { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AddressId { get; set; } = null!;

    public virtual ICollection<AccountHolder> AccountHolders { get; set; } = new List<AccountHolder>();

    public virtual Address Address { get; set; } = null!;
}
