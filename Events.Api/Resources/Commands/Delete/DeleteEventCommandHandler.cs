using Application.Models;
using Core.Entity;
using Core.Interfaces;
using Mapster;
using MediatR;

namespace Events.Api.Resources.Commands.Delete
{
    public class DeleteEventCommandHandler: IRequestHandler<DeleteByIdEventCommand, EventModel>
    {
        private readonly IGenericRepository<Event> _eventRepository;

        public DeleteEventCommandHandler(IGenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventModel> Handle(DeleteByIdEventCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _eventRepository.GetByIdAsync(request.Id);
            if (existingProduct == null)
            {
                throw new ApplicationException("Product with this id is not exists");
            }
            var newEvent = existingProduct.Adapt<EventModel>();
            await _eventRepository.DeleteAsync(existingProduct);
            return newEvent;
        }
    }
}
