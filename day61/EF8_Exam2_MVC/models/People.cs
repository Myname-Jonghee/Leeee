using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using EF8_Exam2_MVC.Models;

namespace EF8_Exam2_MVC.Models
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<People> Peoples { get; set; }
    }
}
