using Core.Entity;
using MediatR;

namespace Events.Api.Resources.Commands.Create
{
    public class CreateEventCommand: BaseEntity, IRequest<Event>
    {
        public string? Theme { get; set; }
        public string? Description { get; set; }
        public string? Plan { get; set; }
        public string? Organizer { get; set; }
        public string? Speaker { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
    }
}
