using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class ActionTypeMapping  : IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder.ToTable("ACTION_TYPE");
            builder.Property(a => a.Id).HasColumnName("ATY_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Description).HasColumnName("ATY_DESCRIPTION").HasMaxLength(300).IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("ATY_CREATED_AT").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("ATY_UPDATE_AT").IsRequired();
            builder.Property(a => a.Active).HasColumnName("ATY_ACTIVE").IsRequired();
        }
    }
}
