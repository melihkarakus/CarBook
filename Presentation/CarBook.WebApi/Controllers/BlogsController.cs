using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
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
        public async Task<IActionResult> GetBlog(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(values);
        }
        [HttpGet("GetLast3BlogWithAuthors")]
        public async Task<IActionResult> GetLast3BlogWithAuthors()
        {
            var values = await _mediator.Send(new GetLast3BlogWithAuthorsQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand createBlogCommand)
        {
            await _mediator.Send(createBlogCommand);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Silme işlemi başarılı.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand updateBlogCommand)
        {
            await _mediator.Send(updateBlogCommand);
            return Ok("Güncelleme işlemi başarılı");
        }
        
    }
}
