using KarateBooking.Application.Common;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.Event.Commands.Cancel
{
    public class CancelEventHandler : ICommandHandler<CancelEventCommand, bool>
    {
        private readonly IEventRepository _eventRepository;

        public CancelEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<bool> Handle(CancelEventCommand command)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(command.Id)
                ?? throw new NotFoundException($"Dogadjaj sa ID {command.Id} ne postoji.");

            eventEntity.Cancel();

            await _eventRepository.UpdateAsync(eventEntity);

            return true;
        }
    }
}
