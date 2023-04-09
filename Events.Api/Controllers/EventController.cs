using Application.Models;
using Events.Api.Resources.Commands.Create;
using Events.Api.Resources.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Events.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEvent(CreateEventCommand commandCreate)
        {
            try
            {
                var response = await _mediator.Send(commandCreate);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var command = new DeleteByIdEventCommand() { Id = id };
                var response = await _mediator.Send(command);
                return response is not null ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}