using API.Domain.CoreLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class CustomerMapping  : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");
            builder.Property(a => a.Id).HasColumnName("CUS_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.Name).HasColumnName("CUS_NAME").HasMaxLength(180).IsRequired();
            builder.Property(a => a.Email).HasColumnName("CUS_EMAIL").HasMaxLength(100).IsRequired();
            builder.Property(a => a.Message).HasColumnName("CUS_DESCRIPTION").HasMaxLength(300).IsRequired();
            builder.Property(a => a.Telephone).HasColumnName("CUS_MOBILE_NUMBER").HasMaxLength(13);
            builder.Property(a => a.CreatedAt).HasColumnName("CUS_CREATED_AT").IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("CUS_UPDATE_AT");
            builder.Property(a => a.Active).HasColumnName("CUS_ACTIVE").IsRequired();
            builder.Property(a => a.PropertyId).HasColumnName("PRO_ID").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID");

            builder.HasOne(x => x.Property).WithMany(x => x.Customers);
        }
    }
}