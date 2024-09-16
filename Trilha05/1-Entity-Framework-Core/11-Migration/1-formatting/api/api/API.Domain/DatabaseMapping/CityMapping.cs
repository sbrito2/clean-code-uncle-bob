using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class CityMapping  : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("CITY");
            builder.Property(a => a.Id).HasColumnName("CIT_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.Name).HasColumnName("CIT_DATE").HasMaxLength(180).IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("CIT_CREATED_AT").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("CIT_UPDATE_AT").IsRequired();
            builder.Property(a => a.Active).HasColumnName("CIT_ACTIVE").IsRequired();
        }
    }
}