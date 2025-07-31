using Microsoft.AspNetCore.Mvc;
using cqrs_mediator_api_example.DTO;
using cqrs_mediator_api_example.Commands.TodoItems;
using MediatR;
using cqrs_mediator_api_example.Queries;

namespace cqrs_mediator_api_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            var result = await _mediator.Send(new GetAllTodoItemsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var query = new GetTodoItemByIdQuery { Id = id };

            var result = await _mediator.Send(query);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItemDTO>> PutTodoItem(long id, [FromBody] UpdateTodoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            var updated = await _mediator.Send(command);
            return updated is null ? NotFound() : NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem([FromBody] CreateTodoItemCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTodoItem), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemDTO>> DeleteTodoItem(long id)
        {
            var command = new DeleteTodoItemCommand { Id = id };
            var deleted = await _mediator.Send(command);
            return deleted is null ? NotFound() : Ok(deleted);
        }
    }
}
