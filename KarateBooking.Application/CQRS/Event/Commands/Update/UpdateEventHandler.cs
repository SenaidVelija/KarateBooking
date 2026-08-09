using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.Event.Commands.Update
{
    public class UpdateEventHandler : ICommandHandler<UpdateEventCommand, EventDto>
    {
        private readonly IEventRepository _eventRepository;
        public UpdateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventDto> Handle(UpdateEventCommand command)
        {
            var eventEntity= await _eventRepository.GetByIdAsync(command.Id);
            if (eventEntity == null)
                throw new NotFoundException("Dogadjaj s tim ID-jem ne postoji");
            eventEntity.UpdateDetails(command.Name, command.Description, command.StartDate,
                command.EndDate, command.EventType, command.Price, command.Capacity);
            await _eventRepository.UpdateAsync(eventEntity);
            return EventDto.FromEntity(eventEntity);
        }
    }
}
