using cqrs_mediator_api_example.DTO;
using MediatR;

namespace cqrs_mediator_api_example.Commands.TodoItems
{
    public class CreateTodoItemCommand: IRequest<TodoItemDTO>
    {
        public string? Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
