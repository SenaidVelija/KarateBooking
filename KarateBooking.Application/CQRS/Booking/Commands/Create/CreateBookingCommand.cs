using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Enums.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarateBooking.Application.CQRS.Booking.Commands.Create
{
    public class CreateBookingCommand : ICommand<BookingDto>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }
    }
}
