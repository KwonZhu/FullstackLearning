using Microsoft.EntityFrameworkCore;

namespace Practice5.Models
{
    public class MoocDBContext : DbContext
    {
        public MoocDBContext(DbContextOptions<MoocDBContext> options) : base(options) 
        { 
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
