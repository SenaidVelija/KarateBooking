using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;

namespace KarateBooking.Application.CQRS.Booking.Queries.GetList
{
    public class GetBookingListQuery : IQuery<List<BookingDto>>
    {
    }
}
