using System.Collections.Immutable;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class PropertyMapping  : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("PROPERTY");
            builder.Property(a => a.Id).HasColumnName("PRO_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.Description).HasColumnName("PRO_DESCRIPTION").HasMaxLength(300).IsRequired();
            builder.Property(a => a.Area).HasColumnName("PRO_AREA").HasColumnType("decimal(11,4)");
            builder.Property(a => a.PhotosPath).HasColumnName("PRO_PHOTOS_PATH").HasMaxLength(250);
            builder.Property(a => a.BaseValue).HasColumnName("PRO_BASE_VALUE");
            builder.Property(a => a.Address).HasColumnName("PRO_ADDRESS").HasMaxLength(250).IsRequired();
            builder.Property(a => a.Number).HasColumnName("PRO_NUMBER").HasMaxLength(15).IsRequired();
            builder.Property(a => a.Cep).HasColumnName("PRO_CEP").HasMaxLength(10).IsRequired();
            builder.Property(a => a.CityId).HasColumnName("CIT_ID").IsRequired();
            builder.Property(a => a.PropertyTypeId).HasColumnName("PRT_ID");
            builder.Property(a => a.Latitude).HasColumnName("PRO_LATITUDE").HasColumnType("decimal(10,8)");
            builder.Property(a => a.Longitude).HasColumnName("PRO_LONGITUDE").HasColumnType("decimal(10,8)");
            builder.Property(a => a.StreetViewUrl).HasColumnName("PRO_STREET_VIEW_URL").HasMaxLength(300);
            builder.Property(a => a.UserId).HasColumnName("USE_ID").IsRequired();
            builder.Property(a => a.Description).HasColumnName("PRO_DESCRIPTION").HasMaxLength(300).IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("PRO_CREATED_AT").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("PRO_UPDATE_AT").IsRequired();
            builder.Property(a => a.Active).HasColumnName("PRO_ACTIVE").IsRequired();
        }
    }
}