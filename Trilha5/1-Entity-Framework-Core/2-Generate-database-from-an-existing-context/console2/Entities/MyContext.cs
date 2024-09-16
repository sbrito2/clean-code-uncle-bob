using Microsoft.EntityFrameworkCore;

namespace console2.Entities
{
    public class MyContext : DbContext 
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=onlineCourse;user=root;password=local");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Age).IsRequired();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.HasMany(e => e.Students).WithOne(e => e.Course);
            });     
        }
    }
}