using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Events.Api.Resources.Commands.Create;
using Infrastucture.Data;
using MediatR;

namespace Events.Api.Resources.Commands
{
    // CHANGE CHANGE CHANGE!!!!
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly IGenericRepository<Event> _eventRepository;

        public CreateEventCommandHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            // add mapper here!!!!!!!!!!!!
            var eventModel = new Event
            {
                Theme = request.Theme,
                Description = request.Description,
                Plan = request.Plan,
                Organizer = request.Organizer,
                Speaker = request.Speaker,
                Date = request.Date,
                Location = request.Location,
            };

            await _eventRepository.AddAsync(eventModel);
            await _eventRepository.SaveAsync();
            return eventModel; 
        }
    }
}
