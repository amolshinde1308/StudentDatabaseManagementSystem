using Microsoft.EntityFrameworkCore;
using StudentDetails.Models;

namespace StudentDetails.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StudentData> Students { get; set; }
    }
}
