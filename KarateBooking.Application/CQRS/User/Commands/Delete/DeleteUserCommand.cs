using KarateBooking.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarateBooking.Application.CQRS.User.Commands.Delete
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}
