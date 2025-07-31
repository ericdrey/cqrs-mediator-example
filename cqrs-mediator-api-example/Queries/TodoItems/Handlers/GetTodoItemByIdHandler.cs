using cqrs_mediator_api_example.Models;
using cqrs_mediator_api_example.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_mediator_api_example.Queries.TodoItems.Handlers
{
    public class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemDTO>
    {
        public readonly TodoContext _context;

        public GetTodoItemByIdHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItemDTO> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(request.Id);
            if (entity == null)
            {
                return null;
            }

            return new TodoItemDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                IsCompleted = entity.IsCompleted
            };
        }
    }
}
