using System.ComponentModel.DataAnnotations;

namespace HuaMoney.Models
{
    public class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

    }
}
