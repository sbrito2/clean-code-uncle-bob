using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace console.Models
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

        public virtual DbSet<Beverage> Beverage { get; set; }
        public virtual DbSet<BeverageType> BeverageType { get; set; }
        public virtual DbSet<Coffe> Coffe { get; set; }
        public virtual DbSet<CoffeGift> CoffeGift { get; set; }
        public virtual DbSet<Mershandise> Mershandise { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=db_coffe_store;user id=postgres;Password=local");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beverage>(entity =>
            {
                entity.HasKey(e => e.BevId)
                    .HasName("BEVERAGE_pkey");

                entity.ToTable("BEVERAGE");

                entity.Property(e => e.BevId)
                    .HasColumnName("BEV_ID")
                    .HasIdentityOptions(null, null, null, 999999999L, null, null)
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BetId).HasColumnName("BET_ID");

                entity.Property(e => e.BevDate)
                    .HasColumnName("BEV_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.BevMilk).HasColumnName("BEV_MILK");

                entity.Property(e => e.BevSoy).HasColumnName("BEV_SOY");

                entity.Property(e => e.CofId).HasColumnName("COF_ID");

                entity.HasOne(d => d.Bet)
                    .WithMany(p => p.Beverage)
                    .HasForeignKey(d => d.BetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BEVERAGE_BET_ID_fkey");

                entity.HasOne(d => d.Cof)
                    .WithMany(p => p.Beverage)
                    .HasForeignKey(d => d.CofId)
                    .HasConstraintName("BEVERAGE_COF_ID_fkey");
            });

            modelBuilder.Entity<BeverageType>(entity =>
            {
                entity.HasKey(e => e.BetId)
                    .HasName("BEVERAGE_TYPE_pkey");

                entity.ToTable("BEVERAGE_TYPE");

                entity.Property(e => e.BetId)
                    .HasColumnName("BET_ID")
                    .HasIdentityOptions(null, null, null, 9999999999999L, true, null)
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BetDescription)
                    .IsRequired()
                    .HasColumnName("BET_DESCRIPTION")
                    .HasMaxLength(500);

                entity.Property(e => e.BetName)
                    .IsRequired()
                    .HasColumnName("BET_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.CogId).HasColumnName("COG_ID");

                entity.HasOne(d => d.Cog)
                    .WithMany(p => p.BeverageType)
                    .HasForeignKey(d => d.CogId)
                    .HasConstraintName("BEVERAGE_TYPE_COG_ID_fkey");
            });

            modelBuilder.Entity<Coffe>(entity =>
            {
                entity.HasKey(e => e.CofId)
                    .HasName("COF_ID");

                entity.ToTable("COFFE");

                entity.Property(e => e.CofId)
                    .HasColumnName("COF_ID")
                    .HasIdentityOptions(null, null, null, 9999999999L, null, null)
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CofCountry)
                    .IsRequired()
                    .HasColumnName("COF_COUNTRY")
                    .HasMaxLength(100);

                entity.Property(e => e.CofDescription)
                    .HasColumnName("COF_DESCRIPTION")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<CoffeGift>(entity =>
            {
                entity.HasKey(e => e.CogId)
                    .HasName("COFFE_GIFT_pkey");

                entity.ToTable("COFFE_GIFT");

                entity.Property(e => e.CogId)
                    .HasColumnName("COG_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CogAmount).HasColumnName("COG_AMOUNT");

                entity.Property(e => e.CogDescription)
                    .IsRequired()
                    .HasColumnName("COG_DESCRIPTION")
                    .HasMaxLength(250);

                entity.Property(e => e.CogName)
                    .IsRequired()
                    .HasColumnName("COG_NAME")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Mershandise>(entity =>
            {
                entity.HasKey(e => e.MerId)
                    .HasName("MERSHANDISE_pkey");

                entity.ToTable("MERSHANDISE");

                entity.Property(e => e.MerId)
                    .HasColumnName("MER_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MerDescription)
                    .IsRequired()
                    .HasColumnName("MER_DESCRIPTION")
                    .HasMaxLength(250);

                entity.Property(e => e.MerName)
                    .IsRequired()
                    .HasColumnName("MER_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.MerPrice)
                    .HasColumnName("MER_PRICE")
                    .HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
