using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Application.Interface;


namespace KarateBooking.Application.CQRS.Booking.Queries.GetList
{
    public class GetBookingListQueryHandler : IQueryHandler<GetBookingListQuery, List<BookingDto>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        public GetBookingListQueryHandler(IBookingRepository bookingRepository, IEventRepository eventRepository
            , IUserRepository userRepository)
        {
            _bookingRepository= bookingRepository;
            _eventRepository = eventRepository;
            _userRepository= userRepository;
        }
        public async Task<List<BookingDto>> Handle(GetBookingListQuery query)
        {
            var bookings = await _bookingRepository.GetAllAsync();
            var result = new List<BookingDto>();

            foreach (var booking in bookings)
            {
                var eventEntity = await _eventRepository.GetByIdAsync(booking.EventId);
                var userEntity = await _userRepository.GetByIdAsync(booking.UserId);

                result.Add(BookingDto.FromEntity(
                    booking,
                    userEntity?.FullName ?? "Nepoznat korisnik",
                    eventEntity?.Name ?? "Nepoznat dogadjaj"));
            }

            return result;
        }
    }
}
