using CarBook.Application.Features.Mediator.Commands.AddressCommands;
using CarBook.Application.Features.Mediator.Queries.AddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _mediator.Send(new GetAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAddress(int id)
        {
            var values = await _mediator.Send(new GetByIdAddressQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _mediator.Send(new RemoveAddressCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
