using API.Domain.CoreLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class CityMapping  : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("city");
            builder.Property(a => a.Id).HasColumnName("CIT_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.Name).HasColumnName("CIT_NAME").HasMaxLength(50).IsRequired();
            builder.Property(a => a.StateId).HasColumnName("STA_ID").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("CIT_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("CIT_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("CIT_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");

            builder.HasOne(x => x.State).WithMany(x => x.Cities);
        }
    }
}