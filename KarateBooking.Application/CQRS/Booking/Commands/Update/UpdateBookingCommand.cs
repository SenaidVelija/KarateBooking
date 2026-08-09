using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Enums.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarateBooking.Application.CQRS.Booking.Commands.Update
{
    public class UpdateBookingCommand : ICommand<BookingDto>
    {
        public int Id { get; set; }
        public int NewQuantity { get; set; }
    }
}
