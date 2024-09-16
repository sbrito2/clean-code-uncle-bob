using System.Collections.Immutable;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class ResourceTypeMapping  : IEntityTypeConfiguration<ResourceType>
    {
        public void Configure(EntityTypeBuilder<ResourceType> builder)
        {
            builder.ToTable("RESOURCE_TYPE");
            builder.Property(a => a.Id).HasColumnName("RET_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Description).HasColumnName("RET_DESCRIPTION").IsRequired();
            builder.Property(a => a.Description).HasColumnName("RET_DESCRIPTION").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("RET_CREATED_AT").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("RET_UPDATE_AT").IsRequired();
            builder.Property(a => a.Active).HasColumnName("RET_ACTIVE").IsRequired();
        }
    }
}