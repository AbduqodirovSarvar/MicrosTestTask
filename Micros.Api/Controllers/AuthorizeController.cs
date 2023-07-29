using MediatR;
using Micros.Application.UseCases.Authorize.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                Console.WriteLine($"{command.FirstName}   {command.Password}");
                var result = await _mediator.Send(command);
                Console.WriteLine($"{result.AccessToken}\n");
                return Ok(result.AccessToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Badrequest");
                return BadRequest(ex.Message);
            }
        }
    }
}
