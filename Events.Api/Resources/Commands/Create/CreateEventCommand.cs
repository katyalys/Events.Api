using Core.Entity;
using MediatR;
using Application.Models;

namespace Events.Api.Resources.Commands.Create
{
    public class CreateEventCommand: BaseEntity, IRequest<EventModel>
    {
        public EventModel? NewEvent { get; set; }
    }
}
