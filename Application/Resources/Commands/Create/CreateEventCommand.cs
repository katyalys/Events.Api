using Core.Entity;
using MediatR;
using Application.Models;

namespace Application.Resources.Commands.Create
{
    public class CreateEventCommand: IRequest<int>
    {
        public EventDto? NewEvent { get; set; }
    }
}
