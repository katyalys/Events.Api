using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Mapster;
using MediatR;

namespace Events.Api.Resources.Queries
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<EventModel>>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        public GetAllEventsQueryHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<EventModel>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.ListAllAsync();
            var eventsModel = events.Adapt<IEnumerable<EventModel>>();
            return eventsModel;
        }
    }
}
