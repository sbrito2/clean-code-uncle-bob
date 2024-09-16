using API.Domain.CoreLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class ActionMapping  : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("action");
            builder.Property(a => a.Id).HasColumnName("ACT_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Date).HasColumnName("ACT_DATE").IsRequired();
            builder.Property(a => a.ActionTypeId).HasColumnName("ATY_ID").IsRequired();
            builder.Property(a => a.PropertyId).HasColumnName("PRO_ID").IsRequired();
            builder.Property(a => a.UserId).HasColumnName("USE_ID").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("ACT_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("ACT_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("ACT_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");
        }
    }
}
