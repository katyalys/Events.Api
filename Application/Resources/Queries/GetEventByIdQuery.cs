using Application.Models;
using MediatR;

namespace Application.Resources.Queries
{
    public class GetEventByIdQuery: IRequest<EventDto>
    {
        public int Id { get; set; }
    }
}
