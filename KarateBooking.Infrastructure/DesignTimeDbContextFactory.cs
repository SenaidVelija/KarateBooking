using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KarateBooking.Infrastructure.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KarateBookingDbContext>
    {
        public KarateBookingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KarateBookingDbContext>();

            optionsBuilder.UseSqlServer("Server=F0RKY;Database=KarateBookingDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new KarateBookingDbContext(optionsBuilder.Options);
        }
    }
}