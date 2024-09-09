using Microsoft.EntityFrameworkCore;

namespace Project_Battery.Models
{
    public class PurchaseDbContext : DbContext
    {
        public PurchaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Purchase> PurchaseInfo { get; set; }


    }
}
