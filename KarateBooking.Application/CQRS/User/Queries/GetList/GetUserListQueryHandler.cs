using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Event.Queries.GetList;
using KarateBooking.Application.DTO;


namespace KarateBooking.Application.CQRS.User.Queries.GetList
{
    public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
        public async Task<List<UserDto>> Handle(GetUserListQuery query)
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(UserDto.FromEntity).ToList();
        }
    }
}
