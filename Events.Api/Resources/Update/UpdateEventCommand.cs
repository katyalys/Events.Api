using Application.Models;
using Core.Entity;
using MediatR;

namespace Events.Api.Resources.Update
{
    public class UpdateEventCommand : IRequest<EventModel>
    {
        public EventModel? UpdatedEvent { get; set; }
    }
}
