using Microsoft.EntityFrameworkCore;

namespace console2.Entities
{
    public class MyContext : DbContext 
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=onlineCourse3;user=root;password=local");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                entity.HasMany(e => e.Exams).WithOne(e => e.Student).OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Subject).IsRequired();
                entity.HasOne(e => e.Student).WithMany(x => x.Exams);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.HasMany(e => e.Students).WithOne(e => e.Course).OnDelete(DeleteBehavior.Cascade);
            });     
        }
    }
}