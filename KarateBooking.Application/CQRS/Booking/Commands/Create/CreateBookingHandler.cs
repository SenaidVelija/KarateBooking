using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Application.Interface;
using KarateBooking.Domain.Entities.Booking;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.Booking.Commands.Create
{
    public class CreateBookingHandler : ICommandHandler<CreateBookingCommand, BookingDto>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        public CreateBookingHandler(IBookingRepository bookingRepository, IEventRepository eventRepository,
            IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }
        public async Task<BookingDto> Handle(CreateBookingCommand command)
        {
            var userEntity = await _userRepository.GetByIdAsync(command.UserId)
                ?? throw new NotFoundException("Korisnik ne postoji.");

            var eventEntity = await _eventRepository.GetByIdAsync(command.EventId)
                ?? throw new NotFoundException("Dogadjaj ne postoji.");
            eventEntity.ReserveSeats(command.Quantity);
            var bookingEntity = BookingEntity.Create(command.UserId, command.EventId, command.Quantity);
            await _eventRepository.UpdateAsync(eventEntity);
            await _bookingRepository.AddAsync(bookingEntity);
           
            return BookingDto.FromEntity(bookingEntity, userEntity.FullName, eventEntity.Name);
        }
    }
}
