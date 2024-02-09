using System.ComponentModel.DataAnnotations;

namespace HuaMoney.Models
{
    public class Bank
    {
        public Bank(){
            
        }
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
