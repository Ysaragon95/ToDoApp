using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.DTOs.Business.Todo;
using ToDo.Application.UseCases.Business.Todo.Command;
using ToDo.Application.UseCases.Business.Todo.Query;
using ToDo.Domain.Common.Response;

namespace ToDo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("create-todo")]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] CreateTodoCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPut("update-todo")]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateTodoCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("delete-todo")]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<int>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromQuery] DeleteTodoCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("list-todo")]
        [ProducesResponseType(typeof(BaseResponse<List<AllTodoQueryResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<List<AllTodoQueryResponse>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<List<AllTodoQueryResponse>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] AllTodoQuery request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
