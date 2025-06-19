using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.DTOs.Security;
using ToDo.Application.UseCases.Security.Command;
using ToDo.Domain.Common.Response;

namespace ToDo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("login")]
        [ProducesResponseType(typeof(BaseResponse<AuthResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<AuthResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<AuthResponse>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginDto)
        {
            var result = await _mediator.Send(loginDto);

            return Ok(result);
        }

        [HttpPost("create-user")]
        [ProducesResponseType(typeof(BaseResponse<CreateUserCommand>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<CreateUserCommand>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<CreateUserCommand>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
