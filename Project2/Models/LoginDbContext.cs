using Microsoft.EntityFrameworkCore;

namespace Project_Battery.Models
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<SignUpDbContext> options) : base(options)
        {
        }
        public DbSet<Login> Login { get; set; }
    }
}
