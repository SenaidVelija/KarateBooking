using KarateBooking.Domain.Exceptions;

namespace KarateBooking.Domain.Entities.User
{
    public class UserEntity
    {
        public int Id { get; private set; }
        public string FullName { get; private set; } = "";
        public string Email { get; private set; } = "";
        public string PhoneNumber { get; private set; } = "";

        private UserEntity() { }

        private UserEntity(string fullName, string email, string phoneNumber)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public static UserEntity Create(string fullName, string email, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ValidationException("Ime i prezime su obavezni.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                throw new ValidationException("Email nije validan.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ValidationException("Broj telefona je obavezan.");

            return new UserEntity(fullName, email, phoneNumber);
        }

        public void UpdateDetails(string fullName, string email, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ValidationException("Ime i prezime su obavezni.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                throw new ValidationException("Email nije validan.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ValidationException("Broj telefona je obavezan.");

            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}