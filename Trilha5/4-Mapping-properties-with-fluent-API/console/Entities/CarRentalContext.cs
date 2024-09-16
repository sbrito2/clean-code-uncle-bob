using Microsoft.EntityFrameworkCore;

namespace console.Entities
{
    public class CarRentalContext : DbContext
    {
        DbSet<Car> Cars { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<RentalCar> RentalCars { get; set; }
        DbSet<Rental> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=CarRental;Username=postgres;Password=local");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("CUS_ID");
                entity.Property(e => e.Name).HasColumnName("CUS_NAME").IsRequired().HasMaxLength(100);
                entity.Property(e => e.Cpf).HasColumnName("CUS_CPF").IsRequired().HasMaxLength(10);
                entity.HasMany(e => e.Rentals).WithOne(e => e.Customer);
                entity.ToTable("CUSTOMER");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("CAR_ID");
                entity.Property(e => e.Plate).HasColumnName("CAR_PLATE").IsRequired().HasMaxLength(50);
                entity.Property(e => e.Model).HasColumnName("CAR_MODEL").IsRequired().HasMaxLength(50);
                entity.Property(e => e.Color).HasColumnName("CAR_COLOR").IsRequired().HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnName("CAR_PRICE").IsRequired().HasColumnType("decimal(5,2)");;
                entity.HasMany(e => e.RentalCars).WithOne(e => e.Car);
                entity.ToTable("CAR");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("REN_ID");
                entity.Property(e => e.StartDate).HasColumnName("REN_START").IsRequired();
                entity.Property(e => e.ReturnDate).HasColumnName("REN_RETURN").IsRequired();
                entity.Property(e => e.Status).HasColumnName("REN_STATUS").IsRequired();
                entity.Property(e => e.CustomerId).HasColumnName("CUS_ID").IsRequired();
                entity.HasOne(e => e.Customer).WithMany(e => e.Rentals);
                entity.HasMany(e => e.RentalCars).WithOne(e => e.Rental);
                entity.ToTable("RENTAL");
            });

            modelBuilder.Entity<RentalCar>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("REC_ID");
                entity.Property(e => e.RentalId).HasColumnName("REN_ID").IsRequired();
                entity.Property(e => e.CarId).HasColumnName("CAR_ID").IsRequired();
                entity.HasOne(e => e.Rental).WithMany(e => e.RentalCars);
                entity.HasOne(e => e.Car).WithMany(e => e.RentalCars);
                entity.ToTable("RENTAL_CAR");
            });
        }
    }
}