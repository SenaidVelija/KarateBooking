using KarateBooking.Domain.Entities.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Infrastructure.Repositories
{
    public class EventRepository : GenericRepository<EventEntity>, IEventRepository
    {
        private readonly IDbContextFactory<KarateBookingDbContext> _contextFactory;

        public EventRepository(IDbContextFactory<KarateBookingDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

    }
}
