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

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Rental> Rental { get; set; }
        public virtual DbSet<RentalCar> RentalCar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;user=root;password=local;database=carrental");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.Property(e => e.CarId)
                    .HasColumnName("CAR_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CarColor)
                    .IsRequired()
                    .HasColumnName("CAR_COLOR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasColumnName("CAR_MODEL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CarPlate)
                    .IsRequired()
                    .HasColumnName("CAR_PLATE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CarPrice)
                    .HasColumnName("CAR_PRICE")
                    .HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PRIMARY");

                entity.ToTable("customer");

                entity.Property(e => e.CusId)
                    .HasColumnName("CUS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CarCpf)
                    .IsRequired()
                    .HasColumnName("CAR_CPF")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CusName)
                    .IsRequired()
                    .HasColumnName("CUS_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => e.RenId)
                    .HasName("PRIMARY");

                entity.ToTable("rental");

                entity.HasIndex(e => e.CusId)
                    .HasName("IX_RENTAL_CUS_ID");

                entity.Property(e => e.RenId)
                    .HasColumnName("REN_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CusId)
                    .HasColumnName("CUS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RenReturn).HasColumnName("REN_RETURN");

                entity.Property(e => e.RenStart).HasColumnName("REN_START");

                entity.Property(e => e.RenStatus)
                    .HasColumnName("REN_STATUS")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Rental)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK_RENTAL_CUSTOMER_CUS_ID");
            });

            modelBuilder.Entity<RentalCar>(entity =>
            {
                entity.HasKey(e => e.RecId)
                    .HasName("PRIMARY");

                entity.ToTable("rental_car");

                entity.HasIndex(e => e.CusId)
                    .HasName("IX_RENTAL_CAR_CUS_ID");

                entity.HasIndex(e => e.RenId)
                    .HasName("IX_RENTAL_CAR_REN_ID");

                entity.Property(e => e.RecId)
                    .HasColumnName("REC_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CusId)
                    .HasColumnName("CUS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RenId)
                    .HasColumnName("REN_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.RentalCar)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK_RENTAL_CAR_CAR_CUS_ID");

                entity.HasOne(d => d.Ren)
                    .WithMany(p => p.RentalCar)
                    .HasForeignKey(d => d.RenId)
                    .HasConstraintName("FK_RENTAL_CAR_RENTAL_REN_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
