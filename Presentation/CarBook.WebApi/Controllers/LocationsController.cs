using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdLocation(int id)
        {
            var values = await _mediator.Send(new GetByIdLocationQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
