using Microsoft.EntityFrameworkCore;

namespace HuaMoney.Models
{
    public class HuaMoneyContext : DbContext
    {
        public HuaMoneyContext(DbContextOptions<HuaMoneyContext> options) : base(options)
        {

        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }



    }
}
