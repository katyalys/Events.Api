using Application.Models;
using MediatR;

namespace Application.Resources.Commands.Delete
{
    public class DeleteByIdEventCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
