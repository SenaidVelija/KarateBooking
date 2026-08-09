using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Entities.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.Event.Commands.Create
{
    public class CreateEventHandler : ICommandHandler<CreateEventCommand, EventDto>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventDto> Handle(CreateEventCommand command)
        {
            var eventEntity = EventEntity.Create(command.Name,command.Description, command.StartDate,
                command.EndDate, command.EventType, command.Price, command.Capacity);
            await _eventRepository.AddAsync(eventEntity);
            return EventDto.FromEntity(eventEntity);
        }
    }
}
