using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Enums.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarateBooking.Application.CQRS.User.Commands.Create
{
    public class CreateUserCommand : ICommand<UserDto>
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
    }
}
