using KarateBooking.Application.Common;
using KarateBooking.Application.Interface;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.Booking.Commands.Cancel
{
    public class CancelBookingHandler : ICommandHandler<CancelBookingCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEventRepository _eventRepository;

        public CancelBookingHandler(IBookingRepository bookingRepository, IEventRepository eventRepository)
        {
            _bookingRepository = bookingRepository;
            _eventRepository = eventRepository;
        }
        public async Task<bool> Handle(CancelBookingCommand command)
        {
            var bookingEntity = await _bookingRepository.GetByIdAsync(command.Id)
                ?? throw new NotFoundException($"Rezervacija sa ID {command.Id} ne postoji.");
            var eventEntity = await _eventRepository.GetByIdAsync(bookingEntity.EventId)
                ?? throw new NotFoundException("Dogadjaj sa tim ID-jem ne postoji");
            bookingEntity.Cancel();
            eventEntity.ReleaseSeats(bookingEntity.Quantity);
            await _bookingRepository.UpdateAsync(bookingEntity);
            await _eventRepository.UpdateAsync(eventEntity);
            return true;
        }
    }
}
