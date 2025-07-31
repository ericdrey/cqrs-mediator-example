using MediatR;
using cqrs_mediator_api_example.DTO;

namespace cqrs_mediator_api_example.Queries
{
    public class GetTodoItemByIdQuery : IRequest<TodoItemDTO>
    {
        public long Id { get; set; }
    }
}
