using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Handlers.AuthorHandler;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var values = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand createAuthorCommand)
        {
            await _mediator.Send(createAuthorCommand);
            return Ok("Ekleme işlemi başarılı.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Silme işlemi başarılı.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand updateAuthorCommand)
        {
            await _mediator.Send(updateAuthorCommand);
            return Ok("Güncelleme işlemi başarılı.");
        }
    }
}
