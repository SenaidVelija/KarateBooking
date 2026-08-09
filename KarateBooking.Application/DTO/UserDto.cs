using KarateBooking.Domain.Entities.User;

namespace KarateBooking.Application.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        public static UserDto FromEntity(UserEntity entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };
        }
    }
}