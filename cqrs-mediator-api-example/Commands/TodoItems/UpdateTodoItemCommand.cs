using cqrs_mediator_api_example.DTO;
using MediatR;

namespace cqrs_mediator_api_example.Commands.TodoItems
{
    public class UpdateTodoItemCommand : IRequest<TodoItemDTO>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
