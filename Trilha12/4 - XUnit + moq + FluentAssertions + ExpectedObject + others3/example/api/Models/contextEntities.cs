using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class contextEntities : DbContext
    {
        public contextEntities()
        {
        }

        public contextEntities(DbContextOptions<contextEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;password=local;database=test");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("PRO_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
