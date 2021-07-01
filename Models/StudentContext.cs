using Microsoft.EntityFrameworkCore;
namespace EFCore.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }  
    }
}