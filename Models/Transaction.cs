using System.ComponentModel.DataAnnotations;

namespace HuaMoney.Models
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }
    }
}
