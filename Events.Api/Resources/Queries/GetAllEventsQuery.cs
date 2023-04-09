using Application.Models;
using MediatR;

namespace Events.Api.Resources.Queries
{
    public class GetAllEventsQuery : IRequest<IEnumerable<EventModel>>
    {
    }
}
