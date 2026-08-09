using KarateBooking.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        private readonly IDbContextFactory<KarateBookingDbContext> _contextFactory;

        public UserRepository(IDbContextFactory<KarateBookingDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

    }
}
