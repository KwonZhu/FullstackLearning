using Microsoft.EntityFrameworkCore;

namespace Practice5.Models
{
    public class MoocDBContext : DbContext
    {
        public MoocDBContext(DbContextOptions<MoocDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; } //for JWT

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(c =>
            {
                c.ToTable("Users");
                c.HasKey(x => x.Id);
                c.Property(x => x.UserName).IsRequired().HasMaxLength(50);
                c.Property(x => x.Password).HasMaxLength(200);
                c.Property(x => x.Email).HasMaxLength(200);
                c.Property(x => x.Address).HasMaxLength(500);
                c.Property(x => x.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>(c => 
            { 
                c.HasKey(x => x.Id);
                c.Property(x => x.CategoryName).IsRequired().HasMaxLength(200);
                c.HasMany(x => x.Courses);
            });

            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Course>(c =>
            {
                c.HasKey(x => x.Id);
                c.Property(x => x.CourseName).IsRequired().HasMaxLength(200);
                c.Property(x => x.Description).IsRequired().HasMaxLength(200);
                c.HasOne(x => x.Category);
            });
        }
    }
}
