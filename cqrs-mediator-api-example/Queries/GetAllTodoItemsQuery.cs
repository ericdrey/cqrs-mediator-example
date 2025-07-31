using cqrs_mediator_api_example.DTO;
using MediatR;

namespace cqrs_mediator_api_example.Queries
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItemDTO>>
    {
    }
}
