

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

        private EventEntity() { }

        private EventEntity(string name, string description, DateTime startDate,
            DateTime endDate, EventType eventType)
        {
     
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            EventType = eventType;
            EventStatus = EventStatus.Zakazan;
        }
        public static EventEntity Create(string name, string description, DateTime startDate,
            DateTime endDate, EventType eventType)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Morate unijeti ime dogadjaja");
            if (endDate < startDate)
                throw new ValidationException("Datum zavrsetka dogadjaja ne moze biti prije datuma pocetka");
            if (startDate < DateTime.Now)
                throw new ValidationException("Datum pocetka ne moze biti u proslosti");
            return new EventEntity(name, description, startDate, endDate, eventType);
        }
        public void UpdateDetails(string name, string description, DateTime startDate,
            DateTime endDate, EventType eventType)
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
        public void MarkAsFinished()
        {
            if (EventStatus != EventStatus.UToku)
                throw new BusinessRuleException("Samo dogadjaj koji je u toku moze biti oznacen kao zavrsen");
            EventStatus=EventStatus.Zavrsen;
        }
        public void MarkAsInProgress()
        {
            if (EventStatus != EventStatus.Zakazan)
                throw new BusinessRuleException("Samo dogadjaj koji je u statusu Zakazan moze preci u status U toku");
            EventStatus = EventStatus.UToku;
        }
    }
}
