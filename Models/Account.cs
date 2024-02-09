using HuaMoney.Models;

namespace HuaMoney.Models
{
    public class Account
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}