

using KarateBooking.Domain.Enums.Event;
using KarateBooking.Domain.Exceptions;

namespace KarateBooking.Domain.Entities.Event
{
    public class EventEntity
    {

        public int Id { get; private set; }
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public EventType EventType { get; private set; }
        public EventStatus EventStatus { get; private set; }
        public decimal Price { get; private set; }
        public int Capacity { get; private set; }
        public int ReservedCount { get; private set; }
        public int AvailableCount => Capacity - ReservedCount;

        private EventEntity() { }

        private EventEntity(string name, string description, DateTime startDate,
            DateTime endDate, EventType eventType, decimal price, int capacity)
        {
     
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            EventType = eventType;
            EventStatus = EventStatus.Zakazan;
            Price = price;
            Capacity = capacity;
            ReservedCount = 0;
        }
        public static EventEntity Create(string name, string description, DateTime startDate,
            DateTime endDate, EventType eventType, decimal price, int capacity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Morate unijeti ime dogadjaja");
            if (endDate < startDate)
                throw new ValidationException("Datum zavrsetka dogadjaja ne moze biti prije datuma pocetka");
            if (startDate < DateTime.Now)
                throw new ValidationException("Datum pocetka ne moze biti u proslosti");
            return new EventEntity(name, description, startDate, endDate, eventType, price, capacity);
        }
        public void UpdateDetails(string name, string description, DateTime startDate,
            DateTime endDate, EventType eventType, decimal price, int capacity)
        {
            if (EventStatus != EventStatus.Zakazan)
                throw new BusinessRuleException("Samo dogadjaj u statusu Zakazan moze biti izmijenjen.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Morate unijeti ime dogadjaja");
            if (endDate < startDate)
                throw new ValidationException("Datum zavrsetka dogadjaja ne moze biti prije datuma pocetka");
            if (startDate < DateTime.Now)
                throw new ValidationException("Datum pocetka ne moze biti u proslosti");

            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            EventType = eventType;
            Price = price;
            Capacity = capacity;
        }
        public void Cancel()
        {
            if (EventStatus == EventStatus.Zavrsen)
                throw new BusinessRuleException("Ne moze se otkazati dogadjaj koji je zavrsen");
            EventStatus=EventStatus.Otkazan;
        }
        public void CanBeDeleted()
        {
            if (EventStatus == EventStatus.UToku)
                throw new BusinessRuleException("Ne mozete obrisati dogadjaj koji je u toku");
            
        }
        public void ReserveSeats(int quantity)
        {
            if (quantity <= 0)
                throw new ValidationException("Kolicina mora biti veca od nule.");
            if (quantity > AvailableCount)
                throw new BusinessRuleException($"Nema dovoljno slobodnih mjesta. Dostupno: {AvailableCount}");

            ReservedCount += quantity;
        }

        public void ReleaseSeats(int quantity)
        {
            ReservedCount -= quantity;
            if (ReservedCount < 0) ReservedCount = 0;
        }

    }
}
