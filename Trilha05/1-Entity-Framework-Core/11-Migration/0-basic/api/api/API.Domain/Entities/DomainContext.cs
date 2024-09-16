using Microsoft.EntityFrameworkCore;
using PDG.Domain.Entities;

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
            optionsBuilder.UseMySQL("server=localhost;database=auctionSystem;user=root;password=local");
    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}