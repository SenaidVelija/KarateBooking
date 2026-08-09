using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarateBooking.Application.CQRS.User.Commands.Update
{
    public class UpdateUserCommand : ICommand<UserDto>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
    }
}
