using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class uSERMapping  : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USER");
            builder.Property(a => a.Id).HasColumnName("USE_ID").ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasColumnName("USE_name").HasMaxLength(180).IsRequired();
            builder.Property(a => a.Email).HasColumnName("USE_EMAIL").HasMaxLength(180).IsRequired();
            builder.Property(a => a.Description).HasColumnName("USE_DESCRIPTION").HasMaxLength(300);
            builder.Property(a => a.Birth).HasColumnName("USE_BIRTH");
            builder.Property(a => a.Rg).HasColumnName("USE_RG").HasMaxLength(10).IsRequired();
            builder.Property(a => a.Cpf).HasColumnName("USE_CPF").HasMaxLength(11).IsRequired();
            builder.Property(a => a.PhotoFront).HasColumnName("USE_PHOTO_FRONT").HasMaxLength(250);
            builder.Property(a => a.Password).HasColumnName("USE_PASSWORD").HasMaxLength(20).IsRequired();
            builder.Property(a => a.ProfileId).HasColumnName("PRF_ID").IsRequired();
            builder.Property(a => a.CreatedAt).HasColumnName("USE_CREATED_AT").ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.UpdatedAt).HasColumnName("USE_UPDATE_AT").IsRequired();
            builder.Property(a => a.Active).HasColumnName("USE_ACTIVE").IsRequired();
        }
    }
}