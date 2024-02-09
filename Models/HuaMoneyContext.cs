using Microsoft.EntityFrameworkCore;

namespace HuaMoney.Models
{
    public class HuaMoneyContext : DbContext
    {
        public HuaMoneyContext(DbContextOptions<HuaMoneyContext> options) : base(options) 
        {

        }

        public DbSet<Bank> Banks { get; set; }
    }
}
