using MediatR;
using Micros.Application.UseCases.InComeCases.Query;
using Micros.Application.UseCases.OutComeCases.Command;
using Micros.Application.UseCases.OutComeCases.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OutComeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OutComeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateOutComeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetAllOutComeByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            return Ok(await _mediator.Send(new GetOutComeByIdQuery(Id)));
        }
    }
}
