using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Events.Api.Resources.Commands.Create;
using Infrastucture.Data;
using Mapster;
using MediatR;

namespace Events.Api.Resources.Commands
{
    // CHANGE CHANGE CHANGE!!!!
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;

        public CreateEventCommandHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventModel> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            //// add mapper here!!!!!!!!!!!!
            //var eventModel = new EventModel
            //{
            //    Theme = request.Theme,
            //    Description = request.Description,
            //    Plan = request.Plan,
            //    Organizer = request.Organizer,
            //    Speaker = request.Speaker,
            //    DateTime = request.DateTime,
            //    Place = request.Place,
            //};

            var newEvent = request.NewEvent.Adapt<Event>();
            await _eventRepository.AddAsync(newEvent);
            await _eventRepository.SaveAsync();
            return request.NewEvent; 
        }
    }
}
