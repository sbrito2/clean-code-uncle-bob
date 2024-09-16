using System.Collections.Immutable;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class PropertyTypeMapping  : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.ToTable("PROPERTY_TYPE");
            builder.Property(a => a.Id).HasColumnName("PRT_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Type).HasColumnName("PRT_TYPE").HasMaxLength(180).IsRequired();
            builder.Property(a => a.Description).HasColumnName("PRT_DESCRIPTION").HasMaxLength(300).IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("PRT_CREATED_AT").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("PRT_UPDATE_AT").IsRequired();
            builder.Property(a => a.Active).HasColumnName("PRT_ACTIVE").IsRequired();
        }
    }
}