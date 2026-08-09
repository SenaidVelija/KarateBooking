using KarateBooking.Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KarateBooking.Infrastructure.Persistence.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
               .ValueGeneratedOnAdd();

            builder.Property(b => b.Quantity)
                .IsRequired();

            builder.Property(b => b.BookingDate)
                .IsRequired();

            builder.Property(b => b.Status)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}