using System;
using API.Domain.CoreLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Domain.DatabaseMapping
{
    public class UserMapping  : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.Property(x => x.Id).HasColumnName("USE_ID").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("USE_NAME").HasMaxLength(180).IsRequired();
            builder.Property(x => x.Email).HasColumnName("USE_EMAIL").HasMaxLength(180).IsRequired();
            builder.Property(x => x.MobileNumber).HasColumnName("USE_MOBILE_NUMBER").HasMaxLength(180);
            builder.Property(x => x.Description).HasColumnName("USE_DESCRIPTION").HasMaxLength(300);
            builder.Property(x => x.Birth).HasColumnName("USE_BIRTH");
            builder.Property(x => x.Rg).HasColumnName("USE_RG").HasMaxLength(10);
            builder.Property(x => x.Cpf).HasColumnName("USE_CPF").HasMaxLength(11);
            builder.Property(x => x.Password).HasColumnName("USE_PASSWORD").HasMaxLength(20).IsRequired();
            builder.Property(x => x.ProfileId).HasColumnName("PRF_ID").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("USE_CREATED_AT").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("USE_UPDATE_AT");
            builder.Property(x => x.Active).HasColumnName("USE_ACTIVE").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("USE_ID_ALT");

            builder.HasMany(x => x.Actions).WithOne(x => x.User);
            builder.HasMany(x => x.Properties).WithOne(x => x.User);
            builder.HasOne(x => x.Profile).WithMany(x => x.Users);
        }
    }
}