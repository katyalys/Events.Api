using Application.Models;
using Core.Entity;
using MediatR;

namespace Application.Commands.Update
{
    public class UpdateEventCommand : IRequest<int>
    {
        public EventDto? UpdatedEvent { get; set; }
    }
}
