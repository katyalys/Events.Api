using Application.Models;
using MediatR;

namespace Events.Api.Resources.Commands.Delete
{
    public class DeleteByIdEventCommand: IRequest<EventModel>
    {
        public int Id { get; set; }
    }
}
