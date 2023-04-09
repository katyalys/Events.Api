using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Mapster;
using MediatR;

namespace Events.Api.Resources.Queries
{
    public class GetEventByIdQueryHandler: IRequestHandler<GetEventByIdQuery, EventModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        public GetEventByIdQueryHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventModel> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(request.Id);
            if (existingEvent == null)
            {
                throw new ApplicationException("Product with this id is not exists");
            }
            var eventById = existingEvent.Adapt<EventModel>();
            return eventById;
        }
    }
}
