using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.CQRS.User.Commands.Create
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(CreateUserCommand command)
        {
            var userEntity = UserEntity.Create(command.FullName, command.Email, command.PhoneNumber);
            await _userRepository.AddAsync(userEntity);
            return UserDto.FromEntity(userEntity);
        }
    }
}
