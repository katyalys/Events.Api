using Application.Models;
using MediatR;

namespace Events.Api.Resources.Queries
{
    public class GetEventByIdQuery: IRequest<EventModel>
    {
        public int Id { get; set; }
    }
}
