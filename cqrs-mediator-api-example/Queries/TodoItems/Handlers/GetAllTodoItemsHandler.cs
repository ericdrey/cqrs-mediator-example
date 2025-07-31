using cqrs_mediator_api_example.DTO;
using cqrs_mediator_api_example.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_mediator_api_example.Queries.TodoItems.Handlers
{
    public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItemDTO>>
    {
        private readonly TodoContext _context;

        public GetAllTodoItemsHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItemDTO>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .Select(t => new TodoItemDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    IsCompleted = t.IsCompleted
                }).ToListAsync();
        }
    }
}
