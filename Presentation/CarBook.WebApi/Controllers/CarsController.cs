using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetCarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCar(int id)
        {
            var values = await _mediator.Send(new GetByIdCarQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet("CarWithBrand")]
        public async Task<IActionResult> CarWithBrand()
        {
            var values= await _mediator.Send(new GetCarWithBrandQuery());
            return Ok(values);
        }
        [HttpGet("Get5Car")]
        public async Task<IActionResult> Get5Car()
        {
            var values = await _mediator.Send(new GetCarWithBrandQuery());
            return Ok(values.Take(5));  
        }
    }
}
