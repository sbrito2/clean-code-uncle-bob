using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class ActionTypeMapping  : IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder.ToTable("action_type");
            builder.Property(a => a.Id).HasColumnName("ATY_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Type).HasColumnName("ATY_TYPE").IsRequired();
            builder.Property(a => a.Description).HasColumnName("ATY_DESCRIPTION").HasMaxLength(300).IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("ATY_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("ATY_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("ATY_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");
        }
    }
}
