using Application.Models;
using MediatR;

namespace Application.Resources.Queries
{
    public class GetAllEventsQuery : IRequest<IEnumerable<EventDto>>
    {
    }
}
