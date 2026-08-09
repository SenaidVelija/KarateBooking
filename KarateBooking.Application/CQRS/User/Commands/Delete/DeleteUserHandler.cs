using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.User.Commands.Delete
{
    public class DeleteUserHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _eventRepository;
        public DeleteUserHandler(IUserRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand command)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(command.Id);
            if (eventEntity == null)
                throw new NotFoundException("Dogadjaj s tim ID-jem ne postoji");
           
            await _eventRepository.DeleteAsync(command.Id);
            return true;
        }
    }
}
