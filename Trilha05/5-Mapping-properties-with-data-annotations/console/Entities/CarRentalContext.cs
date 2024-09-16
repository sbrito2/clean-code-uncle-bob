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
            optionsBuilder.UseMySQL("server=localhost;database=CarRental;user=root;password=local");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}