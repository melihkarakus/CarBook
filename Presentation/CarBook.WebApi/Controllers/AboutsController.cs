using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommand;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommand;
        private readonly RemoveAboutCommandHandler _removeAboutCommand;

        public AboutsController(CreateAboutCommandHandler createAboutCommand, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommand, RemoveAboutCommandHandler removeAboutCommand)
        {
            _createAboutCommand = createAboutCommand;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommand = updateAboutCommand;
            _removeAboutCommand = removeAboutCommand;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand createAboutCommand)
        {
            await _createAboutCommand.handle(createAboutCommand);
            return Ok("Başarıyla Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutCommand.Handle(new RemoveAboutCommand(id));
            return Ok("Başarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
        {
            await _updateAboutCommand.Handle(updateAboutCommand);
            return Ok("Başarıyla Güncellendi.");
        }
    }
}
