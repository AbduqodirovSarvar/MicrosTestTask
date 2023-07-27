using MediatR;
using Micros.Application.UseCases.CommonCases.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByFilter([FromQuery] GetAllReportsByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
