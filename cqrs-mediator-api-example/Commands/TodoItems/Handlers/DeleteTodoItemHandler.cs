using cqrs_mediator_api_example.Models;
using cqrs_mediator_api_example.DTO;
using MediatR;

namespace cqrs_mediator_api_example.Commands.TodoItems.Handlers
{
    public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, TodoItemDTO>
    {
        public readonly TodoContext _context;

        public DeleteTodoItemHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItemDTO> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.TodoItems.FindAsync(request.Id);
            if (item == null)
            {
                return null;
            }
            _context.TodoItems.Remove(item);
             await _context.SaveChangesAsync();

            return new TodoItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                IsCompleted = item.IsCompleted
            };
        }
    }
}
