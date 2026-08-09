using KarateBooking.Domain.Enums.Booking;
using KarateBooking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateBooking.Domain.Entities.Booking
{
    public class BookingEntity
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int EventId { get; private set; }
        public int Quantity { get; private set; }
        public DateTime BookingDate { get; private set; }
        public BookingStatus Status { get; private set; }

        private BookingEntity() { }

        private BookingEntity(int userId, int eventId, int quantity)
        {
            UserId = userId;
            EventId = eventId;
            Quantity = quantity;
            BookingDate = DateTime.Now;
            Status = BookingStatus.Aktivna;
        }

        public static BookingEntity Create(int userId, int eventId, int quantity)
        {
            if (quantity <= 0)
                throw new ValidationException("Kolicina mora biti veca od nule.");

            return new BookingEntity(userId, eventId, quantity);
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (Status == BookingStatus.Otkazana)
                throw new BusinessRuleException("Ne moze se izmijeniti otkazana rezervacija.");
            if (newQuantity <= 0)
                throw new ValidationException("Kolicina mora biti veca od nule.");

            Quantity = newQuantity;
        }

        public void Cancel()
        {
            if (Status == BookingStatus.Otkazana)
                throw new BusinessRuleException("Rezervacija je vec otkazana.");

            Status = BookingStatus.Otkazana;
        }
    }
}
