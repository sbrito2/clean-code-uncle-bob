using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class BidMapping  : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("bid");
            builder.Property(a => a.Id).HasColumnName("BID_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Date).HasColumnName("BID_DATE").IsRequired();
            builder.Property(a => a.Value).HasColumnName("BID_VALUE").HasColumnType("decimal(8,2)").IsRequired().IsRequired();
            builder.Property(a => a.ActionId).HasColumnName("ACT_ID").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("BID_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("BID_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("BID_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");
        }
    }
}