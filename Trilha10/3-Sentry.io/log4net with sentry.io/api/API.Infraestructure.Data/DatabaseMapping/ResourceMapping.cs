using System.Collections.Immutable;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class ResourceMapping  : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("resource");
            builder.Property(a => a.Id).HasColumnName("RES_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.Description).HasColumnName("RES_DESCRIPTION").HasMaxLength(300).IsRequired();
            builder.Property(a => a.Value).HasColumnName("RES_VALUE").IsRequired();
            builder.Property(a => a.ResourceTypeId).HasColumnName("RET_ID").IsRequired();
            builder.Property(a => a.PropertyId).HasColumnName("PRO_ID").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("RES_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("RES_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("RES_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");
        }
    }
}