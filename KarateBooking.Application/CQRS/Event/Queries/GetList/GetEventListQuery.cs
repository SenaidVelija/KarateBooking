

using KarateBooking.Application.Common;
using KarateBooking.Application.DTO;

namespace KarateBooking.Application.CQRS.Event.Queries.GetList
{
    public class GetEventListQuery : IQuery<List<EventDto>>
    {
    }
}
