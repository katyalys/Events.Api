using Application.Exceptions;
using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Resources.Queries
{
    public class GetEventByIdQueryHandler: IRequestHandler<GetEventByIdQuery, EventDto>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        public GetEventByIdQueryHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;

         }

        public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(request.Id);
            if (existingEvent == null)
            {
                throw new EntityNotFoundException("No events");
            }
            var eventById = _mapper.Map<EventDto>(existingEvent);
            return eventById;
        }
    }
}
