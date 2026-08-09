using KarateBooking.Application.Interfaces;
using KarateBooking.Domain.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.Interface
{
    public interface IBookingRepository : IGenericRepository<BookingEntity>
    {
    }
}
