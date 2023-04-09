using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Mapster;
using MediatR;

namespace Events.Api.Resources.Commands.Update
{
    public class UpdateEventCommandHandler: IRequestHandler<UpdateEventCommand, EventModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;

        public UpdateEventCommandHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventModel> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventUpdated = request.UpdatedEvent.Adapt<Event>();
            var existingEvent = await _eventRepository.GetByIdAsync(eventUpdated.Id);
            if (existingEvent == null)
            {
                throw new ApplicationException("Product with this id is not exists");
            }
            existingEvent.Plan = eventUpdated.Plan;
            existingEvent.Description = eventUpdated.Description;
            existingEvent.Location = eventUpdated.Location;
            existingEvent.Organizer = eventUpdated.Organizer;
            existingEvent.Speaker = eventUpdated.Speaker;
            existingEvent.Theme = eventUpdated.Theme;
            existingEvent.Date = eventUpdated.Date;
            await _eventRepository.UpdateAsync(existingEvent);
            return request.UpdatedEvent;
        }
    }
}
