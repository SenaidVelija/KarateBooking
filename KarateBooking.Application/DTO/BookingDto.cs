using KarateBooking.Domain.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Application.DTO
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
        public int EventId { get; set; }
        public string EventName { get; set; } = "";
        public int Quantity { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = "";

        public static BookingDto FromEntity(BookingEntity entity, string userName, string eventName)
        {
            return new BookingDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                UserName = userName,
                EventId = entity.EventId,
                EventName = eventName,
                Quantity = entity.Quantity,
                BookingDate = entity.BookingDate,
                Status = entity.Status.ToString()
            };
        }
    }
}
