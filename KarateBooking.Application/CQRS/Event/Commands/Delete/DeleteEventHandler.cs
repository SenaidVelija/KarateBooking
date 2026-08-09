using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.Event.Commands.Delete
{
    public class DeleteEventHandler : ICommandHandler<DeleteEventCommand, bool>
    {
        private readonly IEventRepository _eventRepository;
        public DeleteEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(DeleteEventCommand command)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(command.Id);
            if (eventEntity == null)
                throw new NotFoundException("Dogadjaj s tim ID-jem ne postoji");
            eventEntity.CanBeDeleted();
            await _eventRepository.DeleteAsync(command.Id);
            return true;
        }
    }
}
