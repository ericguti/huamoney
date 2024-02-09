using System.ComponentModel.DataAnnotations;

namespace HuaMoney.Models
{
    public class Transaction
    {
        public Transaction(){}
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Recipient { get; set; }
        public string Concept { get; set; }
        public string Currency { get; set; }
        public decimal AccountAmountAfter {get; set;}
        public long AccountId {get; set;}
        public virtual Account Account{get; set;} 
    }
}
