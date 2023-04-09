using Application.Exceptions;
using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Commands.Update
{
    public class UpdateEventCommandHandler: IRequestHandler<UpdateEventCommand, int>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventUpdated = _mapper.Map<Event>(request);
            if (eventUpdated == null)
                throw new EntityNotFoundException("Event with this id is not exists");

            await _eventRepository.UpdateAsync(eventUpdated);
            return eventUpdated.Id;
        }
    }
}
