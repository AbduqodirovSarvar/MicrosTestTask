using MediatR;
using Micros.Application.UseCases.UserCases.Command;
using Micros.Application.UseCases.UserCases.Query;
using Microsoft.AspNetCore.Mvc;

namespace Micros.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserCommand command)
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

        [HttpPatch("Update")]
        public async Task<IActionResult> Update(UpdateUserCommand command)
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteUserCommand(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            return Ok(await _mediator.Send(new GetUserQuery(Id)));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllUserQuery()));
        }

        [HttpGet("ByPosition")]
        public async Task<IActionResult> GetByPosition(GetAllUserByPositionQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
