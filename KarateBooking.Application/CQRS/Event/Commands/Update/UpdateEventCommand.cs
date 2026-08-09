using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Enums.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarateBooking.Application.CQRS.Event.Commands.Update
{
    public class UpdateEventCommand : ICommand<EventDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventType EventType { get; set; }
        public EventStatus EventStatus { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
