using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class ActionMapping  : IEntityTypeConfiguration<API.Domain.Entities.Action>
    {
        public void Configure(EntityTypeBuilder<API.Domain.Entities.Action> builder)
        {
            builder.ToTable("ACTION");
            builder.Property(a => a.Id).HasColumnName("ACT_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Date).HasColumnName("ACT_DATE").IsRequired();
            builder.Property(a => a.InitialBid).HasColumnName("ACT_INITIAL_BID");
            builder.Property(a => a.ActionTypeId).HasColumnName("ATY_ID").IsRequired();
            builder.Property(a => a.PropertyId).HasColumnName("PRO_ID").IsRequired();
            builder.Property(a => a.UserId).HasColumnName("USE_ID").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("ACT_CREATED_AT").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("ACT_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("ACT_ACTIVE").IsRequired();
        }
    }
}
