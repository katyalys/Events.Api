using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Resources.Queries
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<EventDto>>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        public GetAllEventsQueryHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.ListAllAsync();
            var eventsModel = _mapper.Map<IEnumerable<EventDto>>(events);
            return eventsModel;
        }
    }
}
