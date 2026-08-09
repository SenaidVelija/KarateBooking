using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;


namespace KarateBooking.Application.CQRS.Event.Queries.GetList
{
    public class GetEventListQueryHandler : IQueryHandler<GetEventListQuery, List<EventDto>>
    {
        private readonly IEventRepository _eventRepository;
        public GetEventListQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository= eventRepository;
        }
        public async Task<List<EventDto>> Handle(GetEventListQuery query)
        {
            var events = await _eventRepository.GetAllAsync();
            return events.Select(EventDto.FromEntity).ToList();
        }
    }
}
