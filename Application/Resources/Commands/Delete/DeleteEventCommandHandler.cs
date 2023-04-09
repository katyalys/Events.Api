using Application.Exceptions;
using Application.Models;
using Application.Resources.Commands.Delete;
using Core.Entity;
using Core.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Commands.Delete
{
    public class DeleteEventCommandHandler: IRequestHandler<DeleteByIdEventCommand, int>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IGenericRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;   
        }

        public async Task<int> Handle(DeleteByIdEventCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _eventRepository.GetByIdAsync(request.Id);
            if (existingProduct == null)
            {
                throw new EntityNotFoundException("Event with this id is not exists");
            }
            var newEvent = _mapper.Map<EventDto>(existingProduct);
            await _eventRepository.DeleteAsync(existingProduct);
            return newEvent.Id;
        }
    }
}
