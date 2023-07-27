using MediatR;
using Micros.Application.UseCases.InComeCases.Command;
using Micros.Application.UseCases.InComeCases.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InComeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InComeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateInComeCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetAllInComeByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            return Ok(await _mediator.Send(new GetInComeByIdQuery(Id)));
        }

    }
}
