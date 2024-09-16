using Microsoft.EntityFrameworkCore;

namespace LazyLoading.Entities
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanItem> LoanItems { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=LibraryBD;Username=postgres;Password=local");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>( entity =>
            {
                entity.HasKey(x => x.ID);
                entity.Property(x => x.Name).IsRequired();;
                entity.Property(x => x.Country);
                entity.Property(x => x.Description).IsRequired();
                entity.HasMany(e => e.Books).WithOne(e => e.Author);
            });

            modelBuilder.Entity<Book>( entity =>
            {
                entity.HasKey(x => x.ID);
                entity.Property(x => x.Title).IsRequired();
                entity.HasOne(e => e.Author).WithMany(e => e.Books);
                entity.HasMany(e => e.LoanItems).WithOne(e => e.Book);
            });

            modelBuilder.Entity<Loan>( entity =>
            {
                entity.HasKey(x => x.ID);
                entity.Property(x => x.Date).IsRequired();
                entity.HasMany(e => e.LoanItems).WithOne(e => e.Loan);
                entity.HasOne(e => e.Member).WithMany(e => e.Loans);
            });

            modelBuilder.Entity<LoanItem>( entity =>
            {
                entity.HasKey(x => x.ID);
                entity.Property(x => x.ReturnDate).IsRequired();
                entity.HasOne(e => e.Book).WithMany(e => e.LoanItems);
                entity.HasOne(e => e.Loan).WithMany(e => e.LoanItems);
            });

            modelBuilder.Entity<Member>( entity =>
            {
                entity.HasKey(x => x.ID);
                entity.Property(x => x.Name).IsRequired();
                entity.Property(x => x.Course).IsRequired();
                entity.Property(x => x.UniversityID).IsRequired();
            });
        }
    }
}