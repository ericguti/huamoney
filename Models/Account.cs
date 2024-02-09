using HuaMoney.Models;

namespace HuaMoney.Models
{
    public class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }
        // TODO
        public long Id { get; set; }
        public string Name { get; set; }
        public string  AccountNumber{ get; set; }
        public string  Currency{ get; set; }
        public decimal Amount { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long BankId {get; set;}
        public virtual Bank Bank {get; set;}
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}