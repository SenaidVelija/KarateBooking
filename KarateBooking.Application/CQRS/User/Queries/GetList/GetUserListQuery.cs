

using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;

namespace KarateBooking.Application.CQRS.User.Queries.GetList
{
    public class GetUserListQuery : IQuery<List<UserDto>>
    {
    }
}
