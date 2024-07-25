using CarBook.Application.Features.Mediator.Handlers.CarPricingHandler;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarPricingQueryHandler")]
        public async Task<IActionResult> GetCarPricingQueryHandler()
        {
            var values = await _mediator.Send(new GetCarPricingQuery());
            return Ok(values);
        }
    }
}
