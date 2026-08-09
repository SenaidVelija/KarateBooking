using KarateBooking.Domain.Entities.Booking;
using KarateBooking.Domain.Entities.Event;
using KarateBooking.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Infrastructure
{
    public class KarateBookingDbContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }

        public KarateBookingDbContext(DbContextOptions<KarateBookingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KarateBookingDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
