using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Application.Interface;
using KarateBooking.Domain.Entities.User;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.Booking.Commands.Update
{
    public class UpdateBookingHandler : ICommandHandler<UpdateBookingCommand, BookingDto>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        public UpdateBookingHandler(IBookingRepository bookingRepository, IEventRepository eventRepository,
            IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }
        public async Task<BookingDto> Handle(UpdateBookingCommand command)
        {
            var bookingEntity= await _bookingRepository.GetByIdAsync(command.Id)
                ?? throw new NotFoundException("Rezervacija s tim ID-jem ne postoji");
            var eventEntity = await _eventRepository.GetByIdAsync(bookingEntity.EventId)
                ?? throw new NotFoundException("Dogadjaj s tim ID-jem ne postoji");
            var userEntity = await _userRepository.GetByIdAsync(bookingEntity.UserId);
            var oldQuantity = bookingEntity.Quantity;
            eventEntity.ReleaseSeats(oldQuantity);
            try
            {
                eventEntity.ReserveSeats(command.NewQuantity);
            }
            catch (BusinessRuleException)
            {
                eventEntity.ReserveSeats(oldQuantity);
                throw;
            }
            bookingEntity.UpdateQuantity(command.NewQuantity);
            await _bookingRepository.UpdateAsync(bookingEntity);
            return BookingDto.FromEntity(bookingEntity, userEntity.FullName ?? "", eventEntity.Name);
        }
    }
}
