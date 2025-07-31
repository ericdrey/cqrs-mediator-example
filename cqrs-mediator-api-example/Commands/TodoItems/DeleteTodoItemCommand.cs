using MediatR;
using cqrs_mediator_api_example.DTO;

namespace cqrs_mediator_api_example.Commands.TodoItems
{
    public class DeleteTodoItemCommand : IRequest<TodoItemDTO>
    {
        public long Id { get; set; }
    }
}
