using KarateBooking.Domain.Entities.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Infrastructure.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                 .IsRequired()
                 .HasMaxLength(150);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(e => e.StartDate)
                .IsRequired();
            builder.Property(e => e.EndDate)
                .IsRequired();
            builder.Property(e => e.EventType)
                .HasConversion<string>()
                .IsRequired();
            builder.Property(e=>e.EventStatus)
                .HasConversion<string>()
                .IsRequired();
            builder.Property(e => e.Price)
                .IsRequired();
            builder.Property(e => e.Capacity)
                .IsRequired();
        }
    }
}
