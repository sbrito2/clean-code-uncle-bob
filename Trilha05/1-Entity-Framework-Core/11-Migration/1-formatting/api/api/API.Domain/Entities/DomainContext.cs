using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Domain.Entities
{
    public class DomainContext : DbContext
    {
        DbSet<Action> Actions { get; set; }
        DbSet<ActionType> ActionTypes { get; set; }
        DbSet<Bid> Bids { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<PropertyType> PropertyTypes { get; set; }
        DbSet<Resource> Resources { get; set; }
        DbSet<State> States { get; set; }
        DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=auction_system;user=root;password=local");
    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}