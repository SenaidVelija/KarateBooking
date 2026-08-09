using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.User.Commands.Update
{
    public class UpdateUserHandler : ICommandHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(UpdateUserCommand command)
        {
            var userEntity= await _userRepository.GetByIdAsync(command.Id);
            if (userEntity == null)
                throw new NotFoundException("Dogadjaj s tim ID-jem ne postoji");
            userEntity.UpdateDetails(command.FullName, command.Email, command.PhoneNumber);
            await _userRepository.UpdateAsync(userEntity);
            return UserDto.FromEntity(userEntity);
        }
    }
}
