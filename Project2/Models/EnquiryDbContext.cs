using Microsoft.EntityFrameworkCore;

namespace Project_Battery.Models
{
    public partial class EnquiryDbContext : DbContext
    {
        public EnquiryDbContext()
        {
        }
        public EnquiryDbContext(DbContextOptions<EnquiryDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        public DbSet<Enquiry> Enquiries { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
