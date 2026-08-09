

using KarateBooking.Domain.Entities.Event;

namespace KarateBooking.Application.DTO
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventType { get; set; } = "";
        public string EventStatus { get; set; } = "";
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public int ReservedCount { get; set; }
        public int AvailableCount { get; set; }
        public static EventDto FromEntity(EventEntity entity)
        {
            return new EventDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                EventType = entity.EventType.ToString(),
                EventStatus = entity.EventStatus.ToString(),
                Price = entity.Price,
                Capacity = entity.Capacity,
                ReservedCount = entity.ReservedCount,
                AvailableCount = entity.AvailableCount
            };
        }
    }
   
}
