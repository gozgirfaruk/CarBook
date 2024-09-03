using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBlog(int id)
        {
            var values = await _mediator.Send(new GetByIdBlogQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet("LastThreeBlog")]
        public async Task<IActionResult> LastThreeBlog()
        {
            var values = await _mediator.Send(new GetBlogWithAuthorQuery());
            return Ok(values.Take(3));
        }
        [HttpGet("GetBlogWithAuhtor")]
        public async Task<IActionResult> GetBlogWithAuhtor()
        {
            var values = await _mediator.Send(new GetBlogWithAuthorQuery());
            return Ok(values);
        }

    }
}
