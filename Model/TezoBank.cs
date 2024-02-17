using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TezoBank
    { 
        public static List<AccountHolder> AccountHolders { get; set; } = new List<AccountHolder>();

        public TezoBank()
        {

        }
    }
}

