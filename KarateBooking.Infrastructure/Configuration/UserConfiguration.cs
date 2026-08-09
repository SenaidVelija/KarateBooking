using KarateBooking.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KarateBooking.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}