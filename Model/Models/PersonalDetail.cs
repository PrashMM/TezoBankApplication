namespace Models.Models;

public partial class PersonalDetail
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int Age { get; set; }

    public int Gender { get; set; }

    public int AadharNumber { get; set; }

    public string PanCardNumber { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public virtual ICollection<AccountHolder> AccountHolders { get; set; } = new List<AccountHolder>();
}
