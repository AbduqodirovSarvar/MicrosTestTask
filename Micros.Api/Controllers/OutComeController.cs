using MediatR;
using Micros.Application.UseCases.InComeCases.Query;
using Micros.Application.UseCases.OutComeCases.Command;
using Micros.Application.UseCases.OutComeCases.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutComeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OutComeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOutComeCommand command)
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

        [HttpGet("ByFilter")]
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
