using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class StateMapping  : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("state");
            builder.Property(a => a.Id).HasColumnName("STA_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.Name).HasColumnName("STA_NAME").HasMaxLength(50).IsRequired();
            builder.Property(a => a.Abreviation).HasColumnName("STA_ABREVIATION").HasMaxLength(2).IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("STA_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("STA_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("STA_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");

            builder.HasMany(x => x.Cities).WithOne(x => x.State);
        }
    }
}