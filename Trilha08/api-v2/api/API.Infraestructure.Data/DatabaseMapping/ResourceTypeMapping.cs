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
            builder.ToTable("resource_type");
            builder.Property(a => a.Id).HasColumnName("RET_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Description).HasColumnName("RET_DESCRIPTION").IsRequired();
            builder.Property(a => a.Description).HasColumnName("RET_DESCRIPTION").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("RET_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("RET_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("RET_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");
        }
    }
}