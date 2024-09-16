using API.Domain.CoreLogic.Entities;
using API.Domain.CoreLogic.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Action = API.Domain.CoreLogic.Entities.Action;

namespace API.Infraestructure.Data.Context
{
    public class DomainContext : DbContext
    {
        internal DbSet<Action> Actions { get; set; }
        internal DbSet<ActionType> ActionTypes { get; set; }
        internal DbSet<Bid> Bids { get; set; }
        internal DbSet<City> Cities { get; set; }
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<Profile> Profiles { get; set; }
        internal DbSet<Property> Properties { get; set; }
        internal DbSet<PropertyType> PropertyTypes { get; set; }
        internal DbSet<Resource> Resources { get; set; }
        internal DbSet<State> States { get; set; }
        internal DbSet<User> Users { get; set; }
        protected int? UserId;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("server=198.12.252.214;port=3306;database=auction_system;user=root; password=root;");
            optionsBuilder.UseMySQL("server=localhost;database=auction_system;user=root;password=local");
        }

        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            this.FilterActiveEntities(modelBuilder);
        }

        public void FilterActiveEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.CoreLogic.Entities.Action>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<ActionType>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<Bid>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<City>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<Profile>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<Property>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<PropertyType>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<Resource>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<State>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<User>().HasQueryFilter(p => p.Active);
            modelBuilder.Entity<Customer>().HasQueryFilter(p => p.Active);
        }

        public void SetUserId(int userId)
        {
            this.UserId = userId;
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatus();
            UpdateTimestamps();
            return base.SaveChanges();
        }

        private void UpdateSoftDeleteStatus()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["Active"] = true;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues["Active"] = true;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["Active"] = false;
                        break;
                }
            }
        }

        private void UpdateTimestamps()
        {
            IEnumerable<ITimestampedModel> including = this.ChangeTracker.Entries()
                            .Where(x => x.State == EntityState.Added && x.Entity is ITimestampedModel)
                            .Select(x => x.Entity as ITimestampedModel);

            IEnumerable<ITimestampedModel> updating = this.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified && x.Entity is ITimestampedModel)
                .Select(x => x.Entity as ITimestampedModel);

            foreach (ITimestampedModel item in including)
            {
                item.CreatedAt = DateTime.UtcNow;
                item.UpdatedAt = DateTime.UtcNow;
                // item.UserId = this.UserId;
            }

            foreach (ITimestampedModel item in updating)
            {
                item.UpdatedAt = DateTime.UtcNow;
                // item.UserId = this.UserId;
            }
        }
    }
}