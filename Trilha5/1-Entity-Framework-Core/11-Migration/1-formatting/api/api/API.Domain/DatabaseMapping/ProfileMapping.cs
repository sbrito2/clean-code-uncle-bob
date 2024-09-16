using System.Collections.Immutable;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class ProfileMapping  : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("PROFILE");
            builder.Property(a => a.Id).HasColumnName("PRF_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.Description).HasColumnName("PRF_DESCRIPTION").HasMaxLength(300).IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("PRF_CREATED_AT").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("PRF_UPDATE_AT").IsRequired();
            builder.Property(a => a.Active).HasColumnName("PRF_ACTIVE").IsRequired();
        }
    }
}