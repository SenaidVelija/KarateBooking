using KarateBooking.Application.Interface;
using KarateBooking.Domain.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Infrastructure.Repositories
{
    public class BookingRepository : GenericRepository<BookingEntity>, IBookingRepository
    {
        private readonly IDbContextFactory<KarateBookingDbContext> _contextFactory;

        public BookingRepository(IDbContextFactory<KarateBookingDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

    }
}
