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
            builder.ToTable("property");
            builder.Property(a => a.Id).HasColumnName("PRO_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.Title).HasColumnName("PRO_TITLE").IsRequired();
            builder.Property(a => a.Bathrooms).HasColumnName("PRO_BATHROOMS");
            builder.Property(a => a.Bedrooms).HasColumnName("PRO_BEDROOMS");
            builder.Property(a => a.ParkingSpaces).HasColumnName("PRO_PARKING_SPACES");
            builder.Property(a => a.Description).HasColumnName("PRO_DESCRIPTION").HasMaxLength(150).IsRequired();
            builder.Property(a => a.ApartmentNumber).HasColumnName("PRO_APARTMENT_NUMBER");
            builder.Property(a => a.Area).HasColumnName("PRO_AREA").HasColumnType("decimal(11,4)");
            builder.Property(a => a.PhotosPath).HasColumnName("PRO_PHOTOS_PATH").HasMaxLength(250);
            builder.Property(a => a.BaseValue).HasColumnName("PRO_BASE_VALUE").IsRequired();
            builder.Property(a => a.InitialBid1).HasColumnName("PRO_INITIAL_BID_1");
            builder.Property(a => a.InitialBid2).HasColumnName("PRO_INITIAL_BID_2");
            builder.Property(a => a.Address).HasColumnName("PRO_ADDRESS").HasMaxLength(250).IsRequired();
            builder.Property(a => a.Number).HasColumnName("PRO_NUMBER").HasMaxLength(15);
            builder.Property(a => a.Cep).HasColumnName("PRO_CEP").HasMaxLength(10);
            builder.Property(a => a.CityId).HasColumnName("CIT_ID").IsRequired();
            builder.Property(a => a.PropertyTypeId).HasColumnName("PRT_ID").IsRequired();
            builder.Property(a => a.ActionTypeId).HasColumnName("ATY_ID");
            builder.Property(a => a.Latitude).HasColumnName("PRO_LATITUDE");
            builder.Property(a => a.Longitude).HasColumnName("PRO_LONGITUDE");
            builder.Property(a => a.StreetViewUrl).HasColumnName("PRO_STREET_VIEW_URL").HasMaxLength(300);
            builder.Property(a => a.CreatedAt).HasColumnName("PRO_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("PRO_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("PRO_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");
            builder.Property(x => x.IsPopular).HasColumnName("PRO_IS_POPULAR");

            builder.HasOne(x => x.User).WithMany(x => x.Properties);
            builder.HasOne(x => x.City).WithMany(x => x.Properties);
            builder.HasOne(x => x.ActionType).WithMany(x => x.Properties);
            builder.HasMany(x => x.Resources).WithOne(x => x.Property);
            
            builder.HasMany(x => x.Actions).WithOne(x => x.Property);
        }
    }
}